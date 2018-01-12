namespace OfaSchlupfer.Elementary.Immutable {
    using System;

    /// <summary>
    /// Base implementation
    /// </summary>
    /// <typeparam name="TModel">The model type.</typeparam>
    public class BuilderBase<TModel>
        : IBuilder<TModel>
        , IDisposable
        , IFreezeReceiver
        where TModel : IBuildTarget {
        protected readonly Action<TModel> _SetUnFrozen;
        protected readonly Action<TModel> _SetFrozen;
        protected TModel _Target;
        protected FreezeReceiver _FreezeReceiver;
        private bool _CloneNeeded;

        /// <summary>
        /// Initializes a new instance of the <see cref="BuilderBase{TModel}"/> class.
        /// </summary>
        /// <param name="target">the target</param>
        /// <param name="clone">always clone</param>
        /// <param name="setUnFrozen">will be called if target is set to another instance - unfrozen.</param>
        /// <param name="setFrozen">will be called if target is set to another instance - frozen.</param>
        protected BuilderBase(TModel target, bool clone, Action<TModel> setUnFrozen, Action<TModel> setFrozen) {
            this._Target = target;
            this._SetUnFrozen = setUnFrozen ?? NoOp;
            this._SetFrozen = setFrozen ?? NoOp;
            this._CloneNeeded = clone;
            target.AddFreezeReceiver(this._FreezeReceiver = new FreezeReceiver(this));
        }

        private static void NoOp(TModel model) { }

        /// <summary>
        /// Gets a unfrozen instance.
        /// </summary>
        /// <returns>a unfrozen instance.</returns>
        protected virtual TModel EnsureUnfrozen() {
            if (this._Target.IsFrozen || this._CloneNeeded) {
                this._CloneNeeded = false;
                var target = (TModel)this._Target.UnFreeze(false);
                if (!ReferenceEquals(this._Target, target)) {
                    this._Target = target;
                    this._FreezeReceiver?.SetDone();
                    target.AddFreezeReceiver(this._FreezeReceiver = new FreezeReceiver(this));
                    this._SetUnFrozen(target);
                }
                return target;
            } else {
                return this._Target;
            }
        }

        /// <summary>
        /// Gets the target.
        /// </summary>
        /// <returns>a frozen target.</returns>
        public TModel GetTarget() {
            var target = this._Target;
            if (!(target.IsFrozen)) {
                target.Freeze();
                this._SetFrozen(target);
            }
            return target;
        }

        public void Dispose() {
            this._FreezeReceiver?.SetDone();
            this._FreezeReceiver = null;
        }

        public virtual bool HandleFreeze(IBuildTarget frozen) {
            this._SetFrozen((TModel)frozen);
            return false;
        }

        public virtual bool HandleUnFreeze(IBuildTarget previous, IBuildTarget next) {
            if (ReferenceEquals(previous, next)) {
                return false;
            }
            if (ReferenceEquals(this._Target, previous)) {
                var target = (TModel)next;
                this._Target = target;
                this._FreezeReceiver?.SetDone();
                target.AddFreezeReceiver(this._FreezeReceiver = new FreezeReceiver(this));
                this._SetUnFrozen(target);
            }
            return false;
        }

        protected class FreezeReceiver : IFreezeReceiver {
            public BuilderBase<TModel> BuilderBase;
            public bool Done;

            public FreezeReceiver(BuilderBase<TModel> builderBase) {
                this.BuilderBase = builderBase;
            }

            public void SetDone() {
                this.BuilderBase = null;
                this.Done = true;
            }

            public bool HandleFreeze(IBuildTarget frozen) {
                if (this.BuilderBase == null) {
                    return true;
                } else {
                    return this.BuilderBase.HandleFreeze(frozen);
                }
            }

            public bool HandleUnFreeze(IBuildTarget previous, IBuildTarget next) {
                if (this.BuilderBase == null) {
                    return true;
                } else {
                    return this.BuilderBase.HandleUnFreeze(previous, next);
                }
            }
        }
    }
}
