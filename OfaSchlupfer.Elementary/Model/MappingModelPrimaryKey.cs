namespace OfaSchlupfer.Model {
    using System;

    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;

    [JsonObject]
    public class MappingModelPrimaryKey
        : MappingObjectString<MappingModelComplexType, ModelPrimaryKey> {

        public MappingModelPrimaryKey() {
        }

        public override void ResolveNameSource(ModelErrors errors) => this.ResolveNameSourceHelper(this.Owner, (owner, name) => owner.Source.Keys.FindByKey(name), errors);

        public override void ResolveNameTarget(ModelErrors errors) => this.ResolveNameTargetHelper(this.Owner, (owner, name) => owner.Target.Keys.FindByKey(name), errors);
    }
}