namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Serializable]
    public class ModelRelation {
        public ModelEntity Master;
        public ModelEntity Child;

        public string Name;
        public ModelRelation() {

        }
    }
}
