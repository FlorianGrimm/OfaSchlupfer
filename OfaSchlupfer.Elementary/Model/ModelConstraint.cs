namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    [JsonObject]
    public class ModelConstraint {
        public string Name;
        public string Type;
        public readonly List<ModelProperty> Properties;
        public ModelConstraint() {
        }
    }
}
