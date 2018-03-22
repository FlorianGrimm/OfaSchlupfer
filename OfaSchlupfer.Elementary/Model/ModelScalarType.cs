namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [JsonObject]
    public class ModelScalarType : ModelType {
        public ModelScalarType() {
            this.IsNullable = true;
        }

        [JsonProperty(Order = 2)]
        public bool IsNullable { get; set; }
    }
}
