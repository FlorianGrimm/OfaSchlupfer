namespace OfaSchlupfer.Entity {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Newtonsoft.Json;

    public class TypeJsonConverter : JsonConverter {
        private static Dictionary<string, Type> Name2Type;
        private static Dictionary<Type, string> Type2Name;

        private static void Add(Type t, string n) {
            Name2Type.Add(n, t);
            Type2Name.Add(t, n);
        }

        private static void Fill() {
            if (Name2Type is null) {
                Name2Type = new Dictionary<string, Type>();
                Type2Name = new Dictionary<Type, string>();

                Add(typeof(string), "String");
                Add(typeof(Guid), "Guid");
                Add(typeof(Guid?), "Guid?");
                Add(typeof(bool), "bool");
                Add(typeof(bool?), "bool?");
                Add(typeof(char[]), "char[]");
                Add(typeof(byte[]), "byte[]");
                Add(typeof(byte), "byte");
                Add(typeof(byte?), "byte?");
                Add(typeof(short), "short");
                Add(typeof(short?), "short?");
                Add(typeof(int), "int");
                Add(typeof(int?), "int?");
                Add(typeof(long), "long");
                Add(typeof(long?), "long?");
                Add(typeof(decimal), "decimal");
                Add(typeof(decimal?), "decimal?");
                Add(typeof(float), "float");
                Add(typeof(float?), "float?");
                Add(typeof(double), "double");
                Add(typeof(double?), "double?");
                Add(typeof(DateTime), "DateTime");
                Add(typeof(DateTime?), "DateTime?");
            }
        }

        public TypeJsonConverter() {
            Fill();
        }


        public override bool CanConvert(Type objectType) {
            return objectType == typeof(Type);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            var typeName = reader.ReadAsString();
            var type=Name2Type.GetValueOrDefault(typeName);
            if (type is null) {
                type = System.Type.GetType(typeName);
            }
            return type ?? existingValue;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            if (value is null) {
                writer.WriteNull();
            } else {
                var type = (Type)value;
                var typeName = Type2Name.GetValueOrDefault(type);
                if (typeName is null) {
                    typeName = type.AssemblyQualifiedName;
                }
                writer.WriteValue(typeName);
            }
        }
    }
}
