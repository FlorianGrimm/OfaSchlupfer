namespace OfaSchlupfer.HttpAccess {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using OfaSchlupfer.Elementary;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;
    using System.Net;

    public class HttpClientDispatcherFactory 
        : IHttpClientDispatcherFactory 
        , IHttpClientCredentialsDispatcherFactory {
        public readonly IServiceProvider ServiceProvider;
        private IHttpClientTypedFactory[] _HttpClientFactories;
        private IHttpClientCredentialsTypedFactory[] _HttpClientCredentialsFactories;
        private Dictionary<string, IHttpClientTypedFactory> _HttpClientFactoryByAuthenticationMode;
        private Dictionary<string, IHttpClientCredentialsTypedFactory> _HttpClientCredentialsTypedFactoryByAuthenticationMode;
        // 
        public HttpClientDispatcherFactory(IServiceProvider serviceProvider) {
            this.ServiceProvider = serviceProvider;
        }

        public IHttpClientTypedFactory GetHttpClientTypedFactoryByAuthenticationMode (string authenticationMode) {
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

        public IHttpClientCredentialsTypedFactory GetHttpClientCredentialsTypedFactoryByAuthenticationMode(string authenticationMode) {
            if (this._HttpClientCredentialsTypedFactoryByAuthenticationMode == null) {
                var httpClientCredentialsFactories = this._HttpClientCredentialsFactories
                    ?? (this._HttpClientCredentialsFactories = this.ServiceProvider.GetServices<IHttpClientCredentialsTypedFactory>().ToArray());
                var dict = new Dictionary<string, IHttpClientCredentialsTypedFactory>(StringComparer.OrdinalIgnoreCase);
                foreach (var httpClientCredentialsFactory in httpClientCredentialsFactories) {
                    var key = httpClientCredentialsFactory.GetAuthenticationMode();
                    dict[key] = httpClientCredentialsFactory;
                }
                this._HttpClientCredentialsTypedFactoryByAuthenticationMode = dict;
            }
            IHttpClientCredentialsTypedFactory result = null;
            this._HttpClientCredentialsTypedFactoryByAuthenticationMode.TryGetValue(authenticationMode, out result);
            return result;
        }

        public IHttpClient CreateHttpClient(RepositoryConnectionString connectionString) {
            if (connectionString == null) { return null; }
            var factory = this.GetHttpClientTypedFactoryByAuthenticationMode(connectionString.AuthenticationMode);
            IHttpClientCredentials todo = null;
            if (factory != null) {
                return factory.CreateHttpClient(connectionString, todo);
            } else {
                factory = this.GetHttpClientTypedFactoryByAuthenticationMode("Default");
                if (factory != null) {
                    return factory.CreateHttpClient(connectionString, todo);
                } else {
                    //return new HttpClientImplementation(connectionString);
                    return null;
                }
            }
        }

        public IHttpClientCredentials CreateHttpClientCredentials(RepositoryConnectionString connectionString) {
            throw new NotImplementedException();
        }

        public IHttpClient CreateHttpClient(RepositoryConnectionString connectionString, IHttpClientCredentials credentials) {
            throw new NotImplementedException();
        }
    }

    public class HttpClientDefaultFactory : IHttpClientTypedFactory {

        public IHttpClient CreateHttpClient(RepositoryConnectionString connectionString, IHttpClientCredentials credentials) {
            var url = connectionString.GetUrlNormalized();
            var result = new HttpClientImplementation(url, credentials);
            return result;
        }

        public string GetAuthenticationMode() => "Default";
    }
}
