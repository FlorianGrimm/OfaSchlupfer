namespace OfaSchlupfer.SPO {
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using OfaSchlupfer.HttpAccess;

    internal class SharePointOnlineHttpClient : HttpClientImplementation, ISharePointOnlineHttpClient, System.IDisposable {
        //private const int MaximumRetries = 10;
        //private string _Url;
        //private ISharePointOnlineCredentials _spoCred;
        //        private HttpClientHandler _Handler;

        public SharePointOnlineHttpClient(string url, ISharePointOnlineCredentials spoCred) : base(url, spoCred) {
            if (string.IsNullOrEmpty(url)) { throw new ArgumentNullException(nameof(url)); }
            if (spoCred == null) { throw new ArgumentNullException(nameof(spoCred)); }
            //this._Url = url;
            //this._spoCred = spoCred;
        }

        // weichei
        // public bool Authenticate() {
        //     return (this._spoCred.GetAuthenticationCookie(new Uri(this._Url), false, false)) != null;
        // }

        //Task<HttpResponseMessage> GetAsync(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken);
#if no
        public async Task<string> GetAsStringAsync(string requestUrl, Action<HttpClient> configureHttpClient) {
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

                    string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    return result;
                }
            }
        }
#endif
#if weichei
        public Task<string> GetAsStringAsync(string requestUrl, Action<HttpClient> configureHttpClient, Func<HttpResponseMessage, int, bool> shouldRetry) {
            return this.ExecuteAsync<string>(requestUrl, configureHttpClient, CancellationToken.None, null, (client, url, ct) => client.GetAsync(url, ct), (content) => content.ReadAsStringAsync());
        }
#endif
#if weichei
        public async Task<R> ExecuteAsync<R>(
            string requestUrl,
            Action<HttpClient> configureHttpClient,
            CancellationToken cancellationToken,
            Func<HttpResponseMessage, int, bool> shouldRetry,
            Func<HttpClient, string, CancellationToken, Task<HttpResponseMessage>> executeAsync,
            Func<HttpContent, Task<R>> readAsync
            ) {
            if (requestUrl == null) { throw new ArgumentNullException(nameof(requestUrl)); }
            if (requestUrl.StartsWith("/")) { requestUrl = this._Url + requestUrl; }
            var uri = new Uri(this._Url);
            var cookie = this._spoCred.GetAuthenticationCookie(uri, false, false);
            bool authenticationRetryAllowed = true;
            int reties = 0;

            while (reties < MaximumRetries) {
                using (var httpClientHandler = new HttpClientHandler()) {
                    httpClientHandler.Credentials = this._spoCred;
                    httpClientHandler.CookieContainer.SetCookies(uri, cookie);
                    using (var httpClient = new HttpClient(httpClientHandler)) {
                        if (configureHttpClient != null) {
                            configureHttpClient(httpClient);
                        }
                        HttpResponseMessage response;
                        Task<HttpResponseMessage> responseTask;
                        if (executeAsync == null) {
                            responseTask = httpClient.GetAsync(requestUrl, cancellationToken);
                        } else {
                            responseTask = executeAsync(httpClient, requestUrl, cancellationToken);
                        }
                        var responseTaskConfigured = responseTask.ConfigureAwait(false);
                        try {
                            response = await responseTaskConfigured;
                        } catch (Exception exc) {
                            throw exc;
                        }
                        using (response) {
                            if (!response.IsSuccessStatusCode) {
                                if ((response.StatusCode == System.Net.HttpStatusCode.Unauthorized) || (response.StatusCode == System.Net.HttpStatusCode.Forbidden)) {
                                    if (authenticationRetryAllowed) {
                                        authenticationRetryAllowed = false;
                                        cookie = this._spoCred.GetAuthenticationCookie(uri, true, false);
                                        continue;
                                    }
                                }
                                if (shouldRetry != null) {
                                    reties++;
                                    if (reties < MaximumRetries) {
                                        authenticationRetryAllowed = true;
                                        bool bShouldRetry = shouldRetry(response, reties);
                                        if (bShouldRetry) {
                                            continue;
                                        }
                                    }
                                }
                            }


                            response.EnsureSuccessStatusCode();
                            {
                                R result;
                                Task<R> resultTask = readAsync(response.Content);
                                var resultTaskConfigured = resultTask.ConfigureAwait(false);
                                try {
                                    result = await resultTaskConfigured;
                                } catch (Exception exc) {
                                    throw exc;
                                }
                                return result;
                            }
                        }
                    }
                }
            }
            throw new HttpRequestException("Maximum retires");
        }
#endif
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

#if weichei
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
#endif

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
