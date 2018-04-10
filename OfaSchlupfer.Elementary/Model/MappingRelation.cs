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
        : FreezeableObject
        , IMappingNamedObject<string> {
        [JsonIgnore]
        private string _Name;

        [JsonIgnore]
        private bool _Enabled;

        [JsonIgnore]
        private string _SourceName;

        [JsonIgnore]
        private string _TargetName;

        [JsonIgnore]
        private ModelRelation _Source;

        [JsonIgnore]
        private ModelRelation _Target;

        public MappingRelation() {
        }

        [JsonProperty]
        public string SourceName {
            get {
                return this._SourceName;
            }
            set {
                this.ThrowIfFrozen();
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
                this._TargetName = value;
            }
        }

        [JsonIgnore]
        public ModelRelation Source {
            get {
                return this._Source;
            }
            set {
                this.ThrowIfFrozen();
                this._Source = value;
            }
        }

        [JsonIgnore]
        public ModelRelation Target {
            get {
                return this._Target;
            }
            set {
                this.ThrowIfFrozen();
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
                this._Name = value;
            }
        }

        public string GetName() => this._Name;

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
