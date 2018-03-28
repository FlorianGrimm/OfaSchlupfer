namespace OfaSchlupfer.ModelOData.SPO {
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    internal class SharePointOnlineHttpClient : ISharePointOnlineHttpClient, System.IDisposable {
        private string _Url;
        private ISharePointOnlineCredentials _spoCred;
        //        private HttpClientHandler _Handler;

        public SharePointOnlineHttpClient(string url, ISharePointOnlineCredentials spoCred) {
            if (string.IsNullOrEmpty(url)) { throw new ArgumentNullException(nameof(url)); }
            if (spoCred == null) { throw new ArgumentNullException(nameof(spoCred)); }
            this._Url = url;
            this._spoCred = spoCred;
        }

        public bool AuthenticateAsync() {
            return (this._spoCred.GetAuthenticationCookie(new Uri(this._Url))) != null;
        }

        public async Task<string> GetAsync(string requestUrl, Action<HttpClient> configureHttpClient) {
            if (requestUrl == null) { return null; }
            if (requestUrl.StartsWith("/")) { requestUrl = this._Url + requestUrl; }
            var uri = new Uri(this._Url);
            var cookie = this._spoCred.GetAuthenticationCookie(uri, false, false);

            using (var httpClientHandler = new HttpClientHandler()) {
                httpClientHandler.Credentials = this._spoCred;
                httpClientHandler.CookieContainer.SetCookies(uri, cookie);
                using (var httpClient = new HttpClient(httpClientHandler)) {
                    if (configureHttpClient != null) {
                        configureHttpClient(httpClient);
                    }
                    HttpResponseMessage response = await httpClient.GetAsync(requestUrl).ConfigureAwait(false);
                    response.EnsureSuccessStatusCode();

                    string jsonData = await response.Content.ReadAsStringAsync();

                    return jsonData;
                }
            }
        }

        //public async Task<string> ExecuteJson(string requestUrl) {
        //    if (requestUrl == null) { return null; }
        //    if (requestUrl.StartsWith("/")) { requestUrl = this._Url + requestUrl; }
        //    using (var client = new HttpClient(this._Handler)) {
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        //        HttpResponseMessage response = await client.GetAsync(requestUrl).ConfigureAwait(false);
        //        response.EnsureSuccessStatusCode();

        //        string jsonData = await response.Content.ReadAsStringAsync();

        //        return jsonData;
        //    }
        //}

        protected virtual void Dispose(bool disposing) {
            //using (var h = this._Handler) {
            //    this._Handler = null;
            //}
        }

        ~SharePointOnlineHttpClient() => this.Dispose(false);

        // This code added to correctly implement the disposable pattern.
        public void Dispose() {
            this.Dispose(true);
            System.GC.SuppressFinalize(this);
        }


        //public object x() {
        //    //Creating Handler to allows the client to use credentials and cookie 
        //    var handler = new HttpClientHandler() { Credentials = credential };
        //    //Getting authentication cookies 
        //    Uri uri = new Uri(webUrl);
        //    handler.CookieContainer.SetCookies(uri, credential.GetAuthenticationCookie(uri));

        //    //Invoking REST API 
        //    var client = new HttpClient(handler);
        //}

    }
}
