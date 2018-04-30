namespace OfaSchlupfer.Model {
    using System;

    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;

    /// <summary>
    /// Defines the metadata
    /// </summary>
    [JsonObject]
    public sealed class ModelDefinition
        : FreezableObject
        , IObjectWithOwner<ModelRepository> {
        [JsonIgnore]
        private ModelRepository _Owner;

        [JsonIgnore]
        private string _MetaData;

        [JsonIgnore]
        private string _RepositoryType;

        public ModelDefinition() { }

        [JsonIgnore]
        public ModelRepository Owner {
            get => this._Owner;
            set => this.SetOwner(ref this._Owner, value);
        }

        [JsonProperty(Order = 1)]
        public string RepositoryTypeName {
            get => this._RepositoryType;
            set => this.SetStringProperty(ref this._RepositoryType, value);
        }

        [JsonProperty(Order = 2)]
        public string MetaData {
            get => this._MetaData;
            set => this.SetStringProperty(ref this._MetaData, value);
        }
    }
}
