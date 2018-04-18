namespace OfaSchlupfer.SPO {
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    using Microsoft.Rest;

    using OfaSchlupfer.Elementary;
    using OfaSchlupfer.HttpAccess;
    using System.Net.Http;

    public class SharePointOnlineServiceClientCredentialsFactory : IServiceClientCredentialsConcreteFactory {
        private ILoggerFactory _LoggerFactory;
        private ILogger _Logger;

        public SharePointOnlineServiceClientCredentialsFactory(
            ILoggerFactory loggerFactory,
            IOptions<ServiceClientCredentialsOptions> options = null
            ) {
            this._LoggerFactory = loggerFactory;
            this._Logger = options?.Value.Logger;
        }

        public string GetAuthenticationMode() => "SPOIDCRL";

        public ServiceClientCredentials CreateServiceClientCredentials(RepositoryConnectionString connectionString) {
            var logger = this._Logger ?? (this._Logger = this._LoggerFactory.CreateLogger("Authentication"));
            return new SharePointOnlineServiceClientCredentials(connectionString, logger);
        }


        //public IHttpClientCredentials CreateHttpClientCredentials(RepositoryConnectionString connectionString) {
        //    var logger = this._Logger ?? (this._Logger = this._LoggerFactory.CreateLogger("Authentication"));
        //    return new SharePointOnlineCredentials(connectionString.User, connectionString.Password, logger);
        //}

        //public IHttpClient CreateHttpClient(RepositoryConnectionString connectionString, IHttpClientCredentials credentials) {
        //    if (credentials == null) {
        //        var spoCred = this.CreateHttpClientCredentials(connectionString);
        //        return new HttpClientImplementation(connectionString.GetUrlNormalized(), spoCred);
        //    } else {
        //        return new HttpClientImplementation(connectionString.GetUrlNormalized(), (SharePointOnlineCredentials) credentials);
        //    }
        //}


    }
}
