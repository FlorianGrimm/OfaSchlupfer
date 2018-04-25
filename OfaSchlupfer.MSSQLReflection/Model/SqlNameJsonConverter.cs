namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Linq;
    using Newtonsoft.Json;

    public class SqlNameJsonConverter : JsonConverter<SqlName> {
        private Tuple<ObjectLevel, string>[] ObjectLevelNameValues;

        public override SqlName ReadJson(
            JsonReader reader,
            Type objectType,
            SqlName existingValue,
            bool hasExistingValue,
            JsonSerializer serializer) {
            var content = reader.ReadAsString();
            if (string.IsNullOrEmpty(content)) { return null; }
            var objectLevelNameValues = ObjectLevelNameValues;
            if (objectLevelNameValues is null) {
                objectLevelNameValues = ((ObjectLevel[])System.Enum.GetValues(typeof(ObjectLevel)))
                    .Select(lvl => Tuple.Create(lvl, lvl.ToString()))
                    .ToArray();
                ObjectLevelNameValues = objectLevelNameValues;
            }

            foreach (var nameValue in objectLevelNameValues) {
                if (content.StartsWith(nameValue.Item2 + ";", StringComparison.Ordinal)) {
                    var names = content.Substring(nameValue.Item2.Length + 1);
                    return SqlName.Parse(names, nameValue.Item1);
                }
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, SqlName value, JsonSerializer serializer) {
            var txt = ConvertToValue(value);
            writer.WriteValue(txt);
        }

        public static string ConvertToValue(SqlName value) {
            return value.ObjectLevel.ToString() + ";" + value.GetQFullName("[", 0);
        }
    }
}