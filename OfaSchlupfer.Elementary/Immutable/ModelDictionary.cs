namespace OfaSchlupfer.Elementary.Immutable {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// a immutable Dicationary.
    /// </summary>
    /// <typeparam name="TKey">the key type</typeparam>
    /// <typeparam name="TValue">the value type.</typeparam>
    public class ModelDictionary<TKey, TValue> : BuildTargetBase {
        /// <summary>
        /// Helper for Copy Constructor.
        /// </summary>
        /// <param name="schemas">the copy ctor parameter</param>
        /// <param name="srcSchemas">the source field.</param>
        /// <returns>schemas if frozen - otherwise a new <see cref="ModelDictionary{TKey, TValue}"/> with the data from schemas or srcSchemas.</returns>
        public static ModelDictionary<TKey, TValue> FactoryCopy(ModelDictionary<TKey, TValue> schemas, ModelDictionary<TKey, TValue> srcSchemas) {
            return (((object)schemas != null) && schemas.IsFrozen) ? schemas : new ModelDictionary<TKey, TValue>(schemas ?? srcSchemas);
        }

        /// <summary>
        /// Helper for Copy Constructor.
        /// </summary>
        /// <param name="schemas">the copy ctor parameter</param>
        /// <param name="srcSchemas">the source field.</param>
        /// <returns>a new <see cref="ModelDictionary{TKey, TValue}"/> with the data from schemas or srcSchemas.</returns>
        public static ModelDictionary<TKey, TValue> FactoryCopyUnFrozen(ModelDictionary<TKey, TValue> schemas, ModelDictionary<TKey, TValue> srcSchemas) {
            return new ModelDictionary<TKey, TValue>(schemas ?? srcSchemas);
        }

        private static byte _FreezeChildren;

        /// <summary>
        /// the items
        /// </summary>
        protected readonly Dictionary<TKey, TValue> _ByName;

        private TValue[] _Cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelDictionary{TKey, TValue}"/> class.
        /// </summary>
        public ModelDictionary() {
            this._ByName = new Dictionary<TKey, TValue>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelDictionary{TKey, TValue}"/> class. Copy constructor.
        /// </summary>
        /// <param name="src">the source - cannot be null.</param>
        public ModelDictionary(ModelDictionary<TKey, TValue> src) {
            if ((object)src == null) { throw new ArgumentNullException(nameof(src)); }

            this._ByName = new Dictionary<TKey, TValue>(src._ByName);
        }

        /// <summary>
        /// Get the builder for mutate.
        /// </summary>
        /// <param name="clone">always clone.</param>
        /// <param name="setUnFrozen">will be called if target is set to another instance - unfrozen.</param>
        /// <param name="setFrozen">will be called if target is set to another instance - frozen.</param>
        /// <returns>a builder</returns>
        public ModelDictionaryBuilder<ModelDictionary<TKey, TValue>> GetBuilder(bool clone, Action<ModelDictionary<TKey, TValue>> setUnFrozen, Action<ModelDictionary<TKey, TValue>> setFrozen)
            => new ModelDictionaryBuilder<ModelDictionary<TKey, TValue>>(this, clone, setUnFrozen, setFrozen);

        /// <summary>
        /// Gets a all key as an array.
        /// </summary>
        /// <returns>All items as an array.</returns>
        public TKey[] GetKeys() => this._ByName.Keys.ToArray();

        /// <summary>
        /// Gets a all items as an array.
        /// </summary>
        /// <returns>All items as an array.</returns>
        public TValue[] GetValues() {
            if (this.IsFrozen) {
                return this._Cache ?? (this._Cache = this._ByName.Values.ToArray());
            } else {
                return this._ByName.Values.ToArray();
            }
        }

        /// <summary>
        /// Gets a all items as an array.
        /// </summary>
        /// <returns>All items as an array.</returns>
        public KeyValuePair<TKey, TValue>[] GetKeyValues() => this._ByName.ToArray();

        /// <summary>
        /// Gets the schema by its's name
        /// </summary>
        /// <param name="name">the schema name to search for</param>
        /// <returns>the found schema or null.</returns>
        public TValue GetByName(TKey name) {
            TValue result;
            this._ByName.TryGetValue(name, out result);
            return result;
        }

        protected override void FreezeChildren() {
            base.FreezeChildren();

            // 0 means undetermined - so calc
            if (_FreezeChildren == 0) {
                if (typeof(IBuildTarget).IsAssignableFrom(typeof(TValue))) {
                    // 1 means yes
                    _FreezeChildren = 1;
                } else {
                    // 2 means no
                    _FreezeChildren = 2;
                }
            }
            if (_FreezeChildren == 1) {
                foreach (var item in this._ByName.Values.ToList()) {
                    ((IBuildTarget)item)?.Freeze();
                }
            }
        }

        /// <summary>
        /// Create a unfrozen instance
        /// </summary>
        /// <returns>a new instacne</returns>
        protected override IBuildTarget UnFreezeCreateInstance() {
            return new ModelDictionary<TKey, TValue>(this);
        }

        /// <summary>
        /// Builder for <see cref="ModelDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <typeparam name="TModel">the Model type</typeparam>
        public class ModelDictionaryBuilder<TModel>
            : BuilderBase<TModel>
            where TModel : ModelDictionary<TKey, TValue> {
            internal ModelDictionaryBuilder(TModel target, bool clone, Action<TModel> setUnFrozen, Action<TModel> setFrozen)
                : base(target, clone, setUnFrozen, setFrozen) {
            }

            /// <summary>
            /// Dangerzone
            /// </summary>
            /// <returns>only if you need!!</returns>
            public Dictionary<TKey, TValue> GetByName() => this._Target._ByName;

            /// <summary>
            /// Add the value
            /// </summary>
            /// <param name="value">the value to add - cannot be null.</param>
            /// <param name="getKey">a function - cannot be null</param>
            /// <returns>the old value.</returns>
            public TValue Add(TValue value, Func<TValue, TKey> getKey) {
                if ((object)value == null) { throw new ArgumentNullException(nameof(value)); }
                if ((object)getKey == null) { throw new ArgumentNullException(nameof(getKey)); }
                var schemaByName = this.EnsureUnfrozen()._ByName;
                TValue result;
                TKey key = getKey(value);
                schemaByName.TryGetValue(key, out result);
                schemaByName[key] = value;
                return result;
            }

            /// <summary>
            /// Add the value.
            /// </summary>
            /// <param name="key">the key - cannot be null.</param>
            /// <param name="value">the value - cannot be null.</param>
            /// <returns>the old value.</returns>
            public TValue Add(TKey key, TValue value) {
                if ((object)key == null) { throw new ArgumentNullException(nameof(key)); }
                if ((object)value == null) { throw new ArgumentNullException(nameof(value)); }
                var byName = this.EnsureUnfrozen()._ByName;
                TValue result;
                byName.TryGetValue(key, out result);
                byName[key] = value;
                return result;
            }

            /// <summary>
            /// Gets the schema by its's name
            /// </summary>
            /// <param name="name">the schema name to search for</param>
            /// <returns>the found schema or null.</returns>
            public TValue GetByName(TKey name) => this._Target.GetByName(name);

            /// <summary>
            /// Gets a all items as an array.
            /// </summary>
            /// <returns>All items as an array.</returns>
            public TValue[] GetValues() => this._Target._ByName.Values.ToArray();

            /// <summary>
            /// Gets a all key as an array.
            /// </summary>
            /// <returns>All items as an array.</returns>
            public TKey[] GetKeys() => this._Target._ByName.Keys.ToArray();

            /// <summary>
            /// Gets a all items as an array.
            /// </summary>
            /// <returns>All items as an array.</returns>
            public KeyValuePair<TKey, TValue>[] GetKeyValues() => this._Target._ByName.ToArray();
        }
    }
}
