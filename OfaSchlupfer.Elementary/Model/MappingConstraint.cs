namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using OfaSchlupfer.Freezable;

    [JsonObject]
    public class MappingConstraint
        : MappingObject<string, ModelEntityName, ModelConstraint> {
        [JsonIgnore]
        private MappingEntity _Owner;

        public MappingConstraint() { }

        [JsonIgnore]
        public MappingEntity Owner {
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
        protected override bool AreSourceNamesEqual(ModelEntityName sourceName, ref ModelEntityName value) => MappingObjectHelper.AreNamesEqual(sourceName, ref value);
        protected override bool AreTargetNamesEqual(ModelEntityName targetName, ref ModelEntityName value) => MappingObjectHelper.AreNamesEqual(targetName, ref value);
        protected override bool AreThisNamesEqual(string thisName, ref string value) => MappingObjectHelper.AreNamesEqual(thisName, ref value);

        public override void ResolveNameSource(ModelErrors errors) {
            if (((object)this._Owner != null) && ((object)this._Source == null) && ((object)this._SourceName != null)) {
            }
        }
        public override void ResolveNameTarget(ModelErrors errors) {
            if (((object)this._Owner != null) && ((object)this._Target == null) && ((object)this._TargetName != null)) {
#warning TODO ResolveNameTarget
                //this._Owner.Source.f
            }
        }

    }
}