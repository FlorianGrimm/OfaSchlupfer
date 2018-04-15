namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;

    [JsonObject]
    public abstract class ModelType : ModelNamedOwnedElement<ModelSchema> {
    }
}
