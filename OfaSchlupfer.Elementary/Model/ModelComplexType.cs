namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;

    using System;
    using System.Collections.Generic;
    using System.Text;
    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.Entitiy;

    [JsonObject]
    public class ModelComplexType : ModelType {
        [JsonIgnore]
        private readonly FreezeableOwnedKeyedCollection<ModelComplexType, string, ModelProperty> _Properties;

        [JsonProperty(Order = 2)]
        public FreezeableOwnedKeyedCollection<ModelComplexType, string, ModelProperty> Properties => this._Properties;

        public ModelComplexType() {
            this._Properties = new FreezeableOwnedKeyedCollection<ModelComplexType, string, ModelProperty>(
                this,
                (property) => property.Name,
                ModelUtility.Instance.StringComparer,
                (owner, item) => { item.Owner = owner; });
        }

        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this._Properties.Freeze();
            }
            return result;
        }
    }

    public class ModelComplexTypeMetaEntity
        : FreezeableObject
        , IMetaEntity 
        , IMetaEntityArrayValues
        {
        private readonly ModelComplexType _ModelComplexType;

        public ModelComplexTypeMetaEntity(ModelComplexType modelComplexType) {
            this._ModelComplexType = modelComplexType;
            if (modelComplexType.IsFrozen()) { this.Freeze(); }
        }

        public IList<IMetaProperty> GetProperties() {
            throw new NotImplementedException();
        }

        public IList<IMetaIndexedProperty> GetPropertiesByIndex() {
            throw new NotImplementedException();
        }

        public IMetaProperty GetProperty(string name) {
            throw new NotImplementedException();
        }

        public IMetaIndexedProperty GetPropertyByIndex(int index) {
            throw new NotImplementedException();
        }

        public string Validate(object[] values, bool validateOrThrow) {
            throw new NotImplementedException();
        }
    }
}
