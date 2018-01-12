#pragma warning disable SA1402

namespace OfaSchlupfer.Elementary.Immutable {
    using System;

    /// <summary>
    /// Extension Helper ModelBuilderPair
    /// </summary>
    public static class ModelBuilderPair {
        /// <summary>
        /// Create a <see cref="ModelBuilderPair{TModel, TBuilder}"/>.
        /// </summary>
        /// <typeparam name="TModel">the immutable model</typeparam>
        /// <typeparam name="TBuilder">the builder</typeparam>
        /// <param name="model">the model</param>
        /// <param name="factoryGetBuilder">function to get a builder.</param>
        /// <param name="setUnFrozen">the action if unfrozen instance is generated.</param>
        /// <param name="setFrozen">the action if frozen instance is generated.</param>
        /// <returns>A ModelBuilderPair.</returns>
        public static ModelBuilderPair<TModel, TBuilder> FactoryModelBuilderPair<TModel, TBuilder>(
            this TModel model,
            Func<TModel, bool, Action<TModel>, Action<TModel>, TBuilder> factoryGetBuilder,
            Action<TBuilder, TModel> setUnFrozen,
            Action<TBuilder, TModel> setFrozen)
            where TModel : IBuildTarget
            where TBuilder : IBuilder<TModel> {
            var result = new ModelBuilderPair<TModel, TBuilder>(model, default(TBuilder), setUnFrozen, setFrozen);
            var builder = factoryGetBuilder(model, false, result.HandleSetUnFrozen, result.HandleSetFrozen);
            result.SetBuilder(builder);
            return result;
        }

        /// <summary>
        /// Create a <see cref="ModelBuilderProperty{TOwner, TOwnerBuilder, TModel, TModelBuilder}"/>.
        /// </summary>
        /// <typeparam name="TOwner">the owner model</typeparam>
        /// <typeparam name="TOwnerBuilder">the owner builder</typeparam>
        /// <typeparam name="TModel">the immutable model</typeparam>
        /// <typeparam name="TBuilder">the builder</typeparam>
        /// <param name="ownerPair">the owner pair</param>
        /// <param name="getModel">function to get model.</param>
        /// <param name="setFrozenOwner">action to set the model</param>
        /// <param name="factoryGetBuilder">function to get a builder.</param>
        /// <param name="setUnFrozen">the action if unfrozen instance is generated.</param>
        /// <param name="setFrozen">the action if frozen instance is generated.</param>
        /// <returns>a ModelBuilderProperty</returns>
        public static ModelBuilderProperty<TOwner, TOwnerBuilder, TModel, TBuilder> FactoryModelBuilderProperty<TOwner, TOwnerBuilder, TModel, TBuilder>(
            this ModelBuilderPair<TOwner, TOwnerBuilder> ownerPair,
            Func<TOwner, TModel> getModel,
            Action<TOwnerBuilder, TModel> setFrozenOwner,
            Func<TModel, bool, Action<TModel>, Action<TModel>, TBuilder> factoryGetBuilder,
            Action<TBuilder, TModel> setUnFrozen = null,
            Action<TBuilder, TModel> setFrozen = null)
            where TOwner : IBuildTarget
            where TOwnerBuilder : IBuilder<TOwner>
            where TModel : IBuildTarget
            where TBuilder : IBuilder<TModel> {
            var result = new ModelBuilderProperty<TOwner, TOwnerBuilder, TModel, TBuilder>(ownerPair, getModel, default(TBuilder), setFrozenOwner, setUnFrozen, setFrozen);
            var builder = factoryGetBuilder(result.Model, false, result.HandleSetUnFrozen, result.HandleSetFrozen);
            result.SetBuilder(builder);
            return result;
        }
    }

    /// <summary>
    /// Model + Builder
    /// </summary>
    /// <typeparam name="TModel">the immutable model</typeparam>
    /// <typeparam name="TModelBuilder">the builder</typeparam>
    public class ModelBuilderPair<TModel, TModelBuilder>
         : IFreezeReceiver, IDisposable
        where TModel : IBuildTarget
        where TModelBuilder : IBuilder<TModel> {
        private TModel _Model;
        private TModelBuilder _Builder;
        private Action<TModelBuilder, TModel> _setUnFrozen;
        private Action<TModelBuilder, TModel> _setFrozen;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelBuilderPair{M, B}"/> class.
        /// </summary>
        /// <param name="model">the model - cannot be null.</param>
        /// <param name="builder">the builder - can be null</param>
        /// <param name="setUnFrozen">the action if unfrozen instance is generated.</param>
        /// <param name="setFrozen">the action if frozen instance is generated.</param>
        public ModelBuilderPair(
            TModel model,
            TModelBuilder builder,
            Action<TModelBuilder, TModel> setUnFrozen,
            Action<TModelBuilder, TModel> setFrozen) {
            if ((object)model == null) { throw new ArgumentNullException(nameof(model)); }
            this._Model = model;
            this._Builder = builder;
            this._setUnFrozen = setUnFrozen ?? NoOp;
            this._setFrozen = setFrozen ?? NoOp;
        }

        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerNonUserCode]
        [System.Diagnostics.DebuggerStepThrough]
        private static void NoOp(TModelBuilder builder, TModel model) { }

        /// <summary>
        /// Gets the model.
        /// </summary>
        public TModel Model => this._Model;

        /// <summary>
        /// Gets the builder.
        /// </summary>
        public TModelBuilder Builder => this._Builder;

        /// <summary>
        /// Gets a frozen target.
        /// </summary>
        /// <returns>A frozen target.</returns>
        public TModel GetTarget() {
            var result = this._Builder.GetTarget();
            /*
            this._setUnFrozen(this._Builder, result);
            this._setFrozen(this._Builder, result);
            */
            return result;
        }

        internal void SetBuilder(TModelBuilder builder) {
            if (!ReferenceEquals(this._Builder, null)) { throw new InvalidOperationException("Builder is already set"); }
            this._Builder = builder;
        }

        /// <summary>
        /// Set the model.
        /// </summary>
        /// <param name="model">the new model.</param>
        internal void HandleSetUnFrozen(TModel model) {
            // System.Diagnostics.Debug.WriteLine("HandleSetUnFrozen");
            this._Model = model;
            this._setUnFrozen(this._Builder, model);
        }

        internal void HandleSetFrozen(TModel model) {
            // System.Diagnostics.Debug.WriteLine("HandleSetFrozen");
            this._Model = model;
            this._setFrozen(this._Builder, model);
        }

        public bool HandleFreeze(IBuildTarget frozen) {
            var model = (TModel)frozen;
            this._Model = model;
            this._setFrozen(this._Builder, model);
            return ReferenceEquals(this.Builder, null);
        }

        public bool HandleUnFreeze(IBuildTarget previous, IBuildTarget next) {
            var model = (TModel)next;
            this._Model = model;
            this._setUnFrozen(this._Builder, model);
            return ReferenceEquals(this.Builder, null);
        }
        /*
        internal void SetFrozenOwner(Action<TOwnerBuilder, TModel> setFrozenModel) {
            this._setFrozenOwner = setFrozenModel ?? NoOpOwner;
        }
        */

        public void Dispose() {
            this._Builder = default(TModelBuilder);
            this._Model = default(TModel);
        }
    }

    /// <summary>
    /// Model + Builder
    /// </summary>
    /// <typeparam name="TOwner">the owner</typeparam>
    /// <typeparam name="TOwnerBuilder">the builder owner</typeparam>
    /// <typeparam name="TModel">the immutable model</typeparam>
    /// <typeparam name="TModelBuilder">the builder</typeparam>
    public class ModelBuilderProperty<TOwner, TOwnerBuilder, TModel, TModelBuilder>
        : IFreezeReceiver, IDisposable
        where TOwner : IBuildTarget
        where TOwnerBuilder : IBuilder<TOwner>
        where TModel : IBuildTarget
        where TModelBuilder : IBuilder<TModel> {
        private Func<TOwner, TModel> _getModel;
        private ModelBuilderPair<TOwner, TOwnerBuilder> _OwnerPair;
        private TModel _Model;
        private TModelBuilder _Builder;
        private Action<TOwnerBuilder, TModel> _setFrozenOwner;
        private Action<TModelBuilder, TModel> _setUnFrozen;
        private Action<TModelBuilder, TModel> _setFrozen;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelBuilderProperty{TOwner, TOwnerBuilder, TModel, TModelBuilder}"/> class.
        /// </summary>
        /// <param name="ownerPair">the owner.</param>
        /// <param name="getModel">the model - cannot be null.</param>
        /// <param name="builder">the builder - can be null</param>
        /// <param name="setFrozenOwner">the a frozen owner.</param>
        /// <param name="setUnFrozen">the action if unfrozen instance is generated.</param>
        /// <param name="setFrozen">the action if frozen instance is generated.</param>
        public ModelBuilderProperty(
            ModelBuilderPair<TOwner, TOwnerBuilder> ownerPair,
            Func<TOwner, TModel> getModel,
            TModelBuilder builder,
            Action<TOwnerBuilder, TModel> setFrozenOwner,
            Action<TModelBuilder, TModel> setUnFrozen,
            Action<TModelBuilder, TModel> setFrozen) {
            TModel model = getModel(ownerPair.Model);
            if ((object)model == null) { throw new ArgumentNullException(nameof(model)); }
            this._OwnerPair = ownerPair;
            this._getModel = getModel;
            this._Model = model;
            this._Builder = builder;
            this._setFrozenOwner = setFrozenOwner ?? NoOpOwner;
            this._setUnFrozen = setUnFrozen ?? NoOp;
            this._setFrozen = setFrozen ?? NoOp;
            model.AddFreezeReceiver(this);
        }

        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerNonUserCode]
        [System.Diagnostics.DebuggerStepThrough]
        private static void NoOp(TModelBuilder modelBuilder, TModel model) { }

        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerNonUserCode]
        [System.Diagnostics.DebuggerStepThrough]
        private static void NoOpOwner(TOwnerBuilder ownerBuilder, TModel model) { }

        /// <summary>
        /// Gets the model.
        /// </summary>
        public TModel Model => this._Model;

        /// <summary>
        /// Gets the builder.
        /// </summary>
        public TModelBuilder Builder => this._Builder;

        /// <summary>
        /// Gets a frozen target.
        /// </summary>
        /// <returns>A frozen target.</returns>
        public TModel GetTarget() {
            var result = this._Builder.GetTarget();
            this._setFrozenOwner(this._OwnerPair.Builder, result);
            return result;
        }

        internal void SetBuilder(TModelBuilder builder) {
            if (!ReferenceEquals(this._Builder, null)) { throw new InvalidOperationException("Builder is already set"); }
            this._Builder = builder;
        }

        internal void HandleSetUnFrozen(TModel model) {
            this._Model = model;
            this._setUnFrozen(this._Builder, model);
        }

        internal void HandleSetFrozen(TModel model) {
            this._Model = model;
            var currentModel = this._getModel(this._OwnerPair.Model);
            if (!ReferenceEquals(currentModel, model)) {
                this._setFrozen(this._Builder, model);
                this._setFrozenOwner(this._OwnerPair.Builder, model);
            }
        }

        public bool HandleFreeze(IBuildTarget frozen) {
            var model = (TModel)frozen;
            this._Model = model;
            var currentModel = this._getModel(this._OwnerPair.Model);
            if (!ReferenceEquals(currentModel, model)) {
                this._setFrozen(this._Builder, model);
                this._setFrozenOwner(this._OwnerPair.Builder, model);
            }
            return ReferenceEquals(this.Builder, null);
        }

        public bool HandleUnFreeze(IBuildTarget previous, IBuildTarget next) {
            var model = (TModel)next;
            this._Model = model;
            this._setUnFrozen(this._Builder, model);
            bool changed = !ReferenceEquals(previous, next);
            if (changed && !ReferenceEquals(model, null)) {
                model.AddFreezeReceiver(this);
            }
            return ReferenceEquals(this.Builder, null) || changed;
        }

        public void Dispose() {
            this._OwnerPair = null;
            this._Builder = default(TModelBuilder);
            this._Model = default(TModel);
            this._setFrozenOwner = NoOpOwner;
            this._setUnFrozen = NoOp;
            this._setFrozen = NoOp;
        }
    }
}
