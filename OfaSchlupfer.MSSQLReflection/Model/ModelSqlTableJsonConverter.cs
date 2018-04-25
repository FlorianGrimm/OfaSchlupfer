namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using Newtonsoft.Json;

    public class ModelSqlTableJsonConverter : JsonConverter<ModelSqlType> {
        public override ModelSqlType ReadJson(JsonReader reader, Type objectType, ModelSqlType existingValue, bool hasExistingValue, JsonSerializer serializer) {
            //throw new NotImplementedException();
            return new ModelSqlType();
        }

        public override void WriteJson(JsonWriter writer, ModelSqlType value, JsonSerializer serializer) {
            writer.WriteStartObject();
            writer.WritePropertyName("Name");
            writer.WriteRawValue(SqlNameJsonConverter.ConvertToValue(value.Name));
            writer.WriteEndObject();
        }
    }
}