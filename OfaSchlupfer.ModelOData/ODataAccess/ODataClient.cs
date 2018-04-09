namespace OfaSchlupfer.ModelOData.ODataAccess {
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using OfaSchlupfer.Elementary;
    using OfaSchlupfer.HttpAccess;

    public class ODataClient {
        protected IServiceProvider _ServiceProvider;
        protected IHttpClientDispatcherFactory _ClientFactory;
        protected IHttpClientCredentials _HttpClientCredentials;
        public ODataClient(
            IServiceProvider serviceProvider,
            IHttpClientDispatcherFactory httpClientDispatcherFactory
            ) {
            this._ServiceProvider= serviceProvider;
            this._ClientFactory = httpClientDispatcherFactory;
        }
        public RepositoryConnectionString ConnectionString { get; set; }
        
        public virtual IHttpClient CreateHttpClient() {
            if (this._ClientFactory != null) {
                if (this._HttpClientCredentials == null) {
                    this._HttpClientCredentials = this._ClientFactory.CreateHttpClientCredentials(this.ConnectionString);
                }
                if (this._HttpClientCredentials == null) {
                    return this._ClientFactory.CreateHttpClient(this.ConnectionString);
                } else {
                    return this._ClientFactory.CreateHttpClient(this.ConnectionString, this._HttpClientCredentials);
                }
            } else {
                return null;
            }
        }


        public async Task<ODataResponce> ExecuteAsync(
            ODataRequest request,
            CancellationToken cancellationToken,
            Func<HttpResponseMessage, int, bool> shouldRetry
            ) {
            
            var httpClient = this.CreateHttpClient();
            var httpRequest = request.CreateHttpRequest();
            string requestUrl = httpRequest.RequestUri.ToString();
            Action<System.Net.Http.HttpClient> configureHttpClient = null;
            
            Func<System.Net.Http.HttpClient, string, CancellationToken, Task<HttpResponseMessage>> executeAsync = null;
            switch (httpRequest.Method.Method) {
                case "GET":
                    executeAsync = delegate (System.Net.Http.HttpClient client, string url, CancellationToken ct) {
                        return client.GetAsync(url, ct);
                    };
                    break;
                default:
                    break;
            }
            Func<HttpContent, Task<string>> readAsync = null;
            string result;
            var executeTask=httpClient.ExecuteAsync<string>(requestUrl, configureHttpClient, cancellationToken, executeAsync, readAsync, shouldRetry);
            result=await executeTask;
            return null;
        }
    }
}
