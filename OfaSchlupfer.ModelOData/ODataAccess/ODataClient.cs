namespace OfaSchlupfer.ModelOData.ODataAccess {
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using OfaSchlupfer.Elementary;
    using OfaSchlupfer.HttpAccess;
    using OfaSchlupfer.ModelOData.Edm;

    public class ODataClient {
        protected IServiceProvider _ServiceProvider;
        protected IHttpClientDispatcherFactory _ClientFactory;
        protected IHttpClientCredentials _HttpClientCredentials;
        private EdmxModel _EdmxModel;

        public ODataClient(
            IHttpClientDispatcherFactory httpClientDispatcherFactory,
            IServiceProvider serviceProvider
            ) {
            this._ServiceProvider = serviceProvider;
            this._ClientFactory = httpClientDispatcherFactory;
        }
        public RepositoryConnectionString ConnectionString { get; set; }

        public EdmxModel EdmxModel {
            get { return this._EdmxModel; }
            set {
                if (ReferenceEquals(this._EdmxModel, value)) { return; }
                if (!ReferenceEquals(this._EdmxModel, null)) { throw new ArgumentException("Property already set."); }
                this._EdmxModel = value;
            }
        }

        //public ODataRequest Request(string path) {
        //    throw new NotImplementedException();
        //}

        public ODataQueryRequest Query(string path) {
            var result = new ODataQueryRequest();
            result.Path = path;
            return result;
        }

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

        public virtual void SetConnectionString(RepositoryConnectionString connectionString, string suffix) {
            if (string.IsNullOrEmpty(suffix)) {
                this.ConnectionString = connectionString;
            } else {
                this.ConnectionString = connectionString.CreateWithSuffix(suffix);
            }
        }

        public async Task<ODataResponce> ExecuteAsync(
            ODataRequest oDataRequest,
            CancellationToken cancellationToken,
            Func<HttpResponseMessage, int, bool> shouldRetry
            ) {

            var httpClient = this.CreateHttpClient();
            var url = this.ConnectionString.GetUrlNormalized();
            var httpRequest = oDataRequest.CreateHttpRequest(url);
            string requestUrl = httpRequest.RequestUri.ToString();
            // Action<System.Net.Http.HttpClient> configureHttpClient = null;


            Func<System.Net.Http.HttpClient, System.Net.Http.HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> executeAsync = null;
            if (oDataRequest.ShouldResponceReadStream) {
                Func<HttpContent, Task<Stream>> readAsync = readAsStreamAsync;
                ODataResponce oDataResponce = new ODataResponce();
                Stream resultContent;
                var executeTask = httpClient.SendAsync<Stream>(httpRequest, oDataRequest.ConfigureHttpClient, cancellationToken, executeAsync, readAsync, shouldRetry);
                resultContent = await executeTask;
                oDataResponce.SetResponceContentStream(resultContent);
                return oDataResponce;
            } else {
                Func<HttpContent, Task<string>> readAsync = readAsStringAsync;
                ODataResponce oDataResponce = new ODataResponce();
                string resultContent;
                var executeTask = httpClient.SendAsync<string>(httpRequest, oDataRequest.ConfigureHttpClient, cancellationToken, executeAsync, readAsync, shouldRetry);
                resultContent = await executeTask;
                oDataResponce.SetResponceContentString(resultContent);
                return oDataResponce;
            }
        }

        private async Task<Stream> readAsStreamAsync(HttpContent content) {
            var t = content.ReadAsStreamAsync();
            var stream = await t;
            var ms = new MemoryStream();
            await stream.CopyToAsync(ms);
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        private async Task<string> readAsStringAsync(HttpContent content) {
            var t = content.ReadAsStringAsync();
            string result;
            result = await t;
            return result;
        }
    }
}
