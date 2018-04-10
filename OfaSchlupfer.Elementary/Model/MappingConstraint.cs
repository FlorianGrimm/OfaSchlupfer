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
        [JsonIgnore]
        private MappingEntity _Owner;

        public MappingConstraint() { }

        [JsonIgnore]
        public MappingEntity Owner {
            get {
                return this._Owner;
            }
            set {
                this.ThrowIfFrozen();
                this._Owner = value;
            }
        }
        protected override bool AreSourceNamesEqual(string sourceName, ref string value) => MappingObjectHelper.AreNamesEqual(sourceName, ref value);
        protected override bool AreTargetNamesEqual(string targetName, ref string value) => MappingObjectHelper.AreNamesEqual(targetName, ref value);
        protected override bool AreThisNamesEqual(string thisName, ref string value) => MappingObjectHelper.AreNamesEqual(thisName, ref value);
        
        public override void ResolveNameSource() {
            if (((object)this._Source == null) && ((object)this._SourceName != null)) {
#warning TODO ResolveNameSource
            }
        }

        public override void ResolveNameTarget() {
            if (((object)this._Target == null) && ((object)this._TargetName != null)) {
#warning TODO ResolveNameTarget
            }
        }

        internal void UpdateNames(ModelRoot.Current current, ModelSchema.Current sourceCurrent, ModelSchema.Current targetCurrent) {
            throw new NotImplementedException();
        }

        internal void ResolveNames(ModelRoot.Current current, ModelSchema.Current sourceCurrent, ModelSchema.Current targetCurrent) {
            throw new NotImplementedException();
        }
    }
}