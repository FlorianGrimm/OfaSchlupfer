namespace OfaSchlupfer.ModelOData.ODataAccess {
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;

    public class ODataQueryRequest : ODataRequest {
        public ODataQueryRequest() {
        }

        public string Path { get; set; }

        public string HeaderAccept { get; set; }

        public string DataServiceVersion { get; set; }

        public string MaxDataServiceVersion { get; set; }


        public override HttpRequestMessage CreateHttpRequest(string requestUri) {
            var url = requestUri + "/" + Path;
            HttpRequestMessage result = new HttpRequestMessage(HttpMethod.Get, url);

            if (string.IsNullOrEmpty(this.HeaderAccept)) {
                this.HeaderAccept = "application/json;odata=verbose";
            }
            result.Headers.Add("accept", this.HeaderAccept);

            if (!string.IsNullOrEmpty(this.DataServiceVersion)) {
                result.Headers.Add("DataServiceVersion", this.DataServiceVersion);
            }
            if (!string.IsNullOrEmpty(this.MaxDataServiceVersion)) {
                result.Headers.Add("MaxDataServiceVersion", this.MaxDataServiceVersion);
            }
            /*
             accept: application/atom+xml,application/atomsvc+xml,application/xml
             DataServiceVersion: 1.0 MaxDataServiceVersion: 2.0 
             DataServiceVersion: 1.0 MaxDataServiceVersion: 2.0 
             application/json;odata=verbose
            */
            return result;
        }
        public override void ConfigureHttpClient(HttpClient httpClient) {
            base.ConfigureHttpClient(httpClient);
            //httpClient.DefaultRequestHeaders.Add()
        }
    }
}
