namespace OfaSchlupfer.ModelOData.SPO {
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

        // weichei
        //public ISharePointOnlineCredentials CreateCredentials(string username, string password) {
        //    var logger = this._Logger ?? (this._Logger = this._LoggerFactory.CreateLogger("Authentication"));
        //    return new SharePointOnlineCredentials(username, password, logger);
        //}

        public IHttpClient CreateHttpClient(RepositoryConnectionString connectionString) {
            var logger = this._Logger ?? (this._Logger = this._LoggerFactory.CreateLogger("Authentication"));
            var spoCred = new SharePointOnlineCredentials(connectionString.User, connectionString.Password, logger);
            return new HttpClientImplementation(connectionString.GetUrlNormalized(), spoCred);
        }

        // weichei
        //public ISharePointOnlineHttpClient CreateSPOHttpClient(RepositoryConnectionString connectionString) {
        //    var logger = this._Logger ?? (this._Logger = this._LoggerFactory.CreateLogger("Authentication"));
        //    var spoCred = new SharePointOnlineCredentials(connectionString.User, connectionString.Password, logger);
        //    return new SharePointOnlineHttpClient(connectionString.GetUrlNormalized(), spoCred);
        //}
    }
}
