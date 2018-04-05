namespace OfaSchlupfer.HttpAccess {
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class HttpClientImplementation : IHttpClient {
        protected int _MaximumRetries;
        protected string _Url;
        protected ICredentials _Credentials;

        public HttpClientImplementation(string url, ICredentials credentials) {
            this._Url = url;
            this._Credentials = credentials;
        }

        public virtual void Dispose() {
        }

        public virtual async Task<R> ExecuteAsync<R>(
            string requestUrl,
            Action<System.Net.Http.HttpClient> configureHttpClient,
            CancellationToken cancellationToken,
            Func<System.Net.Http.HttpClient, string, CancellationToken, Task<HttpResponseMessage>> executeAsync,
            Func<HttpContent, Task<R>> readAsync,
            Func<HttpResponseMessage, int, bool> shouldRetry
            ) {
            if (requestUrl == null) { throw new ArgumentNullException(nameof(requestUrl)); }
            if (requestUrl.StartsWith("/")) { requestUrl = this._Url + requestUrl; }
            var uri = new Uri(this._Url);
            var cookieCredentials = this._Credentials as ICookieCredentials;
            string cookie = null;
            if ((object)cookieCredentials != null) {
                cookie = await GetAuthenticationCookie(uri, cookieCredentials, false);
            }
            bool authenticationRetryAllowed = true;
            int reties = 0;

            while (reties <= _MaximumRetries) {
                using (var httpClientHandler = new HttpClientHandler()) {
                    if (this._Credentials != null) {
                        httpClientHandler.Credentials = this._Credentials;
                    }
                    if (cookie != null) {
                        httpClientHandler.CookieContainer.SetCookies(uri, cookie);
                    }
                    using (var httpClient = new System.Net.Http.HttpClient(httpClientHandler)) {
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
                        try {
                            response = await responseTask.ConfigureAwait(false);
                        } catch (Exception exc) {
                            throw exc;
                        }
                        using (response) {
                            if (!response.IsSuccessStatusCode) {
                                if ((response.StatusCode == System.Net.HttpStatusCode.Unauthorized) || (response.StatusCode == System.Net.HttpStatusCode.Forbidden)) {
                                    if (authenticationRetryAllowed && ((object)cookieCredentials != null)) {
                                        authenticationRetryAllowed = false;
                                        cookie = await this.GetAuthenticationCookie(uri, cookieCredentials, true);
                                        continue;
                                    }
                                }
                                if (shouldRetry != null) {
                                    reties++;
                                    if (reties <= this._MaximumRetries) {
                                        authenticationRetryAllowed = true;
                                        bool bShouldRetry = shouldRetry(response, reties);
                                        if (bShouldRetry) {
                                            continue;
                                        }
                                    }
                                }
                            }
                            // read the responce
                            response.EnsureSuccessStatusCode();
                            {
                                R result;
                                Task<R> resultTask = readAsync(response.Content);
                                try {
                                    result = await resultTask.ConfigureAwait(false);
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

        public virtual Task<string> GetAsStringAsync(string requestUrl, Action<HttpClient> configureHttpClient, Func<HttpResponseMessage, int, bool> shouldRetry) {
            return this.ExecuteAsync<string>(
                requestUrl,
                configureHttpClient,
                CancellationToken.None,
                (client, url, ct) => client.GetAsync(url, ct),
                (content) => content.ReadAsStringAsync(),
                null);
        }

        protected virtual async Task<string> GetAuthenticationCookie(Uri uri, ICookieCredentials cookieCredentials, bool refresh) {
            if (cookieCredentials.IsSupportedGetAuthenticationCookieAsync) {
                var cookieTask = cookieCredentials.GetAuthenticationCookieAsync(uri, refresh, false);
                return await (cookieTask);
            } else {
                return cookieCredentials.GetAuthenticationCookie(uri, refresh, false);
            }
        }
    }
}
