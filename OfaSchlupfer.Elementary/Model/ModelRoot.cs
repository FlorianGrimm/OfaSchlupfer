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
        : FreezeableObject {
        [JsonIgnore]
        private string _Name;

        [JsonIgnore]
        private readonly FreezeableOwnedKeyedCollection<ModelRoot, ModelEntityName, ModelRepository> _Repositories;

        [JsonIgnore]
        private readonly FreezeableOwnedKeyedCollection<ModelRoot, string, MappingRepository> _RepositoryMappings;

        public FreezeableOwnedKeyedCollection<ModelRoot, ModelEntityName, ModelRepository> Repositories => this._Repositories;

        public FreezeableOwnedKeyedCollection<ModelRoot, string, MappingRepository> RepositoryMappings => this._RepositoryMappings;

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

        /// <summary>
        /// Find a repository by name.
        /// </summary>
        /// <param name="name">the name of the repository</param>
        /// <returns>the repository</returns>
        public List<ModelRepository> FindRepository(ModelEntityName name) => this._Repositories.FindByKey(name);
        
        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this._Repositories.Freeze();
                this._RepositoryMappings.Freeze();
            }
            return result;
        }
    }
}
