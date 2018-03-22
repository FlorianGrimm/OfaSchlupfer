﻿namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Tenant global root of all models.
    /// </summary>
    [JsonObject]
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
        public ModelRepository FindRepository(ModelEntityName name) {
            if (name == null) { return null; }
            return this.Repositories.FirstOrDefault(_ => name.Equals(_.Name));
        }

        public class Current {
            public readonly ModelRoot ModelRoot;
            public readonly Dictionary<ModelEntityName, ModelRepository> RepositoriesByName;
            public readonly Dictionary<ModelEntityName, ModelSchema> SchemaByName;
            // public readonly Dictionary<string, ModelSchema.Current> SchemaCurrentByName;

            public Current(ModelRoot modelRoot, bool build) {
                this.ModelRoot = modelRoot;
                var stringComparer = ModelUtility.Instance.StringComparer;
                var nameComparer = ModelUtility.Instance.ModelEntityNameEqualityComparer;
                if (build) {
                    this.RepositoriesByName = modelRoot.Repositories.ToDictionary(repo => repo.Name, nameComparer);
                    this.SchemaByName = modelRoot.Repositories.ToDictionary(repo => repo.Name, repo => repo.ModelSchema, nameComparer);
                } else {
                    this.RepositoriesByName = new Dictionary<ModelEntityName, ModelRepository>(nameComparer);
                    this.SchemaByName = new Dictionary<ModelEntityName, ModelSchema>(nameComparer);
                }
                // this.SchemaCurrentByName = modelRoot.Repositories.ToDictionary(repo => repo.Name, repo => new ModelSchema.Current(repo.ModelSchema), StringComparer.InvariantCultureIgnoreCase);
            }
        }
    }
}
