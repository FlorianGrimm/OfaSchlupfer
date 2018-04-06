namespace OfaSchlupfer.HttpAccess {
    using Microsoft.Extensions.DependencyInjection;

    public interface IHttpClientBuilder {
        IServiceCollection Services { get; }
    }

    public class HttpClientBuilder : IHttpClientBuilder {
        public HttpClientBuilder(IServiceCollection services) {
            this.Services = services;
        }

        public IServiceCollection Services { get; }
    }

    public class HttpClientBuilderOptions {
        public Microsoft.Extensions.Logging.ILogger Logger { get; set; }
    }
}

namespace Microsoft.Extensions.DependencyInjection {
    using System;
    using OfaSchlupfer.HttpAccess;

    public static class HttpClientExtension {
        public static IHttpClientBuilder AddHttpClient(this Microsoft.Extensions.DependencyInjection.IServiceCollection services) => AddHttpClient(services, _ => { });
        public static IHttpClientBuilder AddHttpClient(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, Action<HttpClientBuilderOptions> configure) {
            services.Configure(configure);
            services.AddSingleton(typeof(OfaSchlupfer.HttpAccess.IHttpClientDispatcherFactory), typeof(HttpClientDispatcherFactory));
            services.AddTransient<IHttpClientTypedFactory, HttpClientDefaultFactory>();
            return new HttpClientBuilder(services);
        }
    }
}