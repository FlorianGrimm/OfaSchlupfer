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

    public interface IReferenceRepositoryModel
        : IFreezeable {
        string GetModelTypeName();

        ModelRepository ModelRepository { get; set; }

        ModelSchema ModelSchema { get; set; }

        ModelSchema GetModelSchema();

        ModelDefinition ModelDefinition { get; set; }

        // subject to change.

        /// <summary>
        /// BuildSchema
        /// </summary>
        /// <param name="metadataContent">the content</param>
        /// <returns>a list of errors.</returns>
        List<string> BuildSchema(string metadataContent);
    }

    public interface IReferenceRepositoryModelType {
        string Name { get; }
        string Description { get; }
        IReferenceRepositoryModel CreateReferenceRepositoryModel();
    }

    public abstract class ReferenceRepositoryModelBase
        : FreezeableObject
        , IReferenceRepositoryModel {
        protected ModelRepository _ModelRepository;

        protected ModelSchema _ModelSchema;

        protected ModelDefinition _ModelDefinition;

        protected ReferenceRepositoryModelBase() {
        }

        public abstract string GetModelTypeName();

        public abstract IEntity CreateEntityByExternalTypeName(string externalTypeName);

        [JsonIgnore]
        public virtual ModelRepository ModelRepository {
            get {
                return this._ModelRepository;
            }
            set {
                if (ReferenceEquals(this._ModelRepository, value)) { return; }
                this.ThrowIfFrozen();
                if ((object)this._ModelRepository != null) {
                    if (ReferenceEquals(this._ModelRepository.ReferenceRepositoryModel, this)) {
                        this._ModelRepository.ReferenceRepositoryModel = null;
                    }
                }
                this._ModelRepository = value;
                if ((object)this._ModelRepository != null) {
                    if (ReferenceEquals(this._ModelRepository.ReferenceRepositoryModel, null)) {
                        this._ModelRepository.ReferenceRepositoryModel = this;
                    }
                }
            }
        }

        [JsonIgnore]
        public virtual ModelSchema ModelSchema {
            get {
                if (this._ModelSchema == null) {
                    if (this.ModelRepository != null) {
                        this._ModelSchema = this.ModelRepository.ModelSchema;
                    }
                }
                return this._ModelSchema;
            }
            set {
                if (ReferenceEquals(this._ModelSchema, value)) { return; }
                this.ThrowIfFrozen();
                this._ModelSchema = value;
                if (this._ModelRepository != null) {
                    this._ModelRepository.ModelSchema = value;
                }
            }
        }

        public abstract ModelSchema GetModelSchema();

        [JsonIgnore]
        public virtual ModelDefinition ModelDefinition {
            get {
                return this._ModelDefinition;
            }
            set {
                if (ReferenceEquals(this._ModelDefinition, value)) { return; }
                this.ThrowIfFrozen();
                this._ModelDefinition = value;
            }
        }

        public abstract List<string> BuildSchema(string metadataContent);

        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this._ModelRepository?.Freeze();
                this._ModelSchema?.Freeze();
                this._ModelDefinition?.Freeze();
            }
            return result;
        }
    }

    public class ReferenceRepositoryModelType : IReferenceRepositoryModelType {
        public readonly IServiceProvider ServiceProvider;

        public ReferenceRepositoryModelType(IServiceProvider serviceProvider) {
            this.ServiceProvider = serviceProvider;
            this.Description = this.Name = this.GetType().Name;
        }

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public virtual IReferenceRepositoryModel CreateReferenceRepositoryModel() {
            return null;
        }
    }

    public class ReferenceRepositoryModelFactory {
        public IServiceProvider ServiceProvider { get; }

        public ReferenceRepositoryModelFactory(IServiceProvider serviceProvider) {
            this.ServiceProvider = serviceProvider;
        }

        public List<IReferenceRepositoryModelType> GetRepositoryTypes()
            => this.ServiceProvider.GetServices<IReferenceRepositoryModelType>().ToList();

        public IReferenceRepositoryModel CreateRepository(string name) {
            var repositoryType = this.ServiceProvider.GetServices<IReferenceRepositoryModelType>().FirstOrDefault(_ => string.Equals(_.Name, name, StringComparison.OrdinalIgnoreCase));
            if (repositoryType != null) {
                return repositoryType.CreateReferenceRepositoryModel();
            }
            return null;
        }
    }
}
