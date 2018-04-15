namespace OfaSchlupfer.HttpAccess {
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using OfaSchlupfer.Elementary;

    public class HttpClientImplementation : IHttpClient {
        protected int _MaximumRetries;
        protected string _Url;
        protected IHttpClientCredentials _Credentials;

        public HttpClientImplementation(string url, IHttpClientCredentials credentials) {
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
            var credentials = this._Credentials;
            var netCredentials = credentials as System.Net.ICredentials;

            IHttpClientCredentialsData httpClientCredentialsData = null;
            if (credentials != null) {
                httpClientCredentialsData = await GetAuthenticationMayAsync(uri, credentials, false);
            }

            bool authenticationRetryAllowed = true;
            int reties = 0;

            while (reties <= _MaximumRetries) {
                using (var httpClientHandler = new HttpClientHandler()) {
                    credentials?.ConfigureHttpClientHandler(httpClientHandler, httpClientCredentialsData);
                    using (var httpClient = new System.Net.Http.HttpClient(httpClientHandler)) {
                        if (configureHttpClient != null) {
                            configureHttpClient(httpClient);
                        }
                        credentials?.ConfigureHttpClient(httpClient, httpClientCredentialsData);
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
                                    if (authenticationRetryAllowed && ((object)credentials != null)) {
                                        authenticationRetryAllowed = false;
                                        httpClientCredentialsData = await this.GetAuthenticationMayAsync(uri, credentials, true);
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

        public virtual async Task<R> SendAsync<R>(
           HttpRequestMessage request,
           Action<System.Net.Http.HttpClient> configureHttpClient,
           CancellationToken cancellationToken,
           Func<System.Net.Http.HttpClient, System.Net.Http.HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> executeAsync,
           Func<HttpContent, Task<R>> readAsync,
           Func<HttpResponseMessage, int, bool> shouldRetry
           ) {
            if (request == null) { throw new ArgumentNullException(nameof(request)); }
            var requestUri = request.RequestUri;
            string requestUrl = requestUri.ToString();
            var credentials = this._Credentials;
            var netCredentials = credentials as System.Net.ICredentials;

            IHttpClientCredentialsData httpClientCredentialsData = null;
            if (credentials != null) {
                httpClientCredentialsData = await GetAuthenticationMayAsync(requestUri, credentials, false);
            }

            bool authenticationRetryAllowed = true;
            int reties = 0;

            while (reties <= _MaximumRetries) {
                using (var httpClientHandler = new HttpClientHandler()) {
                    credentials?.ConfigureHttpClientHandler(httpClientHandler, httpClientCredentialsData);
                    using (var httpClient = new System.Net.Http.HttpClient(httpClientHandler)) {
                        if (configureHttpClient != null) {
                            configureHttpClient(httpClient);
                        }
                        credentials?.ConfigureHttpClient(httpClient, httpClientCredentialsData);
                        HttpResponseMessage response;
                        Task<HttpResponseMessage> responseTask;

                        if (executeAsync == null) {
                            responseTask = httpClient.SendAsync(request, HttpCompletionOption.ResponseContentRead, cancellationToken);
                        } else {
                            responseTask = executeAsync(httpClient, request, cancellationToken);
                        }

                        try {
                            response = await responseTask.ConfigureAwait(false);
                        } catch (Exception exc) {
                            throw exc;
                        }
                        using (response) {
                            if (!response.IsSuccessStatusCode) {
                                if ((response.StatusCode == System.Net.HttpStatusCode.Unauthorized) || (response.StatusCode == System.Net.HttpStatusCode.Forbidden)) {
                                    if (authenticationRetryAllowed && ((object)credentials != null)) {
                                        authenticationRetryAllowed = false;
                                        httpClientCredentialsData = await this.GetAuthenticationMayAsync(requestUri, credentials, true);
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
#warning HERE SendAsync HttpClientImplementation
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

        protected virtual async Task<IHttpClientCredentialsData> GetAuthenticationMayAsync(Uri uri, IHttpClientCredentials cookieCredentials, bool refresh) {
            if (cookieCredentials.IsSupportedGetAuthenticationAsync) {
                var cookieTask = cookieCredentials.GetAuthenticationAsync(uri, refresh, false);
                return await (cookieTask);
            } else if (cookieCredentials.IsSupportedGetAuthentication) {
                return cookieCredentials.GetAuthentication(uri, refresh, false);
            } else {
                return null;
            }
        }
    }
}
