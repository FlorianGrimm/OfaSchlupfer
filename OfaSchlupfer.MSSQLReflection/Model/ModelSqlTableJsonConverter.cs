namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using Newtonsoft.Json;
    public class ModelSqlTableJsonConverter : JsonConverter<ModelSqlTable> {
        public ModelSqlTableJsonConverter() {
        }

        public override ModelSqlTable ReadJson(JsonReader reader, Type objectType, ModelSqlTable existingValue, bool hasExistingValue, JsonSerializer serializer) {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, ModelSqlTable value, JsonSerializer serializer) {
            writer.WriteStartObject();
            writer.WritePropertyName("Name");
            writer.WriteRawValue(SqlNameJsonConverter.ConvertToValue(value.Name));
            writer.WriteEndObject();

        }
    }
}