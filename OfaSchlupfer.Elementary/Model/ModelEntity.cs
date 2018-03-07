namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Serializable]
    public class ModelEntity : ModelType {
        public readonly List<ModelProperty> Properties;
        public readonly List<ModelRelation> Relations;
        public readonly List<ModelConstraint> Constraints;
        public ModelEntity() {
            this.Properties = new List<ModelProperty>();
            this.Relations = new List<ModelRelation>();
            this.Constraints = new List<ModelConstraint>();
        }
    }
}
