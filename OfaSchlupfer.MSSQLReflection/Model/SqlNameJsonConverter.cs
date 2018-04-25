namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Linq;
    using Newtonsoft.Json;

    public class SqlNameJsonConverter : JsonConverter<SqlName> {
        private static Tuple<ObjectLevel, string>[] ObjectLevelNameValues;

        public override SqlName ReadJson(
            JsonReader reader,
            Type objectType,
            SqlName existingValue,
            bool hasExistingValue,
            JsonSerializer serializer) {
            var content = (string)reader.Value;
            return ConvertFromValue(content);
        }

        public override void WriteJson(JsonWriter writer, SqlName value, JsonSerializer serializer) {
            var txt = ConvertToValue(value);
            writer.WriteValue(txt);
        }

        public static string ConvertToValue(SqlName value) {
            if (value is null) { return null; }
            return value.ObjectLevel.ToString() + ";" + value.GetQFullName("[", 0);
        }

        public static SqlName ConvertFromValue(string value) {

            if (string.IsNullOrEmpty(value)) { return null; }
            var objectLevelNameValues = ObjectLevelNameValues;
            if (objectLevelNameValues is null) {
                objectLevelNameValues = ((ObjectLevel[])System.Enum.GetValues(typeof(ObjectLevel)))
                    .Select(lvl => Tuple.Create(lvl, lvl.ToString()))
                    .ToArray();
                ObjectLevelNameValues = objectLevelNameValues;
            }

            foreach (var nameValue in objectLevelNameValues) {
                if (value.StartsWith(nameValue.Item2 + ";", StringComparison.Ordinal)) {
                    var names = value.Substring(nameValue.Item2.Length + 1);
                    return SqlName.Parse(names, nameValue.Item1);
                }
            }

            return null;
        }
    }
}