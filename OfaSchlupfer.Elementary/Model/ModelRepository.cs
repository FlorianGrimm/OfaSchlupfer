namespace OfaSchlupfer.Model {
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    using OfaSchlupfer.Freezable;

    [JsonObject]
    public class ModelRepository
        : FreezeableObject
        , IMappingNamedObject<string>
        , IMappingNamedObject<ModelEntityName> {
        [JsonIgnore]
        private ModelRoot _Owner;

        [JsonIgnore]
        private ModelEntityName _Name;

        [JsonIgnore]
        private IReferenceRepositoryModel _ReferenceRepositoryModel;

        [JsonIgnore]
        private ModelDefinition _ModelDefinition;

        [JsonIgnore]
        private string _RepositoryType;

        [JsonIgnore]
        private ModelSchema _ModelSchema;

        public ModelRepository() { }

        [JsonProperty]
        public ModelEntityName Name {
            get {
                return this._Name;
            }
            set {
                this.ThrowIfFrozen();
                this._Name = value;
                if (this.ModelSchema != null) {
                    this.ModelSchema._Name = value;
                }
            }
        }

        [JsonProperty]
        public ModelDefinition ModelDefinition {
            get {
                return this._ModelDefinition;
            }
            set {
                this.ThrowIfFrozen();
                this._ModelDefinition = value;
            }
        }

        [JsonProperty]
        public string RepositoryType {
            get {
                return this._RepositoryType;
            }
            set {
                this.ThrowIfFrozen();
                this._RepositoryType = value;
            }
        }

        [JsonProperty]
        public ModelSchema ModelSchema {
            get {
                return this._ModelSchema;
            }
            set {
                this.ThrowIfFrozen();
                this._ModelSchema = value;
            }
        }

        [JsonIgnore]
        public IReferenceRepositoryModel ReferenceRepositoryModel {
            get {
                return this._ReferenceRepositoryModel;
            }
            set {
                this.ThrowIfFrozen();
                this._ReferenceRepositoryModel = value;
            }
        }

        [JsonIgnore]
        public ModelRoot Owner {
            get {
                return this._Owner;
            }
            set {
                if (ReferenceEquals(this._Owner, value)) { return; }
                if ((object)this._Owner == null) { this._Owner = value; return; }
                this.ThrowIfFrozen();
                this._Owner = value;
            }
        }

        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this.Name?.Freeze();
                this.ModelDefinition?.Freeze();
                this.ModelSchema?.Freeze();
            }
            return result;
        }

        public IReferenceRepositoryModel GetReferenceRepositoryModel(IServiceProvider serviceProvider) {
            if (this.ReferenceRepositoryModel != null) { return this.ReferenceRepositoryModel; }
            if (this.RepositoryType == null) {
                return null;
            }
            {
                var rtf = new ReferenceRepositoryModelFactory(serviceProvider);
                var instance = rtf.CreateRepository(this.RepositoryType);
                var result = System.Threading.Interlocked.CompareExchange(ref this._ReferenceRepositoryModel, instance, null);
                if (ReferenceEquals(result, null)) {
                    return instance;
                } else {
                    return this.ReferenceRepositoryModel;
                }
            }
        }

        ModelEntityName IMappingNamedObject<ModelEntityName>.GetName() => this._Name;

        string IMappingNamedObject<string>.GetName() => this._Name.GetName();
    }
}
