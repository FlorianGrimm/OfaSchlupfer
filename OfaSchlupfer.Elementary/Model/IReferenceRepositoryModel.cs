﻿namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Extensions.DependencyInjection;
    using OfaSchlupfer.HttpAccess;

    public interface IReferenceRepositoryModel {
        ModelRepository ModelRepository { get; set; }

        ModelSchema ModelSchema { get; set; }

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

    public abstract class ReferenceRepositoryModelBase : IReferenceRepositoryModel {
        protected ModelRepository _ModelRepository;

        protected ModelSchema _ModelSchema;

        protected ModelDefinition _ModelDefinition;

        protected ReferenceRepositoryModelBase() { }

        public virtual ModelRepository ModelRepository {
            get {
                return this._ModelRepository;
            }
            set {
                if (ReferenceEquals(this._ModelRepository, value)) {
                    return;
                }
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

        public virtual ModelSchema ModelSchema {
            get {
                return this._ModelSchema;
            }
            set {
                if (ReferenceEquals(this._ModelSchema, value)) {
                    return;
                }
                this._ModelSchema = value;
            }
        }

        public virtual ModelDefinition ModelDefinition {
            get {
                return this._ModelDefinition;
            }
            set {
                if (ReferenceEquals(this._ModelDefinition, value)) {
                    return;
                }
                this._ModelDefinition = value;
            }
        }

        public abstract List<string> BuildSchema(string metadataContent);

    }

    public class ReferenceRepositoryModelType : IReferenceRepositoryModelType {
        public readonly IServiceProvider ServiceProvider;
        public readonly IHttpClientDispatcherFactory HttpClientDispatcherFactory;

        public ReferenceRepositoryModelType(IServiceProvider serviceProvider, IHttpClientDispatcherFactory httpClientDispatcherFactory) {
            this.ServiceProvider = serviceProvider;
            this.HttpClientDispatcherFactory = httpClientDispatcherFactory;
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
