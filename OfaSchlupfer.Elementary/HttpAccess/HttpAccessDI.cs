namespace OfaSchlupfer.HttpAccess {
    using System.Collections.Generic;
    using Microsoft.Extensions.DependencyInjection;

    public interface IServiceClientCredentialsBuilder {
        IServiceCollection Services { get; }
    }

    public class ServiceClientCredentialsBuilder : IServiceClientCredentialsBuilder {
        public ServiceClientCredentialsBuilder(IServiceCollection services) {
            this.Services = services;
        }

        public IServiceCollection Services { get; }
    }

    public class ServiceClientCredentialsOptions {
        public ServiceClientCredentialsOptions() {
            this.Factories = new List<IServiceClientCredentialsConcreteFactory>();
        }

        public Microsoft.Extensions.Logging.ILogger Logger { get; set; }

        public List<IServiceClientCredentialsConcreteFactory> Factories { get; }
    }
}

namespace Microsoft.Extensions.DependencyInjection {
    using System;
    using OfaSchlupfer.HttpAccess;

    public static class HttpServiceClientExtension {
        public static IServiceClientCredentialsBuilder AddServiceClientCredentials(this Microsoft.Extensions.DependencyInjection.IServiceCollection services) => AddServiceClientCredentials(services, _ => { });
        public static IServiceClientCredentialsBuilder AddServiceClientCredentials(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, Action<ServiceClientCredentialsOptions> configure) {
            services.Configure(configure);
            services.AddSingleton(typeof(IServiceClientCredentialsDispatcherFactory), typeof(ServiceClientCredentialsDispatcherFactory));
            //services.AddTransient<IHttpClientTypedFactory, HttpClientDefaultFactory>();
            return new ServiceClientCredentialsBuilder(services);
        }
    }
}