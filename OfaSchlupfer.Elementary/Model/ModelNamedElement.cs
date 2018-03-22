namespace OfaSchlupfer.Model {
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    [JsonObject]
    public class ModelNamedElement {
        [JsonProperty(Order = 1)]
        public ModelEntityName Name;

        public override string ToString() {
            return (this.Name == null) ? this.GetType().Name : this.Name.ToString();
        }
    }
}