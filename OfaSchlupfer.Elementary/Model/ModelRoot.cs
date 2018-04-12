namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;

    /// <summary>
    /// Tenant global root of all models.
    /// </summary>
    [JsonObject]
    public class ModelRoot
        : FreezeableObject
        , IMappingNamedObject<string> {
        [JsonIgnore]
        private string _Name;

        [JsonIgnore]
        private readonly FreezeableOwnedKeyedCollection<ModelRoot, ModelEntityName, ModelRepository> _Repositories;

        [JsonIgnore]
        private readonly FreezeableOwnedKeyedCollection<ModelRoot, string, MappingRepository> _RepositoryMappings;

        public IList<ModelRepository> Repositories => this._Repositories;

        public IList<MappingRepository> RepositoryMappings => this._RepositoryMappings;

        public ModelRoot() {
            this._Repositories = new FreezeableOwnedKeyedCollection<ModelRoot, ModelEntityName, ModelRepository>(
                this, (item) => item.Name,
                ModelUtility.Instance.ModelEntityNameEqualityComparer,
                (that, item) => { item.Owner = that; });
            this._RepositoryMappings = new FreezeableOwnedKeyedCollection<ModelRoot, string, MappingRepository>(
                this, (item) => item.Name,
                ModelUtility.Instance.StringComparer,
                (that, item) => { item.Owner = that; });
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

#warning TODO weichei
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
        /// <returns>the repository</returns>
        public List<ModelRepository> FindRepository(ModelEntityName name) => this._Repositories.FindByKey(name);

        public string GetName() => this._Name;

        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this._Repositories.Freeze();
                this._RepositoryMappings.Freeze();
            }
            return result;
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
