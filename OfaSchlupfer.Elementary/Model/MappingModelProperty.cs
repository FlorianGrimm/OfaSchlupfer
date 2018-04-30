namespace OfaSchlupfer.Model {
    using System;

    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;

    [JsonObject]
    public class MappingModelProperty
        : MappingObjectString<MappingModelComplexType, ModelProperty> {
        [JsonIgnore]
        private string _Conversion;

        public MappingModelProperty() {
        }

        [JsonIgnore]
        public override MappingModelComplexType Owner {
            get => this._Owner;
            set => this.SetOwnerWithChildren(ref this._Owner, value, (owner) => owner.PropertyMappings);
        }

        [JsonProperty]
        public string Conversion {
            get {
                return this._Conversion;
            }
            set {
                this.ThrowIfFrozen();
                this._Conversion = value;
            }
        }

        public override void ResolveNameSource(ModelErrors errors) => this.ResolveNameSourceHelper(this.Owner, (owner, name) => owner.Source.Properties.FindByKey(name), errors);

        public override void ResolveNameTarget(ModelErrors errors) => this.ResolveNameTargetHelper(this.Owner, (owner, name) => owner.Target.Properties.FindByKey(name), errors);
    }
}