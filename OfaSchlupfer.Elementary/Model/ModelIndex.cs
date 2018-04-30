namespace OfaSchlupfer.Model {
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    using Newtonsoft.Json;

    using OfaSchlupfer.Entity;
    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.Model;

    [JsonObject]
    public class ModelIndex 
        : ModelNamedOwnedElement<ModelComplexType> {
        [JsonIgnore]
        private readonly FreezableOwnedKeyedCollection<ModelIndex, string, ModelIndexProperty> _Properties;

        [JsonIgnore]
        private bool _IsPrimaryKey;

        public ModelIndex() {
            this._Properties = new FreezableOwnedKeyedCollection<ModelIndex, string, ModelIndexProperty>(
                this,
                (key) => key.Name,
                ModelUtility.Instance.StringComparer,
                (owner, item) => { item.Owner = owner; });
        }

        [JsonProperty(Order = 3)]
        public IFreezableOwnedKeyedCollection<string, ModelIndexProperty> Properties => this._Properties;

        [JsonProperty]
        public bool IsPrimaryKey { get => this._IsPrimaryKey; set => this.SetValueProperty(ref this._IsPrimaryKey, value); }
    }
}