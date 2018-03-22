namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Extensions.DependencyInjection;

    public interface IRepository {
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

    public abstract class RepositoryBase : IRepository {
        protected ModelRepository _ModelRepository;

        protected ModelSchema _ModelSchema;

        protected ModelDefinition _ModelDefinition;

        protected RepositoryBase() { }

        public virtual ModelRepository ModelRepository {
            get {
                return this._ModelRepository;
            }
            set {
                if (ReferenceEquals(this._ModelRepository, value)) {
                    return;
                }
                if ((object)this._ModelRepository != null) {
                    if (ReferenceEquals(this._ModelRepository.Repository, this)) {
                        this._ModelRepository.Repository = null;
                    }
                }
                this._ModelRepository = value;
                if ((object)this._ModelRepository != null) {
                    if (ReferenceEquals(this._ModelRepository.Repository, null)) {
                        this._ModelRepository.Repository = this;
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

    public class RepositoryType : IRepositoryType {
        public readonly IServiceProvider ServiceProvider;

        public RepositoryType(IServiceProvider serviceProvider) {
            this.ServiceProvider = serviceProvider;
            this.Description = this.Name = this.GetType().Name;
        }

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public virtual IRepository CreateRepository() {
            return null;
        }
    }

    public class RepositoryTypeFactory {
        public IServiceProvider ServiceProvider { get; }

        public RepositoryTypeFactory(IServiceProvider serviceProvider) {
            this.ServiceProvider = serviceProvider;
        }

        public List<IRepositoryType> GetRepositoryTypes()
            => this.ServiceProvider.GetServices<IRepositoryType>().ToList();

        public IRepository CreateRepository(string name) {
            var repositoryType = this.ServiceProvider.GetServices<IRepositoryType>().FirstOrDefault(_ => string.Equals(_.Name, name, StringComparison.OrdinalIgnoreCase));
            if (repositoryType != null) {
                return repositoryType.CreateRepository();
            }
            return null;
        }
    }
}
