namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;

    using System;
    using System.Collections.Generic;
    using System.Text;

    [JsonObject]
    public class ModelComplexType : ModelType {
        [JsonProperty(Order = 2)]
        public readonly List<ModelProperty> Properties;

        public ModelComplexType() {
            this.Properties = new List<ModelProperty>();
        }
    }
}
