namespace OfaSchlupfer.Freezable {
    using System;
    using System.Runtime.CompilerServices;
    using Newtonsoft.Json;

    /// <summary>
    /// base implementation for <see cref="IFreezable"/>
    /// </summary>
    public class FreezableObject : IFreezable {
        [JsonIgnore]
        private int _IsFrozen;

        [System.Diagnostics.DebuggerStepThrough]
        public FreezableObject() { }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public virtual bool Freeze() {
            return (System.Threading.Interlocked.CompareExchange(ref this._IsFrozen, 1, 0) == 0);
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public bool IsFrozen() => (this._IsFrozen == 1);

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        protected bool SetRefProperty<TProperty>(ref TProperty thisProperty, TProperty value)
            where TProperty : class {
            if (ReferenceEquals(thisProperty, value)) { return false; }
            this.ThrowIfFrozen();
            thisProperty = value;
            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        protected bool SetValueProperty<TProperty>(ref TProperty thisProperty, TProperty value)
            where TProperty : struct {
            this.ThrowIfFrozen();
            thisProperty = value;
            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        protected bool SetValueProperty<TProperty>(ref Nullable<TProperty> thisProperty, Nullable<TProperty> value)
            where TProperty : struct {
            this.ThrowIfFrozen();
            thisProperty = value;
            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        protected bool SetStringProperty(ref string thisProperty, string value) {
            if (value == string.Empty) { value = null; }
            if (ReferenceEquals(thisProperty, value)) { return false; }
            if (string.Equals(thisProperty, value, System.StringComparison.Ordinal)) { return false; }
            this.ThrowIfFrozen();
            thisProperty = value;
            return true;
        }

        /// <summary>
        /// sets this.Property = value. -relaxed ThrowIfFrozen if not set before
        /// </summary>
        /// <typeparam name="TOwner">this</typeparam>
        /// <param name="thisPropertyOwner">this._Property</param>
        /// <param name="value">value</param>
        /// <returns>changed</returns>
        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        protected bool SetOwner<TOwner>(ref TOwner thisPropertyOwner, TOwner value)
            where TOwner : class {
            if (ReferenceEquals(thisPropertyOwner, value)) { return false; }
            if (!(thisPropertyOwner is null)) { this.ThrowIfFrozen(); }
            thisPropertyOwner = value;
            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        protected bool SetRefPropertyOnce<TProperty>(ref TProperty thisProperty, TProperty value, [CallerMemberName]string callerMemberName = null)
            where TProperty : class {
            if (ReferenceEquals(thisProperty, value)) { return false; }
            if (!(thisProperty is null)) { throw new System.ArgumentException($"{callerMemberName} is already set."); }
            thisProperty = value;
            return true;
        }
      
        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        protected TProperty CreateOrGetCacheObject<TProperty, TArg0>(ref TProperty thisProperty, TArg0 arg0, Func<TArg0, TProperty> generator)
            where TProperty : class {
            var result = thisProperty;
            if (result is null) {
                result = generator(arg0);
                if (this._IsFrozen == 1) {
                    thisProperty = result;
                }
            }
            return result;
        }
    }

    public interface IObjectWithOwner<TOwner>
        where TOwner : class {
        TOwner Owner { get; set; }
    }
}
