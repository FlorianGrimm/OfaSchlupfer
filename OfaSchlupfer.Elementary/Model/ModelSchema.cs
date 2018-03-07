namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Serializable]
    public class ModelSchema {
        [NonSerialized]
        internal string _Name;

        public readonly List<ModelEntity> Entities;

        public ModelSchema() {
            this.Entities = new List<ModelEntity>();
        }

        public string Name => this._Name;

        public class Current {
            public readonly ModelSchema ModelSchema;
            public readonly Dictionary<string, ModelEntity> EntityByName;
            public readonly Dictionary<string, ModelRelation> RelationByName;

            public Current(ModelSchema modelSchema, bool build) {
                this.ModelSchema = modelSchema;
                var comparer = StringComparer.InvariantCultureIgnoreCase;
                if (build) {
                    this.EntityByName = modelSchema.Entities.ToDictionary(_ => _.Name, comparer);
                    this.RelationByName = modelSchema.Entities.SelectMany(_ => _.Relations).ToDictionary(_ => _.Name, comparer);
                } else {
                    this.EntityByName = new Dictionary<string, ModelEntity>(comparer);
                    this.RelationByName = new Dictionary<string, ModelRelation>(comparer);
                }
            }
        }
    }
}
