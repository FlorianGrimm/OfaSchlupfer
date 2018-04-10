namespace OfaSchlupfer.HttpAccess {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using OfaSchlupfer.Elementary;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;
    using System.Net;

    public class HttpClientDispatcherFactory
        : IHttpClientDispatcherFactory {
        public readonly IServiceProvider ServiceProvider;
        private IHttpClientTypedFactory[] _HttpClientFactories;
        private Dictionary<string, IHttpClientTypedFactory> _HttpClientFactoryByAuthenticationMode;

        public HttpClientDispatcherFactory(IServiceProvider serviceProvider) {
            this.ServiceProvider = serviceProvider;
        }

        public IHttpClientTypedFactory GetHttpClientTypedFactoryByAuthenticationMode(string authenticationMode) {
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

        public IHttpClientCredentials CreateHttpClientCredentials(RepositoryConnectionString connectionString) {
            if (connectionString == null) { return null; }
            var factory = this.GetHttpClientTypedFactoryByAuthenticationMode(connectionString.AuthenticationMode);
            if (factory != null) {
                return factory.CreateHttpClientCredentials(connectionString);
            } else {
#warning HERE
                //factory = this.GetHttpClientTypedFactoryByAuthenticationMode("Default");
                //if (factory != null) {
                //    return factory.CreateHttpClientCredentials(connectionString);
                //} else {
                //    //return new HttpClientImplementation(connectionString);
                //    return null;
                //}
                throw new NotImplementedException("CreateHttpClientCredentials");
            }
        }

        public IHttpClient CreateHttpClient(RepositoryConnectionString connectionString) {
            if (connectionString == null) { return null; }
            var factory = this.GetHttpClientTypedFactoryByAuthenticationMode(connectionString.AuthenticationMode);
            IHttpClientCredentials credentials = null;
            if (factory != null) {
                return factory.CreateHttpClient(connectionString, credentials);
            } else {
                factory = this.GetHttpClientTypedFactoryByAuthenticationMode("Default");
                if (factory != null) {
                    return factory.CreateHttpClient(connectionString, credentials);
                } else {
                    //return new HttpClientImplementation(connectionString);
                    return null;
                }
            }
        }

        public IHttpClient CreateHttpClient(RepositoryConnectionString connectionString, IHttpClientCredentials credentials) {
            if (connectionString == null) { return null; }
            var factory = this.GetHttpClientTypedFactoryByAuthenticationMode(connectionString.AuthenticationMode);
            if (factory != null) {
                if (credentials == null) {
                    credentials = factory.CreateHttpClientCredentials(connectionString);
                }
                return factory.CreateHttpClient(connectionString, credentials);
            } else {
                factory = this.GetHttpClientTypedFactoryByAuthenticationMode("Default");
                if (factory != null) {
                    return factory.CreateHttpClient(connectionString, credentials);
                } else {
                    //return new HttpClientImplementation(connectionString);
                    return null;
                }
            }
        }
    }

    public class HttpClientDefaultFactory : IHttpClientTypedFactory {

        public HttpClientDefaultFactory() {

        }

        public IHttpClientCredentials CreateHttpClientCredentials(RepositoryConnectionString connectionString) {
            throw new NotImplementedException();
        }

        public IHttpClient CreateHttpClient(RepositoryConnectionString connectionString, IHttpClientCredentials credentials) {
            var url = connectionString.GetUrlNormalized();
            var result = new HttpClientImplementation(url, credentials);
            return result;
        }

        public string GetAuthenticationMode() => "Default";
    }
}
