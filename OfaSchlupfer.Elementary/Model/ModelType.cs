namespace OfaSchlupfer.Model {
    using System;
    using Newtonsoft.Json;

    [JsonObject]
    public abstract class ModelType : ModelNamedOwnedElement<ModelSchema> {
        public abstract Type GetClrType();
    }
}
