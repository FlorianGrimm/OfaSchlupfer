using System;

namespace OfaSchlupfer.Model {
    public class MappingModelIndexColumn
        : MappingObjectString<MappingModelIndex, ModelIndexProperty> {
        public MappingModelIndexColumn() {
        }

        public override void ResolveNameSource(ModelErrors errors) => this.ResolveNameSourceHelper(this.Owner, (owner, name) => owner.Source.Properties.FindByKey(name), errors);

        public override void ResolveNameTarget(ModelErrors errors) => this.ResolveNameTargetHelper(this.Owner, (owner, name) => owner.Target.Properties.FindByKey(name), errors);
    }
}