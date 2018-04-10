namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using OfaSchlupfer.Freezable;

    [JsonObject]
    public class MappingConstraint
        : MappingObjectString<ModelConstraint> {
        public MappingConstraint() { }

        public override void ResolveNameSource() {
            base.ResolveNameSource();
        }

        public override void ResolveNameTarget() {
            base.ResolveNameTarget();
        }

        internal void UpdateNames(ModelRoot.Current current, ModelSchema.Current sourceCurrent, ModelSchema.Current targetCurrent) {
            throw new NotImplementedException();
        }

        internal void ResolveNames(ModelRoot.Current current, ModelSchema.Current sourceCurrent, ModelSchema.Current targetCurrent) {
            throw new NotImplementedException();
        }
    }
}