namespace OfaSchlupfer.Model {
    using System;

    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;

    /// <summary>
    /// Defines the metadata
    /// </summary>
    [JsonObject]
    public sealed class ModelDefinition
        : FreezeableObject 
        , IObjectWithOwner<ModelRepository>
        {
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
            set => this.SetOwner(ref _Owner, value);
        }

        [JsonProperty(Order = 1)]
        public string RepositoryTypeName {
            get {
                return this._RepositoryType;
            }
            set {
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._RepositoryType, value, StringComparison.Ordinal)) { return; }
                this.ThrowIfFrozen();
                this._RepositoryType = value;
            }
        }

        [JsonProperty(Order = 2)]
        public string MetaData {
            get {
                return this._MetaData;
            }
            set {
                this.ThrowIfFrozen();
                this._MetaData = value;
            }
        }    
    }
}
