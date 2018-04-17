namespace OfaSchlupfer.ModelOData.ODataAccess {
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Newtonsoft.Json;
    using OfaSchlupfer.Entity;
    using OfaSchlupfer.HttpAccess;
    using OfaSchlupfer.ModelOData.Edm;

    public class ODataServiceClient<T> : HttpServiceClient<T>
            where T : ODataServiceClient<T> {

        public ODataServiceClient(
            System.Uri baseUri,
            ServiceClientCredentials credentials,
            HttpClientHandler rootHandler,
            params DelegatingHandler[] handlers)
            : base(
                    baseUri,
                    credentials,
                    rootHandler,
                    handlers
            ) {
        }

#warning weichei
        /*
        //private EdmxModel _EdmxModel;
        public EdmxModel EdmxModel { get => this._EdmxModel; set => this._EdmxModel = value; }
         */

        public ODataQueryRequest Query(string path) {
            var result = new ODataQueryRequest();
            result.Path = path;
            return result;
        }
    }

    public class ODataServiceClient : ODataServiceClient<ODataServiceClient> {
        public ODataServiceClient(
           System.Uri baseUri,
           ServiceClientCredentials credentials,
           HttpClientHandler rootHandler,
           params DelegatingHandler[] handlers)
           : base(
                   baseUri,
                   credentials,
                   rootHandler,
                   handlers
           ) {
        }

        public virtual Task<AzureOperationResponse<R>> SendAsync<R>(
                string requestDescription,
                ODataRequest oDataRequest,
                Func<AzureOperationResponse<R>, JsonSerializerSettings, Task> deserializeResponse = null,
                CancellationToken cancellationToken = default(CancellationToken)) {
            var httpRequest = oDataRequest.CreateHttpRequest(this.BaseUri.AbsoluteUri);
            return this.SendAsync(requestDescription, httpRequest, deserializeResponse, cancellationToken);
        }
    }
}