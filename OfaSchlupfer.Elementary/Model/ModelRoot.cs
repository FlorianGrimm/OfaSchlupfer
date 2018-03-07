namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Serializable]
    public class ModelRoot {
        public readonly List<ModelRepository> Repositories;
        public readonly List<MappingRepository> RepositoryMappings;

        public string Name;
        public ModelRoot() {
            this.Repositories = new List<ModelRepository>();
            this.RepositoryMappings = new List<MappingRepository>();
        }

        public void UpdateNames() {
            var current = (new ModelRoot.Current(this, false));

            foreach (var repositoryMapping in this.RepositoryMappings) {
                repositoryMapping.UpdateNames(current);
            }
        }

        public void ResolveNames() {
            var current = (new ModelRoot.Current(this, true));

            foreach (var repositoryMapping in this.RepositoryMappings) {
                repositoryMapping.ResolveNames(current);
            }
        }

        /// <summary>
        /// Find a repository by name.
        /// </summary>
        /// <param name="name">the name of the repository</param>
        /// <returns>the repository or null.</returns>
        public ModelRepository FindRepository(string name) {
            return this.Repositories.FirstOrDefault(_ => String.Equals(_.Name, name, StringComparison.OrdinalIgnoreCase));
        }

        public class Current {
            public readonly ModelRoot ModelRoot;
            public readonly Dictionary<string, ModelRepository> RepositoriesByName;
            public readonly Dictionary<string, ModelSchema> SchemaByName;
            // public readonly Dictionary<string, ModelSchema.Current> SchemaCurrentByName;

            public Current(ModelRoot modelRoot, bool build) {
                this.ModelRoot = modelRoot;
                var comparer = StringComparer.InvariantCultureIgnoreCase;
                if (build) {
                    this.RepositoriesByName = modelRoot.Repositories.ToDictionary(repo => repo.Name, comparer);
                    this.SchemaByName = modelRoot.Repositories.ToDictionary(repo => repo.Name, repo => repo.ModelSchema, comparer);
                } else {
                    this.RepositoriesByName = new Dictionary<string, ModelRepository>(comparer);
                    this.SchemaByName = new Dictionary<string, ModelSchema>(comparer);
                }
                // this.SchemaCurrentByName = modelRoot.Repositories.ToDictionary(repo => repo.Name, repo => new ModelSchema.Current(repo.ModelSchema), StringComparer.InvariantCultureIgnoreCase);
            }
        }
    }
}
