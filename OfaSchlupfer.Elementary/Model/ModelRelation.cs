namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [JsonObject]
    public class ModelRelation {
        //[JsonIgnore]
        [JsonProperty(Order = 1)]
        public string Name { get; set; }

        [JsonProperty(Order = 2, ItemIsReference = true)]
        public ModelEntity Master { get; set; }

        [JsonProperty(Order = 3, ItemIsReference = true)]
        public ModelEntity Child { get; set; }

        public ModelRelation() {

        }
    }
}
