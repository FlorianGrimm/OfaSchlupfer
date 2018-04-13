namespace OfaSchlupfer.Model {
    using System;

    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;

    [JsonObject]
    public class MappingProperty
        : MappingObject<ModelEntityName, ModelEntityName, ModelProperty> {
        [JsonIgnore]
        private MappingEntity _Owner;

        [JsonIgnore]
        private bool _Enabled;

        [JsonIgnore]
        private string _Conversion;

        public MappingProperty() {
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

        protected override bool AreThisNamesEqual(ModelEntityName thisName, ref ModelEntityName value) => MappingObjectHelper.AreNamesEqual(thisName, ref value);

        public override void ResolveNameSource(ModelErrors errors) {
            if (((object)this._Owner != null) && ((object)this._Source == null) && ((object)this._SourceName != null)) {
                var lstFound = this.Owner.Source.EntityType.Properties.FindByKey(this._SourceName);
                if (lstFound.Count == 1) {
                    this._Source = lstFound[0];
                    this._SourceName = null;
                } else if (lstFound.Count == 0) {
                    errors.AddErrorOrThrow($"Source {this._SourceName} not found", this.Name?.ToString(), ResolveNameNotFoundException.Factory);
                } else {
                    errors.AddErrorOrThrow($"Source {this._SourceName} found #{lstFound.Count} times.", this.Name?.ToString(), ResolveNameNotUniqueException.Factory);
                }
            }
        }

        public override void ResolveNameTarget(ModelErrors errors) {
            if (((object)this._Owner != null) && ((object)this._Target == null) && ((object)this._TargetName != null)) {
                var lstFound = this.Owner.Target.EntityType.Properties.FindByKey(this._TargetName);
                if (lstFound.Count == 1) {
                    this._Target = lstFound[0];
                    this._TargetName = null;
                } else if (lstFound.Count == 0) {
                    errors.AddErrorOrThrow($"Target {this._TargetName} not found", this.Name?.ToString(), ResolveNameNotFoundException.Factory);
                } else {
                    errors.AddErrorOrThrow($"Target {this._TargetName} found #{lstFound.Count} times.", this.Name?.ToString(), ResolveNameNotUniqueException.Factory);
                }
            }
        }
    }
}