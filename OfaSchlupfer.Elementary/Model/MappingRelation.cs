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
        : MappingObjectString<ModelRelation>
        , IMappingNamedObject<string> {
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
            if (this.Source == null) {
                if (!string.IsNullOrEmpty(this.SourceName)) {
                    if (sourceCurrent.RelationByName.TryGetValue(this.SourceName, out var source)) {
                        this.Source = source;
                    }
                }
            }
            if (this.Target != null) {
                if (!string.IsNullOrEmpty(this.TargetName)) {
                    if (targetCurrent.RelationByName.TryGetValue(this.TargetName, out var target)) {
                        this.Target = target;
                    }
                }
            }
        }
    }
}
