namespace OfaSchlupfer.Entitiy {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using OfaSchlupfer.Freezable;

    /// <summary>
    /// MetaData for EntityArrayProp
    /// </summary>
    public class MetaEntityArrayValues
        : FreezeableObject
        , IMetaEntity
        , IMetaEntityArrayValues {
        private FreezeableCollection<MetaPropertyArrayValues> _PropertyByIndex;
        private FreezeableDictionary<string, MetaPropertyArrayValues> _PropertyByName;

        // cache
        private FreezedList<IMetaProperty> _GetProperties;
        private FreezedList<IMetaIndexedProperty> _GetPropertiesByIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="MetaEntityArrayValues"/> class.
        /// </summary>
        public MetaEntityArrayValues() {
            this._PropertyByIndex = new FreezeableCollection<MetaPropertyArrayValues>();
            this._PropertyByName = new FreezeableDictionary<string, MetaPropertyArrayValues>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetaEntityArrayValues"/> class.
        /// </summary>
        /// <param name="names">names of properties.</param>
        public MetaEntityArrayValues(IEnumerable<string> names)
            : this() {
            if (names != null) {
                int idx = 0;
                foreach (var name in names) {
                    this.AddProperty(new MetaPropertyArrayValues(idx, name, null));
                    idx++;
                }
            }
        }

        public MetaEntityArrayValues(IEnumerable<IMetaProperty> properties) {
            if (properties != null) {
                int idx = 0;
                foreach (var property in properties) {
                    this.AddProperty(new MetaPropertyArrayValues(idx, property));
                    idx++;
                }
            }
        }

        /// <summary>
        /// Gets the property by index.
        /// </summary>
        public IList<MetaPropertyArrayValues> PropertyByIndex { get { return this._PropertyByIndex; } }

        /// <summary>
        /// Gets the property by name.
        /// </summary>
        public IDictionary<string, MetaPropertyArrayValues> PropertyByName { get { return this._PropertyByName; } }

        /// <summary>
        /// Add a MetaProperty
        /// </summary>
        /// <param name="metaProperty">the property to add.</param>
        public void AddProperty(MetaPropertyArrayValues metaProperty) {
            if (metaProperty == null) { throw new ArgumentNullException(nameof(metaProperty)); }

            // check if property exists
            if (this._PropertyByName.ContainsKey(metaProperty.Name)) {
                throw new ArgumentException("Property already exists.");
            }

            // and add
            if (metaProperty.Index < 0) {
                metaProperty.Index = this._PropertyByIndex.Count;
                this._PropertyByIndex.Add(metaProperty);
                this._PropertyByName.Add(metaProperty.Name, metaProperty);
            } else if (this._PropertyByIndex.Count == metaProperty.Index) {
                this._PropertyByIndex.Add(metaProperty);
                this._PropertyByName.Add(metaProperty.Name, metaProperty);
            } else {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Get the named property
        /// </summary>
        /// <param name="name">the name of the property</param>
        /// <returns>the property or null</returns>
        public IMetaProperty GetProperty(string name) {
            if (name == null) { throw new ArgumentNullException(nameof(name)); }
            MetaPropertyArrayValues result = null;
            if (this._PropertyByName.TryGetValue(name, out result)) {
                return result;
            } else {
                return null;
            }
        }

        /// <summary>
        /// Gets the property by index.
        /// </summary>
        public IMetaIndexedProperty GetPropertyByIndex(int index) => this._PropertyByIndex[index];

        /// <summary>
        /// Gets the properties sorted by index.
        /// </summary>
        public IList<IMetaIndexedProperty> GetPropertiesByIndex() {
            var result = this._GetPropertiesByIndex;
            if ((object)result == null) {
                result = this.PropertyByIndex.Cast<IMetaIndexedProperty>().AsFreezedList();
                // if it is frozen it is save to cache.
                if (this.IsFrozen()) {
                    this._GetPropertiesByIndex = result;
                }
            }
            return result;
        }

        /// <summary>
        /// Get all properties.
        /// </summary>
        /// <returns>a list of properties.</returns>
        public IList<IMetaProperty> GetProperties() {
            var result = this._GetProperties;
            if ((object)result == null) {
                result = this.PropertyByName.Values.Cast<IMetaProperty>().AsFreezedList();
                // if it is frozen it is save to cache.
                if (this.IsFrozen()) {

                    this._GetProperties = result;
                }
            }
            return result;
        }

        public string Validate(object[] values, bool validateOrThrow) {
            var cnt = this._PropertyByIndex.Count;
            var len = values.Length;
            if (cnt != len) {
                var msg = $"Values length {len} is not equal to Metadatas length {cnt}.";
                if (validateOrThrow) {
                    return msg;
                } else {
                    throw new InvalidOperationException(msg);
                }
            }
            for (int idx = 0; idx < cnt; idx++) {
                var subResult = this._PropertyByIndex[idx].Validate(values[idx], validateOrThrow);
                if (validateOrThrow && (object)subResult != null) { return subResult; }
            }
            return null;
        }
        /*
        public IMetaProperty<TData> GetPropertyT<TData>(string name) {
            throw new NotImplementedException();
        }
        */
        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this._PropertyByIndex.Freeze();
                this._PropertyByName.Freeze();
            }
            return result;
        }
    }
}
