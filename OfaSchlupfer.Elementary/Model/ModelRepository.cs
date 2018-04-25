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
        private IExternalRepositoryModel _ReferencedRepositoryModel;

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

        public override ModelRoot Owner {
            get => this._Owner;
            set => this.SetOwner(ref _Owner, value, (owner) => owner.Repositories);
        }

        [JsonProperty(Order = 4)]
        public ModelDefinition ModelDefinition {
            get => this._ModelDefinition;
            set => this.SetPropertyAndOwner<ModelRepository, ModelDefinition>(ref this._ModelDefinition, value);
        }

        [JsonProperty(Order = 3)]
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
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._RepositoryTypeName, value, StringComparison.Ordinal)) { return; }
                this.ThrowIfFrozen();
                this._RepositoryTypeName = value;
                if (!(this.ReferencedRepositoryModel is null)) {
                    if (string.Equals(this.ReferencedRepositoryModel.GetRepositoryTypeName(), value, StringComparison.OrdinalIgnoreCase)) {
                        //OK 
                    } else {
                        // the type doesn't match
                        this.ReferencedRepositoryModel = null;
                    }
                }
                if (!(this.ModelDefinition is null)) {
                    if (string.Equals(this.ModelDefinition.RepositoryTypeName, value, StringComparison.OrdinalIgnoreCase)) {
                        //OK 
                    } else {
                        // the type doesn't match
                        this.ModelDefinition = null;
                    }
                }
            }
        }

        public ModelSchema CreateModelSchema(string name) {
            var result = new ModelSchema();
            result.Name = name ?? this.Name;
            this.ModelSchema = result;
            return result;
        }

        [JsonProperty(Order = 5)]
        public ModelSchema ModelSchema {
            get => this._ModelSchema;
            set {
                if (this.SetPropertyAndOwner(ref this._ModelSchema, value)) {
                }
            }
        }

        public ModelSchema GetModelSchema(MetaModelBuilder metaModelBuilder, ModelErrors errors) {
            var result = this.ModelSchema;
            if (result == null) {
                if (this.ReferencedRepositoryModel != null) {
                    result = this.ReferencedRepositoryModel.GetModelSchema(metaModelBuilder, errors);
                    this.ModelSchema = result;
                    return result;
                }
            }
            return result;
        }

        [JsonIgnore]
        public IExternalRepositoryModel ReferencedRepositoryModel {
            get {
                return this._ReferencedRepositoryModel;
            }
            set {
                if (ReferenceEquals(this._ReferencedRepositoryModel, value)) { return; }
                if (this._ReferencedRepositoryModel != null) { this.ThrowIfFrozen(); }
                var oldValue = this._ReferencedRepositoryModel;

                this._ReferencedRepositoryModel = value;

                if (!(value is null)) {
                    this._RepositoryTypeName = value.GetRepositoryTypeName();
                    value.Owner = this;
                }
                if (!(oldValue is null)) {
                    if (ReferenceEquals(oldValue.Owner, this)) {
                        oldValue.Owner = null;
                    }
                }
                if (!(this.ModelDefinition is null)) {
                    if (string.Equals(this.ModelDefinition.RepositoryTypeName, value.GetRepositoryTypeName(), StringComparison.OrdinalIgnoreCase)) {
                        //OK 
                    } else {
                        // the type doesn't match
                        this.ModelDefinition = null;
                    }
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

        public IExternalRepositoryModel GetReferenceRepositoryModel() {
            if (this.ReferencedRepositoryModel != null) { return this.ReferencedRepositoryModel; }
            if (this.RepositoryTypeName == null) {
                return null;
            }
            {
                if (this.Owner is null) { throw new ModelException("Owner is not set."); }
                var rtf = (this.Owner.ServiceProvider.GetService<ExternalRepositoryModelFactory>())
                    ?? (new ExternalRepositoryModelFactory(this.Owner.ServiceProvider));
                var result = rtf.CreateRepository(this.RepositoryTypeName);
                this.ReferencedRepositoryModel = result;
                return result;
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

        public IModelBuilderNamingService GetNamingService() => this.ReferencedRepositoryModel?.GetNamingService();
    }
}
