namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Maps 2 repositories
    /// </summary>
    [Serializable]
    public class MappingRepository {
        public string SourceName;
        public string TargetName;
        [NonSerialized]
        public ModelRepository Source;
        [NonSerialized]
        public ModelRepository Target;

        public MappingSchema Mapping;

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
                if (!string.IsNullOrEmpty(this.SourceName)) {
                    if (current.RepositoriesByName.TryGetValue(this.SourceName, out var source)) {
                        this.Source = source;
                    }
                }
            }
            if (this.Target == null) {
                if (!string.IsNullOrEmpty(this.TargetName)) {
                    if (current.RepositoriesByName.TryGetValue(this.TargetName, out var target)) {
                        this.Target = target;
                    }
                }
            }
            this.Mapping?.ResolveNames(current);
        }
    }
}
