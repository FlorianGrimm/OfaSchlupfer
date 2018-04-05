namespace OfaSchlupfer.HttpAccess {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using OfaSchlupfer.Elementary;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;

    public class HttpClientDispatcherFactory : IHttpClientDispatcherFactory {
        public readonly IServiceProvider ServiceProvider;
        private IHttpClientTypedFactory[] _HttpClientFactories;
        private Dictionary<string, IHttpClientTypedFactory> _HttpClientFactoryByAuthenticationMode;
        // 
        public HttpClientDispatcherFactory(IServiceProvider serviceProvider) {
            this.ServiceProvider = serviceProvider;
        }

        public IHttpClientTypedFactory GetByAuthenticationMode(string authenticationMode) {
            if (this._HttpClientFactoryByAuthenticationMode == null) {
                var httpClientFactories = this._HttpClientFactories
                    ?? (this._HttpClientFactories = this.ServiceProvider.GetServices<IHttpClientTypedFactory>().ToArray());
                var dict = new Dictionary<string, IHttpClientTypedFactory>(StringComparer.OrdinalIgnoreCase);
                foreach (var httpClientFactory in httpClientFactories) {
                    var key = httpClientFactory.GetAuthenticationMode();
                    dict[key] = httpClientFactory;
                }
                this._HttpClientFactoryByAuthenticationMode = dict;
            }
            IHttpClientTypedFactory result = null;
            this._HttpClientFactoryByAuthenticationMode.TryGetValue(authenticationMode, out result);
            return result;
        }

        public IHttpClient CreateHttpClient(RepositoryConnectionString connectionString) {
            if (connectionString == null) { return null; }
            var factory = this.GetByAuthenticationMode(connectionString.AuthenticationMode);
            if (factory == null) {
                throw new NotSupportedException(connectionString.AuthenticationMode);
            }
            return factory.CreateHttpClient(connectionString);
        }
    }
}
