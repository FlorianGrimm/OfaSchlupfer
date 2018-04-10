namespace OfaSchlupfer.Model {
    using System;

    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;

    [JsonObject]
    public class MappingProperty
        : MappingObjectString<ModelProperty> {
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
            }
        }

        public override void ResolveNameTarget() {
            if (((object)this._Target == null) && ((object)this._TargetName != null)) {
            }
        }

        internal void UpdateNames(ModelRoot.Current current, ModelSchema.Current sourceCurrent, ModelSchema.Current targetCurrent) {
            throw new NotImplementedException();
        }

        internal void ResolveNames(ModelRoot.Current current, ModelSchema.Current sourceCurrent, ModelSchema.Current targetCurrent) {
            throw new NotImplementedException();
        }
    }

    [JsonObject]
    public class MappingProperty3
        : FreezeableObject {

        [JsonIgnore]
        private string _Name;

        [JsonIgnore]
        private bool _Enabled;

        [JsonIgnore]
        private string _Conversion;

        [JsonIgnore]
        private string _SourceName;

        [JsonIgnore]
        private string _TargetName;

        [JsonIgnore]
        private ModelProperty _Source;

        [JsonIgnore]
        private ModelProperty _Target;

        public MappingProperty3() {
        }

        [JsonProperty]
        public string SourceName {
            get {
                return this._SourceName;
            }
            set {
                this.ThrowIfFrozen();
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._SourceName, value, StringComparison.Ordinal)) { return; }
                this._SourceName = value;
            }
        }

        [JsonProperty]
        public string TargetName {
            get {
                return this._TargetName;
            }
            set {
                this.ThrowIfFrozen();
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._TargetName, value, StringComparison.Ordinal)) { return; }
                this._TargetName = value;
            }
        }

        [JsonIgnore]
        public ModelProperty Source {
            get {
                return this._Source;
            }
            set {
                this.ThrowIfFrozen();
                if (ReferenceEquals(this._Source, value)) { return; }
                this._Source = value;
            }
        }

        [JsonIgnore]
        public ModelProperty Target {
            get {
                return this._Target;
            }
            set {
                this.ThrowIfFrozen();
                if (ReferenceEquals(this._Target, value)) { return; }
                this._Target = value;
            }
        }

        [JsonProperty]
        public string Name {
            get {
                return this._Name;
            }
            set {
                this.ThrowIfFrozen();
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._Name, value, StringComparison.Ordinal)) { return; }
                this._Name = value;
            }
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

        internal void UpdateNames(ModelRoot.Current current, ModelSchema.Current sourceCurrent, ModelSchema.Current targetCurrent) {
            throw new NotImplementedException();
        }

        internal void ResolveNames(ModelRoot.Current current, ModelSchema.Current sourceCurrent, ModelSchema.Current targetCurrent) {
            throw new NotImplementedException();
        }
    }
}
