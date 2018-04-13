namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;
    using OfaSchlupfer.Freezable;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [JsonObject]
    public class MappingRelation
        : MappingObject<ModelEntityName, ModelEntityName, ModelRelation>
        , IMappingNamedObject<ModelEntityName> {
        [JsonIgnore]
        private MappingSchema _Owner;

        [JsonIgnore]
        private bool _Enabled;

        public MappingRelation() {
        }

        [JsonProperty]
        public bool Enabled {
            get {
                return this._Enabled;
            }
            set {
                this.ThrowIfFrozen();
                this._Enabled = value;
            }
        }

        [JsonIgnore]
        public MappingSchema Owner {
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

        protected override bool AreThisNamesEqual(ModelEntityName thisName, ref ModelEntityName value) => MappingObjectHelper.AreNamesEqual(thisName, ref value);


        public void ResolveName(ModelErrors errors) {
            this.ResolveNameSource(errors);
            this.ResolveNameTarget(errors);
        }

        public override void ResolveNameSource(ModelErrors errors) {
            if (((object)this.Owner != null) && ((object)this._Source == null) && ((object)this._SourceName != null)) {
#warning TODO
                //var lstFound = this.Owner.Source.FindEntity(this._SourceName);
                //if (lstFound.Count == 1) {
                //    this._Source = lstFound[0];
                //    this._SourceName = null;
                //} else if (lstFound.Count == 0) {
                //    throw new ResolveNameNotFoundException($"{this.SourceName} not found.");
                //} else {
                //    throw new ResolveNameNotUniqueException($"{this.SourceName} found #{lstFound.Count} times.");
                //}
            }
        }

        public override void ResolveNameTarget(ModelErrors errors) {
            if (((object)this.Owner != null) && ((object)this._Target == null) && ((object)this._TargetName != null)) {
#warning TODO
                //var lstFound = this.Owner.FindRepository(this.TargetName);
                //if (lstFound.Count == 1) {
                //    this._Target = lstFound[0];
                //    this._TargetName = null;
                //} else if (lstFound.Count == 0) {
                //    throw new ResolveNameNotFoundException($"{this.TargetName} not found.");
                //} else {
                //    throw new ResolveNameNotUniqueException($"{this.TargetName} found #{lstFound.Count} times.");
                //}
            }
        }
    }
}
