namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [JsonObject]
    public class ModelSchema {
        [JsonIgnore]
        internal ModelEntityName _Name;

        [JsonProperty(Order = 2)]
        public ModelEntityName RootEntityName { get; set; }

        [JsonProperty(Order = 3, ItemIsReference = true)]
        public readonly List<ModelTableType> TableTypes;

        [JsonProperty(Order = 4, ItemIsReference = true)]
        public readonly List<ModelEntity> Entities;

        [JsonProperty(Order = 5, ItemIsReference = false)]
        public readonly List<ModelRelation> Relations;

        public ModelSchema() {
            this.TableTypes = new List<ModelTableType>();
            this.Entities = new List<ModelEntity>();
            this.Relations = new List<ModelRelation>();
        }

        [JsonIgnore]
        public ModelEntityName Name => this._Name;

        public class Current {
            public readonly ModelSchema ModelSchema;
            public readonly Dictionary<ModelEntityName, ModelEntity> EntityByName;
            public readonly Dictionary<string, ModelRelation> RelationByName;
            public readonly Dictionary<ModelEntityName, ModelTableType> TableTypes;

            public Current(ModelSchema modelSchema, bool build) {
                this.ModelSchema = modelSchema;
                var stringComparer = ModelUtility.Instance.StringComparer;
                var nameEqualityComparer = ModelUtility.Instance.ModelEntityNameEqualityComparer;
                if (build) {
                    this.TableTypes = modelSchema.TableTypes.ToDictionary(_ => _.Name, nameEqualityComparer);
                    this.EntityByName = modelSchema.Entities.ToDictionary(_ => _.Name, nameEqualityComparer);
                    this.RelationByName = modelSchema.Relations.ToDictionary(_ => _.Name, stringComparer);
                } else {
                    this.TableTypes = new Dictionary<ModelEntityName, ModelTableType>(nameEqualityComparer);
                    this.EntityByName = new Dictionary<ModelEntityName, ModelEntity>(nameEqualityComparer);
                    this.RelationByName = new Dictionary<string, ModelRelation>(stringComparer);
                }
            }
        }

        //public void AddRelation(ModelRelation modelRelation) {
        //    this.Relations.Add(modelRelation);
        //    //if (modelRelation.Master != null) {
        //    //    modelRelation.Master.
        //    //}
        //}
    }
}
