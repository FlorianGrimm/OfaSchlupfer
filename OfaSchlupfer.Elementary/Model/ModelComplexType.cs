namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;

    using System;
    using System.Collections.Generic;
    using System.Text;
    using OfaSchlupfer.Freezable;

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
}
