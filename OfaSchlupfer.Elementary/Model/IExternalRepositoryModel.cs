namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Extensions.DependencyInjection;

    using Newtonsoft.Json;

    using OfaSchlupfer.HttpAccess;
    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.Entity;
    using OfaSchlupfer.Elementary;

    public interface IExternalRepositoryModel
        : IFreezeable
        , IObjectWithOwner<ModelRepository> {
        string GetRepositoryTypeName();
        
        // IObjectWithOwner<ModelRepository> defines ModelRepository Owner { get; set; }

        RepositoryConnectionString ConnectionString { get; set; }

        ModelSchema ModelSchema { get; set; }

        ModelSchema GetModelSchema(MetaModelBuilder metaModelBuilder, ModelErrors errors);

        ModelDefinition ModelDefinition { get; set; }

        // subject to change.

        /// <summary>
        /// BuildSchema
        /// </summary>
        /// <param name="metadataContent">the content</param>
        /// <returns>a list of errors.</returns>
        List<string> BuildSchema(string metadataContent);

        IModelBuilderNamingService GetNamingService(MappingModelRepository mappingModelRepository);
    }

    public interface IExternalRepositoryModelType {
        string Name { get; }
        string Description { get; }
        IExternalRepositoryModel CreateExternalRepositoryModel();
    }

    public abstract class ExternalRepositoryModelBase
        : FreezableObject
        , IExternalRepositoryModel {
        [JsonIgnore]
        protected ModelRepository _Owner;

        [JsonIgnore]
        protected ModelSchema _ModelSchema;

        [JsonIgnore]
        protected ModelDefinition _ModelDefinition;

        protected ExternalRepositoryModelBase() {
        }

        [JsonProperty]
        public RepositoryConnectionString ConnectionString { get; set; }

        public abstract string GetRepositoryTypeName();

        public abstract IEntity CreateEntityByExternalTypeName(string externalTypeName);

        [JsonIgnore]
        public virtual ModelRepository Owner {
            get {
                return this._Owner;
            }
            set {
                if (ReferenceEquals(this._Owner, value)) { return; }
                if (!(this._Owner is null)) { this.ThrowIfFrozen(); }
                if ((object)this._Owner != null) {
                    if (ReferenceEquals(this._Owner.ReferencedRepositoryModel, this)) {
                        this._Owner.ReferencedRepositoryModel = null;
                    }
                }
                this._Owner = value;
                if ((object)this._Owner != null) {
                    if (this._Owner.ReferencedRepositoryModel is null) {
                        this._Owner.ReferencedRepositoryModel = this;
                    }
                }
            }
        }

        [JsonIgnore]
        public virtual ModelSchema ModelSchema {
            get {
                if (this._Owner is null) {
                    return this._ModelSchema;
                } else {
                    return this._Owner.ModelSchema;
                }
            }
            set {
                if (this.SetRefProperty(ref this._ModelSchema, value)) {
                    if (this._Owner != null) {
                        this._Owner.ModelSchema = value;
                    }
                }
            }
        }

        public abstract ModelSchema GetModelSchema(MetaModelBuilder metaModelBuilder, ModelErrors errors);

        [JsonIgnore]
        public virtual ModelDefinition ModelDefinition {
            get {
                if (this._Owner is null) {
                    return this._ModelDefinition;
                } else {
                    return this._Owner.ModelDefinition;
                }
            }
            set {
                if (this.SetRefProperty(ref this._ModelDefinition, value)) {
                    if (!(value is null) && !(this._Owner is null)) {
                        this._Owner.ModelDefinition = value;
                    }
                }
            }
        }

        public abstract List<string> BuildSchema(string metadataContent);
        
        public virtual IModelBuilderNamingService GetNamingService(MappingModelRepository mappingModelRepository) => new ModelBuilderNamingService(mappingModelRepository);

        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this._Owner?.Freeze();
                this._ModelSchema?.Freeze();
                this._ModelDefinition?.Freeze();
            }
            return result;
        }
    }

    public class ExternalRepositoryModelType : IExternalRepositoryModelType {
        public readonly IServiceProvider ServiceProvider;

        public ExternalRepositoryModelType(IServiceProvider serviceProvider) {
            this.ServiceProvider = serviceProvider;
            this.Description = this.Name = this.GetType().Name;
        }

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public virtual IExternalRepositoryModel CreateExternalRepositoryModel() {
            return null;
        }
    }

    public class ExternalRepositoryModelFactory {
        public IServiceProvider ServiceProvider { get; }

        public ExternalRepositoryModelFactory(IServiceProvider serviceProvider) {
            this.ServiceProvider = serviceProvider;
        }

        public List<IExternalRepositoryModelType> GetRepositoryTypes()
            => this.ServiceProvider.GetServices<IExternalRepositoryModelType>().ToList();

        public IExternalRepositoryModel CreateRepository(string name) {
            var repositoryType = this.ServiceProvider.GetServices<IExternalRepositoryModelType>().FirstOrDefault(_ => string.Equals(_.Name, name, StringComparison.OrdinalIgnoreCase));
            if (repositoryType != null) {
                return repositoryType.CreateExternalRepositoryModel();
            }
            return null;
        }
    }
}
