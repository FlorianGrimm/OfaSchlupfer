namespace OfaSchlupfer.Entity {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;

    /// <summary>
    /// MetaData for EntityArrayProp
    /// </summary>
    [JsonObject]
    public class MetaEntityFlexible
        : FreezeableObject
        , IMetaEntity
        , IMetaEntityFlexible {
        [JsonIgnore]
        private FreezeableCollection<IMetaIndexedProperty> _PropertyByIndex;
        [JsonIgnore]
        private FreezeableDictionary<string, IMetaIndexedProperty> _PropertyByName;

        // cache
        [JsonIgnore]
        private FreezedList<IMetaProperty> _GetProperties;
        [JsonIgnore]
        private FreezedList<IMetaIndexedProperty> _GetPropertiesByIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="MetaEntityFlexible"/> class.
        /// </summary>
        public MetaEntityFlexible() {
            this._PropertyByIndex = new FreezeableCollection<IMetaIndexedProperty>();
            this._PropertyByName = new FreezeableDictionary<string, IMetaIndexedProperty>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetaEntityFlexible"/> class.
        /// </summary>
        /// <param name="names">names of properties.</param>
        public MetaEntityFlexible(string entityTypeName, IEnumerable<string> names)
            : this() {
            this.EntityTypeName = entityTypeName;
            if (names != null) {
                int idx = 0;
                foreach (var name in names) {
                    this.AddProperty(new MetaPropertyFlexible(idx, name, null));
                    idx++;
                }
            }
        }

        public MetaEntityFlexible(string entityTypeName, IEnumerable<IMetaProperty> properties) {
            this.EntityTypeName = entityTypeName;
            if (properties != null) {
                int idx = 0;
                foreach (var property in properties) {
                    this.AddProperty(new MetaPropertyFlexibleChained(idx, property));
                    idx++;
                }
            }
        }

        /// <summary>
        /// Gets or sets the typename.
        /// </summary>
        [JsonProperty]
        public string EntityTypeName { get; set; }

        /// <summary>
        /// Gets the property by index.
        /// </summary>
        [JsonIgnore]
        public IList<IMetaIndexedProperty> PropertyByIndex { get { return this._PropertyByIndex; } }

        /// <summary>
        /// Gets the property by name.
        /// </summary>
        [JsonIgnore]
        public IDictionary<string, IMetaIndexedProperty> PropertyByName { get { return this._PropertyByName; } }

        /// <summary>
        /// Add a MetaProperty
        /// </summary>
        /// <param name="metaProperty">the property to add.</param>
        public void AddProperty(IMetaIndexedProperty metaProperty) {
            if (metaProperty is null) { throw new ArgumentNullException(nameof(metaProperty)); }
            this.ThrowIfFrozen();

            // check if property exists
            if (this._PropertyByName.ContainsKey(metaProperty.Name)) {
                throw new ArgumentException("Property already exists.");
            }

            // and add
            metaProperty.MetaEntity = this;
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
            if (name is null) { throw new ArgumentNullException(nameof(name)); }
            if (this._PropertyByName.TryGetValue(name, out var result)) {
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
            if (result is null) {
                result = this.PropertyByIndex.AsFreezedList();
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
            if (result is null) {
                result = this.PropertyByIndex.Cast<IMetaProperty>().AsFreezedList();
                // if it is frozen it is save to cache.
                if (this.IsFrozen()) {

                    this._GetProperties = result;
                }
            }
            return result;
        }

        public string Validate(IMetaProperty metaProperty, object value, bool validateOrThrow) {
            return metaProperty.Validate(value, validateOrThrow);
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

        [JsonProperty]
        public IEnumerable<IMetaIndexedProperty> Properties {
            get {
                return this.GetPropertiesByIndex();
            }
            set {
                this.ThrowIfFrozen();
                if (!(value is null)) {
                    foreach (var property in value) {
                        this.AddProperty(property);
                    }
                }
            }
        }
    }
}
