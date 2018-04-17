namespace OfaSchlupfer.Model {
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using OfaSchlupfer.Entitiy;
    using OfaSchlupfer.Freezable;

    [JsonObject]
    public class ModelRepository
        : ModelNamedOwnedElement<ModelRoot>
        //, IMappingNamedObject<string>
        //, IMappingNamedObject<ModelEntityName> 
        {
        [JsonIgnore]
        private IReferenceRepositoryModel _ReferenceRepositoryModel;

        [JsonIgnore]
        private ModelDefinition _ModelDefinition;

        [JsonIgnore]
        private string _RepositoryType;

        [JsonIgnore]
        private ModelSchema _ModelSchema;

#warning TODO soon _EndPoint;
        //[JsonIgnore]
        //private readonly FreezeableOwnedKeyedCollection<ModelRepository, string, ModelRepositoryEndPoint> _EndPoint;

        public ModelRepository() {

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
                if (ReferenceEquals(this._ModelSchema, value)) { return; }
                if (ReferenceEquals(this._ModelSchema, this)) {
                    this._ModelSchema.Owner = null;
                }
                this._ModelSchema = value;
                if (this._ModelSchema != null) {
                    this._ModelSchema.Owner = this;
                }
            }
        }

        [JsonIgnore]
        public IReferenceRepositoryModel ReferenceRepositoryModel {
            get {
                return this._ReferenceRepositoryModel;
            }
            set {
                if (ReferenceEquals(this._ReferenceRepositoryModel, value)) {
                    return;
                }
                if (this._ReferenceRepositoryModel != null) {
                    this.ThrowIfFrozen();
                }
                this._ReferenceRepositoryModel = value;
                if (value != null) {
                    if (this.RepositoryType == null) {
                        this._RepositoryType = value.GetModelTypeName();
                    }
#warning later check this._RepositoryType = value.GetModelTypeName();
                }
            }
        }

        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
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

        public IEntity CreateEntityByExternalTypeName(string externalTypeName) {
            //var referenceRepositoryModel = this.GetReferenceRepositoryModel(serviceProvider);
            //return referenceRepositoryModel.CreateEntityByExternalTypeName(externalTypeName);
            //IEntity CreateEntityByExternalTypeName(string externalTypeName);
            var complexType = this.ModelSchema.FindComplexType(externalTypeName);
            
            //return this.ModelSchema.CreateEntityByExternalTypeName(externalTypeName);
        }

        //ModelEntityName IMappingNamedObject<ModelEntityName>.GetName() => this._Name;
        //string IMappingNamedObject<string>.GetName() => this._Name.GetName();
    }
}
