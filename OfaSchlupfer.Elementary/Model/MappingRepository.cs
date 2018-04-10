namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;
    using OfaSchlupfer.Freezable;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Maps 2 repositories
    /// </summary>
    [JsonObject]
    public class MappingRepository
        : MappingObject<string, ModelEntityName, ModelRepository> {
        [JsonIgnore]
        private MappingSchema _Mapping;

        [JsonIgnore]
        private ModelRoot _Owner;

        [JsonProperty]
        public MappingSchema Mapping {
            get {
                return this._Mapping;
            }
            set {
                this.ThrowIfFrozen();
                this._Mapping = value;
            }
        }

        [JsonIgnore]
        public ModelRoot Owner {
            get {
                return this._Owner;
            }
            internal set {
                this.ThrowIfFrozen();
                this._Owner = value;
            }
        }

        public MappingRepository() {
        }

        protected override bool AreSourceNamesEqual(ModelEntityName sourceName, ref ModelEntityName value) => MappingObjectHelper.AreNamesEqual(sourceName, ref value);

        protected override bool AreTargetNamesEqual(ModelEntityName targetName, ref ModelEntityName value) => MappingObjectHelper.AreNamesEqual(targetName, ref value);

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

        internal void UpdateNames(ModelRoot.Current current) {
            if (this.Source != null) {
                var name = this.Source.Name;
                this.SourceName = name;
                current.RepositoriesByName[name] = this.Source;
            }
            if (this.Target != null) {
                var name = this.Target.Name;
                this.TargetName = name;
                current.RepositoriesByName[name] = this.Target;
            }

            if (this.Mapping != null) {
                if (this.Mapping.Source != null) {
                    var name = this.Mapping.Source.Name;
                    this.Mapping.SourceName = name;
                    current.SchemaByName[name] = this.Mapping.Source;
                }
                if (this.Mapping.Target != null) {
                    var name = this.Mapping.Target.Name;
                    this.Mapping.TargetName = name;
                    current.SchemaByName[name] = this.Mapping.Target;
                }
                this.Mapping.UpdateNames(current);
            }
        }

        internal void ResolveNames(ModelRoot.Current current) {
            if (this.Source == null) {
                if (this.SourceName != null) {
                    if (current.RepositoriesByName.TryGetValue(this.SourceName, out var source)) {
                        this.Source = source;
                    }
                }
            }
            if (this.Target == null) {
                if (this.TargetName != null) {
                    if (current.RepositoriesByName.TryGetValue(this.TargetName, out var target)) {
                        this.Target = target;
                    }
                }
            }
            this.Mapping?.ResolveNames(current);
        }
    }
}
