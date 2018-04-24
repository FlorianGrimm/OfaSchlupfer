namespace OfaSchlupfer.Model {
    using System;
    using Newtonsoft.Json;

    [JsonObject]
    public class ModelType : ModelNamedOwnedElement<ModelSchema> {
        public ModelType() {
        }
        public virtual Type GetClrType() { return null; }
    }
}
