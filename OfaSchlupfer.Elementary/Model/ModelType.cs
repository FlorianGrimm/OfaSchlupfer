namespace OfaSchlupfer.Model {
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Base of <see cref="ModelComplexType"/> and <see cref="ModelScalarType"/>.
    /// </summary>
    [JsonObject]
    public class ModelType : ModelNamedOwnedElement<ModelSchema> {
        public ModelType() {
        }
        public virtual Type GetClrType() { return null; }
    }
}
