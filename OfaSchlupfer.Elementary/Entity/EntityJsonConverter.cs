namespace OfaSchlupfer.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Newtonsoft.Json;

    public class EntityJsonConverter : JsonConverter {
        private const string PropertyName__metadata = "__metadata";
        private const string PropertyName_type = "type";
        public EntitySchema EntitySchema { get; }

        public EntityJsonConverter() {
        }

        public EntityJsonConverter(EntitySchema entitySchema) {
            this.EntitySchema = entitySchema;
        }


        public override bool CanConvert(Type objectType) {
            return typeof(IEntity).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            IEntity result = null;
            IMetaEntity metaEntity = null;
            string entityTypeName = null;
            if (reader.TokenType == JsonToken.StartObject) {
                if (reader.Read()) {
                    if (reader.TokenType == JsonToken.PropertyName && string.Equals((reader.Value as string), PropertyName__metadata, StringComparison.Ordinal)) {
                        if (reader.Read()) {
                            if (reader.TokenType == JsonToken.StartObject) {
                                if (reader.Read()) {
                                    if (reader.TokenType == JsonToken.PropertyName && string.Equals((reader.Value as string), PropertyName_type, StringComparison.Ordinal)) {
                                        entityTypeName = reader.ReadAsString();
                                        if (reader.Read()) {
                                            if (reader.TokenType == JsonToken.EndObject) {
                                                if (reader.Read()) {
                                                    //OK
                                                    result = this.EntitySchema?.CreateEntity(entityTypeName);
                                                    metaEntity = result?.MetaData;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (result is null || metaEntity is null) {
                    throw new NotImplementedException("thinkof");
                }
                while (reader.TokenType == JsonToken.PropertyName) {
                    var propertyName = reader.Value as string;
                    if (reader.Read()) {
                        var metaProperty = metaEntity.GetProperty(propertyName);
                        var propertyValue = serializer.Deserialize(reader, metaProperty.PropertyType);
                        metaProperty.GetAccessor(result).Value = propertyValue;
                        reader.Read();
                    }
                }
                if (reader.TokenType == JsonToken.EndObject) {
                    return result;
                }
            }
            throw new NotImplementedException($"Unexpected {reader.TokenType} {reader.Path}");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            var entity = (IEntity)value;
            if (entity is null) {
                writer.WriteNull();
            } else {
                var metaData = entity.MetaData;
                if (entity is IEntityArrayValues entityArrayValues && metaData is IMetaEntityArrayValues metaEntityArray) {
                    var metaProperties = metaEntityArray.GetPropertiesByIndex();
                    writer.WriteStartObject();
                    {
                        if (metaData.EntityTypeName != null) {
                            writer.WritePropertyName(PropertyName__metadata);
                            writer.WriteStartObject();
                            {
                                writer.WritePropertyName(PropertyName_type);
                                serializer.Serialize(writer, metaData.EntityTypeName);
                            }
                            writer.WriteEndObject();
                        }
                        for (int index = 0; index < metaProperties.Count; index++) {
                            var metaProperty = metaProperties[index];
                            writer.WritePropertyName(metaProperty.Name);
                            var propertyValue = metaProperty.GetAccessor(entity).Value;
                            serializer.Serialize(writer, propertyValue);
                        }
                    }
                    writer.WriteEndObject();
                } else {
                    var metaProperties = metaData.GetProperties();

                    writer.WriteStartObject();
                    {
                        if (metaData.EntityTypeName != null) {
                            writer.WritePropertyName(PropertyName__metadata);
                            writer.WriteStartObject();
                            {
                                writer.WritePropertyName(PropertyName_type);
                                serializer.Serialize(writer, metaData.EntityTypeName);
                            }
                            writer.WriteEndObject();
                        }
                        foreach (var metaProperty in metaProperties) {
                            writer.WritePropertyName(metaProperty.Name);
                            var propertyValue = metaProperty.GetAccessor(entity).Value;
                            serializer.Serialize(writer, propertyValue);
                        }
                    }
                    writer.WriteEndObject();
                }
            }
        }
    }
}
