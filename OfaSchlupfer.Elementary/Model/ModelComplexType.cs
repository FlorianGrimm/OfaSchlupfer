namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;

    using System;
    using System.Collections.Generic;
    using System.Text;
    using OfaSchlupfer.Freezable;

    [JsonObject]
    public class ModelComplexType : ModelType {
        [JsonIgnore]
        private ModelSchema _Owner;

        [JsonIgnore]
        private readonly FreezeableOwnedCollection<ModelComplexType, ModelProperty> _Properties;

        [JsonProperty(Order = 2)]
        public IList<ModelProperty> Properties => this._Properties;

        public ModelComplexType() {
            this._Properties = new FreezeableOwnedCollection<ModelComplexType, ModelProperty>(this, (owner, item) => { item.Owner = owner; });
        }

        [JsonIgnore]
        public ModelSchema Owner {
            get {
                return this._Owner;
            }
            internal set {
                if (ReferenceEquals(this._Owner, value)) { return; }
                if ((object)this._Owner == null) { this._Owner = value; return; }
                this.ThrowIfFrozen();
                this._Owner = value;
            }
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
