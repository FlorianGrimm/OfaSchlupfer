namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    [JsonObject]
    public class ModelRepository {
        [JsonIgnore]
        private ModelEntityName _Name;

        [JsonIgnore]
        private IRepository _Repository;

        public ModelRepository() {
        }

        [JsonProperty]
        public ModelEntityName Name {
            get {
                return this._Name;
            }
            set {
                this._Name = value;
                if (this.ModelSchema != null) {
                    this.ModelSchema._Name = value;
                }
            }
        }

        [JsonProperty]
        public ModelDefinition ModelDefinition { get; set; }

        [JsonProperty]
        public string RepositoryType { get; set; }

        [JsonProperty]
        public string SqlSchemaName { get; set; }

        [JsonProperty]
        public ModelSchema ModelSchema { get; set; }

        [JsonIgnore]
        public IRepository Repository {
            get {
                return this._Repository;
            }
            set {
                this._Repository = value;
            }
        }

        public IRepository GetRepository(IServiceProvider serviceProvider) {
            if (this.Repository != null) { return this.Repository; }
            if (this.RepositoryType == null) {
                return null;
            }
            {
                var rtf = new RepositoryTypeFactory(serviceProvider);
                var instance = rtf.CreateRepository(this.RepositoryType);
                var result = System.Threading.Interlocked.CompareExchange(ref this._Repository, instance, null);
                if (ReferenceEquals(result, null)) {
                    return instance;
                } else {
                    return this.Repository;
                }
            }
        }
    }
}
