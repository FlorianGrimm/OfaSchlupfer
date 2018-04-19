namespace OfaSchlupfer.Entity {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Newtonsoft.Json;

    public static class EntityJsonUtiltity {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static string SerializeToJson<T>(
            this T that, 
            JsonSerializerSettings settings,
            EntitySchema entitySchema)
            where T : IEntityFlexible {
            settings = EnsureSerializeObjectSettings(settings, entitySchema);
            var result = JsonConvert.SerializeObject(that, settings);
            return result;
        }

        public static T DeserializeFromJson<T>(
            string json, 
            JsonSerializerSettings settings, 
            //IServiceProvider serviceProvider
            EntitySchema entitySchema)
            where T : class, IEntityFlexible {
            if (string.IsNullOrEmpty(json)) { return null; }
            settings = EnsureDeserializeObjectSettings(settings, entitySchema);
            var result = JsonConvert.DeserializeObject<T>(json, settings);
            return result;
        }

        public static JsonSerializerSettings EnsureSerializeObjectSettings(
            JsonSerializerSettings settings,
            //IServiceProvider serviceProvider,
            EntitySchema entitySchema) {
            if (settings == null) {
                settings = new JsonSerializerSettings();
            }
            if (!(settings.Converters.Any((converter) => converter is EntityJsonConverter))) {
                if (entitySchema is null) { throw new ArgumentNullException(nameof(entitySchema), "is required to create a EntityJsonConverter."); }
                settings.Converters.Add(new EntityJsonConverter(entitySchema));
            }
            return settings;
        }

        public static JsonSerializerSettings EnsureDeserializeObjectSettings(
            JsonSerializerSettings settings, 
            //IServiceProvider serviceProvider,
            EntitySchema entitySchema) {
            if (settings == null) {
                settings = new JsonSerializerSettings();
            }
            if (!(settings.Converters.Any((converter) => converter is EntityJsonConverter))) {
                if (entitySchema is null) { throw new ArgumentNullException(nameof(entitySchema), "is required to create a EntityJsonConverter."); }
                settings.Converters.Add(new EntityJsonConverter(entitySchema));
            }
            return settings;
        }
    }
}
