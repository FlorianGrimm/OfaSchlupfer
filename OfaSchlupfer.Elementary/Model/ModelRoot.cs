namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using OfaSchlupfer.Freezable;

    /// <summary>
    /// Tenant global root of all models.
    /// </summary>
    [JsonObject]
    public class ModelRoot
        : FreezableObject {
        [JsonIgnore]
        IServiceProvider _ServiceProvider;

        [JsonIgnore]
        private string _Name;

        [JsonIgnore]
        private readonly FreezableOwnedKeyedCollection<ModelRoot, string, ModelRepository> _Repositories;

        [JsonIgnore]
        private readonly FreezableOwnedKeyedCollection<ModelRoot, string, MappingModelRepository> _RepositoryMappings;

        public ModelRoot() {
            this._Repositories = new FreezableOwnedKeyedCollection<ModelRoot, string, ModelRepository>(
                this, (item) => item.Name,
                ModelUtility.Instance.StringComparer,
                (that, item) => { item.Owner = that; });
            this._RepositoryMappings = new FreezableOwnedKeyedCollection<ModelRoot, string, MappingModelRepository>(
                this, (item) => item.Name,
                ModelUtility.Instance.StringComparer,
                (that, item) => { item.Owner = that; });
        }

        public MappingModelRepository CreateMapping(
            string name,
            ModelRepository source,
            ModelRepository target) {
            var result = new MappingModelRepository();
            if (name is null) {
                if (!(source is null)
                    && !(target is null)
                    && !(source.Name is null)
                    && !(target.Name is null)
                ) {
                    name = source.Name + target.Name;
                } else {
                    name = DateTime.Now.ToString("s");
                }
            }
            result.Name = name;
            result.Source = source;
            result.Target = target;
            this.RepositoryMappings.Add(result);
            return result;
        }

        public ModelRoot(IServiceProvider serviceProvider) : this() {
            this.ServiceProvider = serviceProvider;
        }

        public ModelRepository CreateRepository(string name, string repositoryType) {
            var result = new ModelRepository {
                Name = name,
                RepositoryTypeName = repositoryType
            };
            this.Repositories.Add(result);
            return result;
        }

        [JsonIgnore]
        public IServiceProvider ServiceProvider {
            get => this._ServiceProvider;
            set => this.SetRefPropertyOnce<IServiceProvider>(ref this._ServiceProvider, value);
        }

        [JsonProperty(Order = 1)]
        public string Name {
            get => this._Name;
            set => this.SetStringProperty(ref this._Name, value);
        }

        [JsonProperty(Order = 2)]
        public FreezableOwnedKeyedCollection<ModelRoot, string, ModelRepository> Repositories => this._Repositories;

        [JsonProperty(Order = 3)]
        public FreezableOwnedKeyedCollection<ModelRoot, string, MappingModelRepository> RepositoryMappings => this._RepositoryMappings;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public string SerializeToJson(JsonSerializerSettings settings) {
            settings = EnsureSerializeObjectSettings(settings);
            var result = JsonConvert.SerializeObject(this, settings);
            return result;
        }

        public static ModelRoot DeserializeFromJson(string json, JsonSerializerSettings settings, IServiceProvider serviceProvider) {
            settings = EnsureDeserializeObjectSettings(settings, serviceProvider);
            var result = JsonConvert.DeserializeObject<ModelRoot>(json, settings);
            return result;
        }

        public static JsonSerializerSettings EnsureSerializeObjectSettings(JsonSerializerSettings settings) {
            if (settings == null) {
                settings = new JsonSerializerSettings();
            }
            //if (!(settings.Converters.Any((converter) => converter is ModelRooCreationConverter))) {
            //    settings.Converters.Add(new ModelRooCreationConverter(serviceProvider));
            //}
            return settings;
        }

        public static JsonSerializerSettings EnsureDeserializeObjectSettings(JsonSerializerSettings settings, IServiceProvider serviceProvider) {
            if (settings == null) {
                settings = new JsonSerializerSettings();
            }
            if (!(settings.Converters.Any((converter) => converter is ModelRootCreationConverter))) {
                if (serviceProvider is null) { throw new ArgumentNullException(nameof(serviceProvider), "is required to create a ModelRooCreationConverter."); }
                settings.Converters.Add(new ModelRootCreationConverter(serviceProvider));
            }
            return settings;
        }

        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this._Repositories.Freeze();
                this._RepositoryMappings.Freeze();
            }
            return result;
        }
    }

    public class ModelRootCreationConverter : CustomCreationConverter<ModelRoot> {
        public readonly IServiceProvider ServiceProvider;
        public ModelRootCreationConverter(IServiceProvider serviceProvider) {
            this.ServiceProvider = serviceProvider;
        }

        public override ModelRoot Create(Type objectType) {
            return (this.ServiceProvider.GetService<ModelRoot>())
                ?? (new ModelRoot(this.ServiceProvider));
        }
    }
}
