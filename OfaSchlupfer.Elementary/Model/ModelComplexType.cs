namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;

    using System;
    using System.Collections.Generic;
    using System.Text;
    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.Entity;
    using System.Linq;

    [JsonObject]
    public class ModelComplexType : ModelType {
        [JsonIgnore]
        private readonly FreezeableOwnedKeyedCollection<ModelComplexType, string, ModelProperty> _Properties;
        private ModelComplexTypeMetaEntity _GetMetaEntity;

        [JsonProperty(Order = 2)]
        public FreezeableOwnedKeyedCollection<ModelComplexType, string, ModelProperty> Properties => this._Properties;

        public ModelComplexType() {
            this._Properties = new FreezeableOwnedKeyedCollection<ModelComplexType, string, ModelProperty>(
                this,
                (property) => property.Name,
                ModelUtility.Instance.StringComparer,
                (owner, item) => { item.Owner = owner; });
        }

        [JsonIgnore]
        public override ModelSchema Owner {
            get => this._Owner;
            set => this.SetOwner(ref _Owner, value, (owner) => owner.ComplexTypes);
        }

        public IMetaEntityFlexible GetMetaEntity() {
            var result = this._GetMetaEntity;
            if ((object)result == null) {
                result = new ModelComplexTypeMetaEntity(this);
                if (this.IsFrozen()) {
                    this._GetMetaEntity = result;
                }
            }
            return result;
        }

        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this._Properties.Freeze();
            }
            return result;
        }

        public override Type GetClrType() => typeof(OfaSchlupfer.Entity.AccessorFlexible);
    }

    [JsonObject]
    public class ModelComplexTypeMetaEntity
        : FreezeableObject
        , IMetaEntity
        , IMetaEntityFlexible {
        [JsonIgnore]
        private readonly ModelComplexType _ModelComplexType;
        [JsonIgnore]
        private FreezeableCollection<IMetaIndexedProperty> _PropertyByIndex;
        [JsonIgnore]
        private FreezeableDictionary<string, IMetaIndexedProperty> _PropertyByName;

        // cache
        private FreezedList<IMetaProperty> _GetProperties;
        private FreezedList<IMetaIndexedProperty> _GetPropertiesByIndex;

        public ModelComplexTypeMetaEntity(ModelComplexType modelComplexType) {
            this.EntityTypeName = modelComplexType.ExternalName ?? modelComplexType.Name;
            this._ModelComplexType = modelComplexType;
            this._PropertyByIndex = new FreezeableCollection<IMetaIndexedProperty>();
            this._PropertyByName = new FreezeableDictionary<string, IMetaIndexedProperty>();
            int index = 0;
            foreach (var property in modelComplexType.Properties) {
                var metaProperty = property.GetMetaProperty(index);
                this.AddProperty(metaProperty);
                index++;
            }
            if (modelComplexType.IsFrozen()) { this.Freeze(); }
        }


        /// <summary>
        /// Gets or sets the typename.
        /// </summary>
        [JsonProperty]
        public string EntityTypeName { get; set; }

        public ModelComplexType ModelComplexType => this._ModelComplexType;

        /// <summary>
        /// Add a MetaProperty
        /// </summary>
        /// <param name="metaProperty">the property to add.</param>
        public void AddProperty(IMetaIndexedProperty metaProperty) {
            if (metaProperty == null) { throw new ArgumentNullException(nameof(metaProperty)); }
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
        /// Get all properties.
        /// </summary>
        /// <returns>a list of properties.</returns>
        public IList<IMetaProperty> GetProperties() {
            var result = this._GetProperties;
            if ((object)result == null) {
                result = this._PropertyByIndex.Cast<IMetaProperty>().AsFreezedList();
                // if it is frozen it is save to cache.
                if (this.IsFrozen()) {

                    this._GetProperties = result;
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the properties sorted by index.
        /// </summary>
        public IList<IMetaIndexedProperty> GetPropertiesByIndex() {
            var result = this._GetPropertiesByIndex;
            if ((object)result == null) {
                result = this._PropertyByIndex.AsFreezedList();
                // if it is frozen it is save to cache.
                if (this.IsFrozen()) {
                    this._GetPropertiesByIndex = result;
                }
            }
            return result;
        }

        /// <summary>
        /// Get the named property
        /// </summary>
        /// <param name="name">the name of the property</param>
        /// <returns>the property or null</returns>
        public IMetaProperty GetProperty(string name) {
            if (name == null) { throw new ArgumentNullException(nameof(name)); }
            IMetaIndexedProperty result = null;
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

        public string Validate(IMetaProperty metaProperty, object value, bool validateOrThrow) => metaProperty.Validate(value, validateOrThrow);

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
    }
}
