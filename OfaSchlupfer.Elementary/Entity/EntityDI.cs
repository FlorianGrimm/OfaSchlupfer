namespace OfaSchlupfer.Entity {
    using System.Collections.Generic;
    using Microsoft.Extensions.DependencyInjection;

    public interface IEntityBuilder {
        IServiceCollection Services { get; }
    }

    public class EntityBuilder : IEntityBuilder {
        public EntityBuilder(IServiceCollection services) {
            this.Services = services;
        }

        public IServiceCollection Services { get; }
    }

    public class EntityOptions {
        public EntityOptions() {
            this.Factories = new List<IEntityConcreteFactory>();
        }

        public Microsoft.Extensions.Logging.ILogger Logger { get; set; }

        public List<IEntityConcreteFactory> Factories { get; }
    }
}

namespace Microsoft.Extensions.DependencyInjection {
    using System;
    using OfaSchlupfer.Entity;

    public static class HttpServiceClientExtension {
        public static IEntityBuilder AddEntity(this Microsoft.Extensions.DependencyInjection.IServiceCollection services) => AddEntity(services, _ => { });
        public static IEntityBuilder AddEntity(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, Action<EntityOptions> configure) {
            services.Configure(configure);
            services.AddSingleton(typeof(IEntityDispatcherFactory), typeof(EntityDispatcherFactory));
            //services.AddTransient<IHttpClientTypedFactory, HttpClientDefaultFactory>();
            return new EntityBuilder(services);
        }
    }
}