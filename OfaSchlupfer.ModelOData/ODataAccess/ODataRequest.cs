namespace OfaSchlupfer.ModelOData.ODataAccess {
    using System;
    using System.Net.Http;

    public class ODataRequest {
        public virtual HttpRequestMessage CreateHttpRequest(string requestUri) {
            HttpRequestMessage result = new HttpRequestMessage(HttpMethod.Get, requestUri);
            return result;
        }

        public virtual bool ShouldResponceReadStream { get; set; }

        public virtual void ConfigureHttpClient(HttpClient httpClient) {
        }
    }
}