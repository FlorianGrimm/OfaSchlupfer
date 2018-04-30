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
        private readonly FreezableOwned2KeyedCollection<ModelComplexType, string, string, ModelIndex> _Indexes;

        [JsonIgnore]
        private readonly FreezableOwned2KeyedCollection<ModelComplexType, string, string, ModelProperty> _Properties;

        [JsonIgnore]
        private readonly FreezableOwned2KeyedCollection<ModelComplexType, string, string, ModelNavigationProperty> _NavigationProperty;

        [JsonIgnore]
        private ModelComplexTypeMetaEntity _GetMetaEntity;

        [JsonProperty(Order = 3)]
        public FreezableOwned2KeyedCollection<ModelComplexType, string, string, ModelIndex> Indexes => this._Indexes;

        [JsonProperty(Order = 4)]
        public FreezableOwned2KeyedCollection<ModelComplexType, string, string, ModelProperty> Properties => this._Properties;

        [JsonProperty(Order = 5)]
        public FreezableOwned2KeyedCollection<ModelComplexType, string, string, ModelNavigationProperty> NavigationProperty => this._NavigationProperty;

        public ModelComplexType() {
            this._Indexes = new FreezableOwned2KeyedCollection<ModelComplexType, string, string, ModelIndex>(
                this,
                GetName,
                ModelUtility.Instance.StringComparer,
                GetExternalNameOrName,
                ModelUtility.Instance.StringComparer,
                (owner, item) => { item.Owner = owner; });
            this._Properties = new FreezableOwned2KeyedCollection<ModelComplexType, string, string, ModelProperty>(
                this,
                GetName,
                ModelUtility.Instance.StringComparer,
                GetExternalNameOrName,
                ModelUtility.Instance.StringComparer,
                (owner, item) => { item.Owner = owner; });
            this._NavigationProperty = new FreezableOwned2KeyedCollection<ModelComplexType, string, string, ModelNavigationProperty>(
                this,
                GetName,
                ModelUtility.Instance.StringComparer,
                GetExternalNameOrName,
                ModelUtility.Instance.StringComparer,
                (owner, item) => { item.Owner = owner; });
        }

        [JsonIgnore]
        public override ModelSchema Owner {
            get => this._Owner;
            set => this.SetOwnerWithChildren(ref this._Owner, value, (owner) => owner.ComplexTypes);
        }

        public IMetaEntityFlexible GetMetaEntity()
            => this.CreateOrGetCacheObject(ref this._GetMetaEntity, this, (that) => new ModelComplexTypeMetaEntity(this));
#warning weichei
        //    {
        //    var result = this._GetMetaEntity;
        //    if (result is null) {
        //        result = new ModelComplexTypeMetaEntity(this);
        //        if (this.IsFrozen()) {
        //            this._GetMetaEntity = result;
        //        }
        //    }
        //    return result;
        //}

        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this._Properties.Freeze();
            }
            return result;
        }

        public override Type GetClrType() => typeof(OfaSchlupfer.Entity.AccessorFlexible);

        public ModelProperty CreateProperty(
                string name,
                string externalName
            ) {
            var result = new ModelProperty {
                Name = name,
                ExternalName = externalName ?? name
            };
            this.Properties.Add(result);
            return result;
        }

        public ModelNavigationProperty CreateNavigationProperty(
                string name,
                string externalName,
                ModelComplexType toComplexType,
                bool isOptional,
                bool isCollection
            ) {
            var result = new ModelNavigationProperty {
                Name = name,
                ExternalName = externalName ?? name,
                IsCollection = isCollection,
                IsOptional = isOptional,
                ItemType = toComplexType
            };
            this.NavigationProperty.Add(result);
            return result;
        }

        public ModelIndex CreateIndex(
                string name,
                string externalName
            ) {
            var result = new ModelIndex {
                Name = name,
                ExternalName = externalName ?? name
            };
            this.Indexes.Add(result);
            return result;
        }
    }

    [JsonObject]
    public class ModelComplexTypeMetaEntity
        : FreezableObject
        , IMetaEntity
        , IMetaEntityFlexible {
        [JsonIgnore]
        private readonly ModelComplexType _ModelComplexType;

        [JsonIgnore]
        private FreezableCollection<IMetaIndexedProperty> _PropertyByIndex;

        [JsonIgnore]
        private readonly FreezableDictionary<string, IMetaIndexedProperty> _PropertyByName;

        // cache
        private FreezedList<IMetaProperty> _GetProperties;
        private FreezedList<IMetaIndexedProperty> _GetPropertiesByIndex;

        public ModelComplexTypeMetaEntity(ModelComplexType modelComplexType) {
            this.EntityTypeName = modelComplexType.ExternalName ?? modelComplexType.Name;
            this._ModelComplexType = modelComplexType;
            this._PropertyByIndex = new FreezableCollection<IMetaIndexedProperty>();
            this._PropertyByName = new FreezableDictionary<string, IMetaIndexedProperty>();
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
        /// Get all properties.
        /// </summary>
        /// <returns>a list of properties.</returns>
        public IList<IMetaProperty> GetProperties()
            => this.CreateOrGetCacheObject(ref this._GetProperties, this, (that) => that._PropertyByIndex.Cast<IMetaProperty>().AsFreezedList());
#warning weichei test first
        //{
        //    var result = this._GetProperties;
        //    if (result is null) {
        //        result = this._PropertyByIndex.Cast<IMetaProperty>().AsFreezedList();
        //        // if it is frozen it is save to cache.
        //        if (this.IsFrozen()) {
        //            this._GetProperties = result;
        //        }
        //    }
        //    return result;
        //}

        /// <summary>
        /// Gets the properties sorted by index.
        /// </summary>
        public IList<IMetaIndexedProperty> GetPropertiesByIndex()
            => this.CreateOrGetCacheObject(ref this._GetPropertiesByIndex, this, (that) => that._PropertyByIndex.AsFreezedList());
#warning weichei test first
        //    {
        //    var result = this._GetPropertiesByIndex;
        //    if (result is null) {
        //        result = this._PropertyByIndex.AsFreezedList();
        //        // if it is frozen it is save to cache.
        //        if (this.IsFrozen()) {
        //            this._GetPropertiesByIndex = result;
        //        }
        //    }
        //    return result;
        //}

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

        public override bool Freeze() {
            // ?? dep on this._ModelComplexType ??
            if (this._ModelComplexType.IsFrozen()) {
                var result = base.Freeze();
                if (result) {
                    this._PropertyByIndex.Freeze();
                    this._PropertyByName.Freeze();
                }
                return result;
            }
            return false;
        }
    }
}
