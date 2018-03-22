namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;

    using System;
    using System.Collections.Generic;
    using System.Text;

    [JsonObject]
    public class ModelTableType : ModelType {
        [JsonProperty(Order = 2)]
        public readonly List<ModelProperty> Properties;

        public ModelTableType() {
            this.Properties = new List<ModelProperty>();
        }
    }
}
