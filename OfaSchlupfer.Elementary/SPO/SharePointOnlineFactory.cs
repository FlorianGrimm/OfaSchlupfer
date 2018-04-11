namespace OfaSchlupfer.SPO {
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using OfaSchlupfer.Elementary;
    using OfaSchlupfer.HttpAccess;
    using System.Net.Http;

    public class SharePointOnlineFactory : ISharePointOnlineClientFactory {
        private ILoggerFactory _LoggerFactory;
        private IOptions<SharePointOnlineCredentialsOptions> _HubOptions;
        private ILogger _Logger;

        public SharePointOnlineFactory(
            IOptions<SharePointOnlineCredentialsOptions> hubOptions,
            ILoggerFactory loggerFactory
            ) {
            this._HubOptions = hubOptions;
            this._LoggerFactory = loggerFactory;
            this._Logger = this._HubOptions?.Value.Logger;
        }

        public string GetAuthenticationMode() => "SPOIDCRL";

        public IHttpClientCredentials CreateHttpClientCredentials(RepositoryConnectionString connectionString) {
            var logger = this._Logger ?? (this._Logger = this._LoggerFactory.CreateLogger("Authentication"));
            return new SharePointOnlineCredentials(connectionString.User, connectionString.Password, logger);
        }

        public IHttpClient CreateHttpClient(RepositoryConnectionString connectionString, IHttpClientCredentials credentials) {
            if (credentials == null) {
                var spoCred = this.CreateHttpClientCredentials(connectionString);
                return new HttpClientImplementation(connectionString.GetUrlNormalized(), spoCred);
            } else {
                return new HttpClientImplementation(connectionString.GetUrlNormalized(), (SharePointOnlineCredentials) credentials);
            }
        }

        
    }
}
