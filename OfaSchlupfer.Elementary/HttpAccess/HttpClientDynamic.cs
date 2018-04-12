namespace OfaSchlupfer.HttpAccess {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;

    /* https://www.youtube.com/watch?v=FvMuPtuvP5w */

    public interface IHttpClientWithCookieContainer {
        CookieContainer CookieContainer { get; }
    }

    public class HttpClientDynamic
            : ServiceClient<HttpClientDynamic> {

        public string ApiVersion { get; set; }

        /// <summary>
        /// The base URI of the service.
        /// </summary>
        public System.Uri BaseUri { get; set; }

        /// <summary>
        /// Gets or sets json serialization settings.
        /// </summary>
        public JsonSerializerSettings SerializationSettings { get; private set; }

        /// <summary>
        /// Gets or sets json deserialization settings.
        /// </summary>
        public JsonSerializerSettings DeserializationSettings { get; private set; }

        /// <summary>
        /// Credentials needed for the client to connect to Azure.
        /// </summary>
        public ServiceClientCredentials Credentials { get; private set; }

        public bool? GenerateClientRequestId { get; set; }

        /// <summary>
        /// Gets or sets the preferred language for the response.
        /// </summary>
        public string AcceptLanguage { get; set; }

        public HttpClientDynamic(
            System.Uri baseUri,
            ServiceClientCredentials credentials,
            HttpClientHandler rootHandler,
            params DelegatingHandler[] handlers
            ) : base(rootHandler ?? CreateRootHandler(), handlers) {
            //ApiVersion = "1970-01-01";
            //var cookieContainer = this.HttpClientHandler.CookieContainer;
            //if ((object)cookieContainer == null) {
            //    cookieContainer = new System.Net.CookieContainer();
            //    this.HttpClientHandler.CookieContainer = cookieContainer;
            //}
            //this.CookieContainer = cookieContainer;
            //
            this.BaseUri = baseUri;
            this.Credentials = credentials;
            this.Credentials?.InitializeServiceClient(this);
        }
#if no
        public async Task<AzureOperationResponse<R>> SendAsync<R>(
            string requestDescription,
            string httpMethod,
            string requestSuffix,
            object requestData,
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken)) {

            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace) {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("requestData", requestData);
                if (ApiVersion != null) {
                    tracingParameters.Add("apiVersion", ApiVersion);
                }
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, requestDescription, tracingParameters);
            }
            // Construct URL
            var baseUrl = this.BaseUri.AbsoluteUri;
            var requestUrl = new System.Uri(new System.Uri(baseUrl + (baseUrl.EndsWith("/") ? "" : "/")), requestSuffix).ToString();
            List<string> _queryParameters = new List<string>();
            //if (ApiVersion != null) {
            //    _queryParameters.Add(string.Format("api-version={0}", System.Uri.EscapeDataString(ApiVersion)));
            //}
            if (_queryParameters.Count > 0) {
                requestUrl += (requestUrl.Contains("?") ? "&" : "?") + string.Join("&", _queryParameters);
            }
            // Create HTTP transport objects
            var httpRequest = new HttpRequestMessage();
            HttpResponseMessage httpResponse = null;
            httpRequest.Method = new HttpMethod(string.IsNullOrEmpty(httpMethod) ? "GET" : httpMethod);
            httpRequest.RequestUri = new System.Uri(requestUrl);
            // Set Headers
            if (this.GenerateClientRequestId != null && this.GenerateClientRequestId.Value) {
                httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", System.Guid.NewGuid().ToString());
            }
            if (this.AcceptLanguage != null) {
                if (httpRequest.Headers.Contains("accept-language")) {
                    httpRequest.Headers.Remove("accept-language");
                }
                httpRequest.Headers.TryAddWithoutValidation("accept-language", this.AcceptLanguage);
            }

            if (customHeaders != null) {
                foreach (var _header in customHeaders) {
                    if (httpRequest.Headers.Contains(_header.Key)) {
                        httpRequest.Headers.Remove(_header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            // Serialize Request
            string requestContent = null;
            if (requestData != null) {
                requestContent = SafeJsonConvert.SerializeObject(requestData, this.SerializationSettings);
                httpRequest.Content = new StringContent(requestContent, System.Text.Encoding.UTF8);
                httpRequest.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
            }
            // Set Credentials
            if (this.Credentials != null) {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (shouldTrace) {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace) {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = null;
            if (statusCode != HttpStatusCode.OK) {
                var ex = new CloudException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                try {
                    responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    CloudError errorBody = SafeJsonConvert.DeserializeObject<CloudError>(responseContent, this.DeserializationSettings);
                    if (errorBody != null) {
                        ex = new CloudException(errorBody.Message);
                        ex.Body = errorBody;
                    }
                } catch (JsonException) {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(httpRequest, requestContent);
                ex.Response = new HttpResponseMessageWrapper(httpResponse, responseContent);
                if (httpResponse.Headers.Contains("x-ms-request-id")) {
                    ex.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                }
                if (shouldTrace) {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                httpRequest.Dispose();
                if (httpResponse != null) {
                    httpResponse.Dispose();
                }
                throw ex;
            }
            // Create Result
            var result = new AzureOperationResponse<R>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("x-ms-request-id")) {
                result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            // Deserialize Response
            if (statusCode == HttpStatusCode.OK) {
                responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                try {
                    result.Body = SafeJsonConvert.DeserializeObject<R>(responseContent, this.DeserializationSettings);
                } catch (JsonException ex) {
                    httpRequest.Dispose();
                    if (httpResponse != null) {
                        httpResponse.Dispose();
                    }
                    throw new SerializationException("Unable to deserialize the response.", responseContent, ex);
                }
            }
            if (shouldTrace) {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }
#endif
        public HttpRequestMessage CreateHttpRequestMessage(
            HttpMethod httpMethod,
            string requestSuffix,
            object requestData,
            string contentType = null,
            Dictionary<string, List<string>> customHeaders = null
            ) {
            var httpRequest = new HttpRequestMessage();
            httpRequest.Method = httpMethod;
            var baseUrl = this.BaseUri.AbsoluteUri;
            var requestUri = new System.Uri(new System.Uri(baseUrl + (baseUrl.EndsWith("/") ? "" : "/")), requestSuffix);
            var requestUrl = requestUri.ToString();
            httpRequest.RequestUri = requestUri;
            if (this.AcceptLanguage != null) {
                if (httpRequest.Headers.Contains("accept-language")) {
                    httpRequest.Headers.Remove("accept-language");
                }
                httpRequest.Headers.TryAddWithoutValidation("accept-language", this.AcceptLanguage);
            }

            if (customHeaders != null) {
                foreach (var _header in customHeaders) {
                    if (httpRequest.Headers.Contains(_header.Key)) {
                        httpRequest.Headers.Remove(_header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }
            if (requestData != null) {
                var requestContent = SafeJsonConvert.SerializeObject(requestData, this.SerializationSettings);
                httpRequest.Content = new StringContent(requestContent, System.Text.Encoding.UTF8);
                httpRequest.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse(contentType ?? "application/json; charset=utf-8");
            }
            return httpRequest;
        }
        public async Task<AzureOperationResponse<R>> SendAsync<R>(
            string requestDescription,
            HttpRequestMessage httpRequest,
            Func<AzureOperationResponse<R>, Task> deserializeResponse = null,
            CancellationToken cancellationToken = default(CancellationToken)) {

            //bool shouldTrace = ServiceClientTracing.IsEnabled;
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace) {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                var requestData = await httpRequest.Content.ReadAsStringAsync();
                tracingParameters.Add("requestData", requestData);
                if (ApiVersion != null) {
                    tracingParameters.Add("apiVersion", ApiVersion);
                }
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, requestDescription, tracingParameters);
            }

            // Create HTTP transport objects
            HttpResponseMessage httpResponse = null;
            //httpRequest.RequestUri = new System.Uri(requestUrl);
            // Set Headers
            if (this.GenerateClientRequestId != null && this.GenerateClientRequestId.Value) {
                httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", System.Guid.NewGuid().ToString());
            }


            // Set Credentials
            if (this.Credentials != null) {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (shouldTrace) {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace) {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = null;
            if (statusCode != HttpStatusCode.OK) {
                var ex = new CloudException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                try {
                    responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    CloudError errorBody = SafeJsonConvert.DeserializeObject<CloudError>(responseContent, this.DeserializationSettings);
                    if (errorBody != null) {
                        ex = new CloudException(errorBody.Message);
                        ex.Body = errorBody;
                    }
                } catch (JsonException) {
                    // Ignore the exception
                }
                string requestContent = null;
                if ((object)httpRequest.Content != null) {
                    requestContent = await httpRequest.Content.ReadAsStringAsync();
                }
                ex.Request = new HttpRequestMessageWrapper(httpRequest, requestContent);
                ex.Response = new HttpResponseMessageWrapper(httpResponse, responseContent);
                if (httpResponse.Headers.Contains("x-ms-request-id")) {
                    ex.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                }
                if (shouldTrace) {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                httpRequest.Dispose();
                if (httpResponse != null) {
                    httpResponse.Dispose();
                }
                throw ex;
            }
            // Create Result
            // HttpOperationResponse
            var result = new AzureOperationResponse<R>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("x-ms-request-id")) {
                result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            // Deserialize Response
            if (statusCode == HttpStatusCode.OK) {
                try {
                    if ((object)deserializeResponse == null) {
                        await DeserializeJsonResponse(result);
                    } else {
                        await deserializeResponse(result);
                    }
                } catch (JsonException ex) {
                    httpRequest.Dispose();
                    if (httpResponse != null) {
                        httpResponse.Dispose();
                    }
                    throw new SerializationException("Unable to deserialize the response.", responseContent, ex);
                } catch (SerializationException) {
                    httpRequest.Dispose();
                    if (httpResponse != null) {
                        httpResponse.Dispose();
                    }
                    throw;
                } catch (Exception) {
                    httpRequest.Dispose();
                    if (httpResponse != null) {
                        httpResponse.Dispose();
                    }
                    throw;
                }
            }
            if (shouldTrace) {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }


        private async Task DeserializeJsonResponse<R>(AzureOperationResponse<R> result) {
            HttpRequestMessage httpRequest = result.Request;
            HttpResponseMessage httpResponse = result.Response;
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            try {
                result.Body = SafeJsonConvert.DeserializeObject<R>(responseContent, this.DeserializationSettings);
            } catch (JsonException ex) {
                httpRequest.Dispose();
                if (httpResponse != null) {
                    httpResponse.Dispose();
                }
                throw new SerializationException("Unable to deserialize the response.", responseContent, ex);
            }
        }
    }

}
