namespace OfaSchlupfer.Model {
    using System;

    using Microsoft.Extensions.DependencyInjection;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    using OfaSchlupfer.Entity;
    using OfaSchlupfer.Freezable;

    [JsonObject]
    public class ModelRepository
        : ModelNamedOwnedElement<ModelRoot>
        //, IMappingNamedObject<string>
        //, IMappingNamedObject<ModelEntityName> 
        {
        [JsonIgnore]
        private IReferencedRepositoryModel _ReferencedRepositoryModel;

        [JsonIgnore]
        private ModelDefinition _ModelDefinition;

        [JsonIgnore]
        private string _RepositoryTypeName;

        [JsonIgnore]
        private ModelSchema _ModelSchema;

#warning TODO soon _EndPoint;
        //[JsonIgnore]
        //private readonly FreezeableOwnedKeyedCollection<ModelRepository, string, ModelRepositoryEndPoint> _EndPoint;

        public ModelRepository() {
        }

        [JsonProperty]
        public ModelDefinition ModelDefinition {
            get => this._ModelDefinition;
            set => this.SetPropertyAndOwner<ModelRepository, ModelDefinition>(ref this._ModelDefinition, value);
        }

        [JsonProperty]
        public string RepositoryTypeName {
            get {
                if (!(this._ReferencedRepositoryModel is null)) {
                    return this._ReferencedRepositoryModel.GetRepositoryTypeName();
                }
                if (!(this._ModelDefinition is null)) {
                    return this._ModelDefinition.RepositoryTypeName;
                }
                return this._RepositoryTypeName;
            }
            set {
#warning HEERERERERERE                
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._RepositoryTypeName, value, StringComparison.Ordinal)) { return; }
                this.ThrowIfFrozen();
                this._RepositoryTypeName = value;
            }
        }

        [JsonProperty]
        public ModelSchema ModelSchema {
            get => this._ModelSchema;
            set => this.SetPropertyAndOwner(ref this._ModelSchema, value);
        }

        public ModelSchema GetModelSchema() {
            var result = this.ModelSchema;
            if (result == null) {
                if (this.ReferencedRepositoryModel != null) {
                    return this.ReferencedRepositoryModel.GetModelSchema();
                }
            }
            return result;
        }

        [JsonIgnore]
        public IReferencedRepositoryModel ReferencedRepositoryModel {
            get {
                return this._ReferencedRepositoryModel;
            }
            set {
#warning HERERERERER
                if (ReferenceEquals(this._ReferencedRepositoryModel, value)) {
                    return;
                }
                if (this._ReferencedRepositoryModel != null) {
                    this.ThrowIfFrozen();
                }
                this._ReferencedRepositoryModel = value;
                if (value != null) {
                    //if (this.RepositoryTypeName == null) {
                    //    this._RepositoryTypeName = value.GetRepositoryTypeName();
                    //}
#warning later check this._RepositoryType = value.GetModelTypeName();
                    value.ModelRepository = this;
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

        public IReferencedRepositoryModel GetReferenceRepositoryModel() {
            if (this.ReferencedRepositoryModel != null) { return this.ReferencedRepositoryModel; }
            if (this.RepositoryTypeName == null) {
                return null;
            }
            {
                if (this.Owner is null) { throw new ModelException("Owner is not set."); }
                var rtf = (this.Owner.ServiceProvider.GetService<ReferencedRepositoryModelFactory>())
                    ?? (new ReferencedRepositoryModelFactory(this.Owner.ServiceProvider));
                var instance = rtf.CreateRepository(this.RepositoryTypeName);
                var result = System.Threading.Interlocked.CompareExchange(ref this._ReferencedRepositoryModel, instance, null);
                if (ReferenceEquals(result, null)) {
                    return instance;
                } else {
                    return this.ReferencedRepositoryModel;
                }
            }
        }
        
        public ModelDefinition CreateModelDefinition(string repositoryType) {
            if (repositoryType is null) {
                if (this.RepositoryTypeName is null) {
                    //OK
                } else {
                    repositoryType = this.RepositoryTypeName;
                }
            }
            var result = new ModelDefinition();
            result.RepositoryTypeName = repositoryType;
            this.ModelDefinition = result;
            return result;
        }

#warning CreateEntityByExternalTypeName
        public IEntity CreateEntityByExternalTypeName(string externalTypeName) {
            //var referenceRepositoryModel = this.GetReferenceRepositoryModel(serviceProvider);
            //return referenceRepositoryModel.CreateEntityByExternalTypeName(externalTypeName);
            //IEntity CreateEntityByExternalTypeName(string externalTypeName);
            var lstComplexType = this.ModelSchema.ComplexTypes.FindByKey2(externalTypeName);
            if (lstComplexType.Count > 0) {
                var metaEntity = lstComplexType[0].GetMetaEntity();

                return new EntityFlexible(metaEntity, null);
            }
            //return this.ModelSchema.CreateEntityByExternalTypeName(externalTypeName);
            return null;
        }

        //ModelEntityName IMappingNamedObject<ModelEntityName>.GetName() => this._Name;
        //string IMappingNamedObject<string>.GetName() => this._Name.GetName();
    }
}
