namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Text;

    [JsonObject]
    public class ModelDefinition {
        public string MetaData { get; set; }

        public string Kind { get; set; }
    }
}
