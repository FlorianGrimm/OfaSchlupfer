namespace OfaSchlupfer.Model {
    using System;
    using System.Linq;
    using Newtonsoft.Json;
    using OfaSchlupfer.Entity;

    public static class ModelJsonUtility {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static string SerializeModelToJson<T>(
            this T that,
            JsonSerializerSettings settings)
            where T : class {
            settings = EnsureSerializeObjectSettings(settings);
            var result = JsonConvert.SerializeObject(that, settings);
            return result;
        }

        public static T DeserializeModelFromJson<T>(
            string json,
            JsonSerializerSettings settings
            //IServiceProvider serviceProvider
            )
            where T : class {
            if (string.IsNullOrEmpty(json)) { return null; }
            settings = EnsureDeserializeObjectSettings(settings);
            var result = JsonConvert.DeserializeObject<T>(json, settings);
            return result;
        }

        public static JsonSerializerSettings EnsureSerializeObjectSettings(
            JsonSerializerSettings settings
            //IServiceProvider serviceProvider,
            ) {
            if (settings == null) {
                settings = new JsonSerializerSettings();
            }
            if (settings.TypeNameHandling == TypeNameHandling.None) {
                settings.TypeNameHandling = TypeNameHandling.Objects;
            }
            //if (!(settings.Converters.Any((converter) => converter is TypeJsonConverter))) {                
            //    settings.Converters.Add(new TypeJsonConverter());
            //}
            return settings;
        }

        public static JsonSerializerSettings EnsureDeserializeObjectSettings(
            JsonSerializerSettings settings
            //IServiceProvider serviceProvider,
            ) {
            if (settings == null) {
                settings = new JsonSerializerSettings();
            }
            if (settings.TypeNameHandling == TypeNameHandling.None) {
                settings.TypeNameHandling = TypeNameHandling.Objects;
            }
            //if (!(settings.Converters.Any((converter) => converter is TypeJsonConverter))) {
            //    settings.Converters.Add(new TypeJsonConverter());
            //}
            return settings;
        }
    }
}
