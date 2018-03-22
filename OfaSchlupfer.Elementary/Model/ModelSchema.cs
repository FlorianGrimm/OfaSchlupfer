namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The schema, classes, or entity projection
    /// </summary>
    [JsonObject]
    public class ModelSchema {
        [JsonIgnore]
        internal ModelEntityName _Name;

        [JsonProperty(Order = 2)]
        public ModelEntityName RootEntityName { get; set; }

        [JsonProperty(Order = 3)]
        public readonly List<ModelComplexType> ComplexTypes;

        [JsonProperty(Order = 4)]
        public readonly List<ModelEntity> Entities;

        [JsonProperty(Order = 5)]
        public readonly List<ModelRelation> Relations;

        public ModelSchema() {
            this.ComplexTypes = new List<ModelComplexType>();
            this.Entities = new List<ModelEntity>();
            this.Relations = new List<ModelRelation>();
        }

        [JsonIgnore]
        public ModelEntityName Name => this._Name;

        public void PostDeserialize() {
        }

        public class Current {
            public readonly ModelSchema ModelSchema;
            public readonly Dictionary<ModelEntityName, ModelEntity> EntityByName;
            public readonly Dictionary<string, ModelRelation> RelationByName;
            public readonly Dictionary<ModelEntityName, ModelComplexType> ComplexTypes;

            public Current(ModelSchema modelSchema, bool build) {
                this.ModelSchema = modelSchema;
                var stringComparer = ModelUtility.Instance.StringComparer;
                var nameEqualityComparer = ModelUtility.Instance.ModelEntityNameEqualityComparer;
                if (build) {
                    this.ComplexTypes = modelSchema.ComplexTypes.ToDictionary(_ => _.Name, nameEqualityComparer);
                    this.EntityByName = modelSchema.Entities.ToDictionary(_ => _.Name, nameEqualityComparer);
                    this.RelationByName = modelSchema.Relations.ToDictionary(_ => _.Name, stringComparer);
                } else {
                    this.ComplexTypes = new Dictionary<ModelEntityName, ModelComplexType>(nameEqualityComparer);
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
