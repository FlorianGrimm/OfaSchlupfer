namespace OfaSchlupfer.SPO {
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Microsoft.Rest;
    using OfaSchlupfer.HttpAccess;

    public class SharePointOnlineServiceClientCredentials : ServiceClientCredentials {
        //private readonly string _Username;
        //private readonly string _Password;
        private readonly ILogger _Logger;
        private readonly SharePointOnlineCredentials _SPOCredentials;

        public SharePointOnlineServiceClientCredentials(string username, string password, ILogger logger) {
            //this._Username = username;
            //this._Password = password;
            this._Logger = logger;
            this._SPOCredentials = new SharePointOnlineCredentials(username, password, logger);
        }

        public override void InitializeServiceClient<T>(ServiceClient<T> client) {
            client.HttpClient.BaseAddress
            base.InitializeServiceClient(client);
        }

        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            var cookie = this._SPOCredentials.GetAuthenticationCookie(request.RequestUri, false, false);
            request.Headers.Add("Set-Cookie", cookie);
            return base.ProcessHttpRequestAsync(request, cancellationToken);
        }
    }
}
