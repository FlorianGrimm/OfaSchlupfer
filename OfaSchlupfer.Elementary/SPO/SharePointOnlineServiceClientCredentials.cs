namespace OfaSchlupfer.SPO {
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Logging;
    using Microsoft.Rest;

    using OfaSchlupfer.Elementary;

    public class SharePointOnlineServiceClientCredentials : ServiceClientCredentials {
        private readonly ILogger _Logger;
        private readonly SharePointOnlineCredentials _SPOCredentials;

        public SharePointOnlineServiceClientCredentials(RepositoryConnectionString connectionString, ILogger logger) {
            this._Logger = logger;
            this._SPOCredentials = new SharePointOnlineCredentials(connectionString.User, connectionString.Password, logger);
        }

        public SharePointOnlineServiceClientCredentials(string username, string password, ILogger logger) {
            this._Logger = logger;
            this._SPOCredentials = new SharePointOnlineCredentials(username, password, logger);
        }

        public override void InitializeServiceClient<T>(ServiceClient<T> client) {
            base.InitializeServiceClient(client);
        }

        public override async Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            var cookie = await this._SPOCredentials.GetAuthenticationCookieAsync(request.RequestUri, false, false);
            request.Headers.Add("Cookie", cookie);
            await base.ProcessHttpRequestAsync(request, cancellationToken);
        }
    }
}
