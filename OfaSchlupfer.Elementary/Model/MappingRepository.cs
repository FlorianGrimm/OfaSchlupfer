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
        : FreezeableObject {

        [JsonIgnore]
        public ModelRepository Source;
        [JsonIgnore]
        public ModelRepository Target;

        [JsonProperty]
        public ModelEntityName SourceName;

        [JsonProperty]
        public ModelEntityName TargetName;

        [JsonProperty]
        public MappingSchema Mapping;

        [JsonIgnore]
        public ModelRoot Owner { get; internal set; }

        public MappingRepository() {
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
