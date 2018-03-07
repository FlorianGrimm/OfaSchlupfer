namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Serializable]
    public class ModelConstraint {
        public string Name;
        public string Type;
        public readonly List<ModelProperty> Properties;
        public ModelConstraint() {
        }
    }
}
