using System;
using System.Net.Http;

namespace OfaSchlupfer.ModelOData.ODataAccess {
    public class ODataRequest {
        public HttpRequestMessage CreateHttpRequest() {
            HttpRequestMessage result = new HttpRequestMessage();
            result.RequestUri = new Uri("/");
            return result;
        }
    }
}