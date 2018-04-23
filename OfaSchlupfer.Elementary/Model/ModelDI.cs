namespace OfaSchlupfer.Model {
    using System.Collections.Generic;
    using Microsoft.Extensions.DependencyInjection;

    public interface IModelBuilder {
        IServiceCollection Services { get; }
    }

    public class EntityBuilder : IModelBuilder {
        public EntityBuilder(IServiceCollection services) {
            this.Services = services;
        }

        public IServiceCollection Services { get; }
    }

    public class EntityOptions {
        public EntityOptions() {
          //  this.Factories = new List<IEntityConcreteFactory>();
        }

        public Microsoft.Extensions.Logging.ILogger Logger { get; set; }

        //public List<IEntityConcreteFactory> Factories { get; }
    }
}

namespace Microsoft.Extensions.DependencyInjection {
    using System;

    using Microsoft.Extensions.DependencyInjection.Extensions;

    using OfaSchlupfer.Model;

    public static class ModelExtension {
        public static IModelBuilder AddOfaSchlupferModel(this Microsoft.Extensions.DependencyInjection.IServiceCollection services) => AddOfaSchlupferModel(services, _ => { });
        public static IModelBuilder AddOfaSchlupferModel(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, Action<EntityOptions> configure) {
            services.Configure(configure);
            //services.AddSingleton(typeof(IEntityDispatcherFactory), typeof(EntityDispatcherFactory));
            
            services.TryAddScoped<ExternalRepositoryModelFactory>();
            services.TryAddScoped<ModelRoot>();
            services.AddTransient<ModelRepository>();
            services.AddTransient<ModelDefinition>();

            //services.AddTransient<CachedMetadataResolver>();

            return new EntityBuilder(services);
        }
    }
}