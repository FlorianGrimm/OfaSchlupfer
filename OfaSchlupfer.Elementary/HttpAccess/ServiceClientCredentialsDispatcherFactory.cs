/*
 * https://www.youtube.com/watch?v=2yXtZ8x7TXw
 */
namespace OfaSchlupfer.HttpAccess {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Microsoft.Rest;

    using OfaSchlupfer.Elementary;

    public class ServiceClientCredentialsDispatcherFactory : IServiceClientCredentialsDispatcherFactory {
        public readonly IServiceProvider ServiceProvider;
        public readonly ServiceClientCredentialsOptions Options;
        private IServiceClientCredentialsConcreteFactory[] _ServiceClientCredentialsFactories;
        private Dictionary<string, IServiceClientCredentialsConcreteFactory> _FactoryByAuthenticationMode;

        // ServiceClientCredentialsOptions
        public ServiceClientCredentialsDispatcherFactory(
            IServiceProvider serviceProvider
            , IOptions<ServiceClientCredentialsOptions> options) {
            this.Options = options.Value ?? new ServiceClientCredentialsOptions();
        }


        public ServiceClientCredentials CreateServiceClientCredentials(
            RepositoryConnectionString connectionString
            ) {
            var authenticationMode = connectionString.AuthenticationMode;
            var cmp = StringComparer.OrdinalIgnoreCase;
            var serviceClientCredentialsFactories = this.GetServiceClientCredentialsFactories();
            foreach (var factory in serviceClientCredentialsFactories) {
                var factoryAuthenticationMode = factory.GetAuthenticationMode();
                if (cmp.Equals(factoryAuthenticationMode, authenticationMode)) {
                    return factory.CreateServiceClientCredentials(connectionString);
                }
            }
            return null;
        }

        private IServiceClientCredentialsConcreteFactory[] GetServiceClientCredentialsFactories() {
            if (this._ServiceClientCredentialsFactories != null) {
                return this._ServiceClientCredentialsFactories;
            }
            if (this.Options.Factories.Count > 0) {
                this._ServiceClientCredentialsFactories = this.Options.Factories.ToArray();
                return this._ServiceClientCredentialsFactories;
            }
            {
                var serivces = this.ServiceProvider.GetServices<IServiceClientCredentialsConcreteFactory>();
                this._ServiceClientCredentialsFactories = serivces.ToArray();
            }
            return this._ServiceClientCredentialsFactories;
        }
    }
}
