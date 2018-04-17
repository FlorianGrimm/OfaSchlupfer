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
    using OfaSchlupfer.Entitiy;
    using OfaSchlupfer.Model;

    public class HttpServiceClient<T>
        : ServiceClient<T>
        , IHttpServiceClient
        , IModelClient
        where T : HttpServiceClient<T> {
        protected ServiceClientCredentials _Credentials;
        protected JsonSerializerSettings _DeserializationSettings;
        protected JsonSerializerSettings _SerializationSettings;

        /// <summary>
        /// ApiVersion.
        /// </summary>
        public string ApiVersion { get; set; }

        /// <summary>
        /// The base URI of the service.
        /// </summary>
        public System.Uri BaseUri { get; set; }

        /// <summary>
        /// Gets or sets json serialization settings.
        /// </summary>
        public JsonSerializerSettings SerializationSettings { get => this._SerializationSettings ?? (this._SerializationSettings = this.CreateSerializationSettings()); }


        /// <summary>
        /// Gets or sets json deserialization settings.
        /// </summary>
        public JsonSerializerSettings DeserializationSettings { get => this._DeserializationSettings ?? (this._DeserializationSettings = this.CreateDeserializationSettings()); }

        /// <summary>
        /// Credentials needed for the client to connect to Azure.
        /// </summary>
        public ServiceClientCredentials Credentials {
            get {
                return this._Credentials;
            }
            set {
                if (ReferenceEquals(this._Credentials, value)) { return; }
                this._Credentials = value;
                value?.InitializeServiceClient(this);
            }
        }

        public bool? GenerateClientRequestId { get; set; }

        /// <summary>
        /// Gets or sets the preferred language for the response.
        /// </summary>
        public string AcceptLanguage { get; set; }

        public HttpServiceClient(
            System.Uri baseUri,
            ServiceClientCredentials credentials,
            HttpClientHandler rootHandler,
            params DelegatingHandler[] handlers
            ) : base(rootHandler ?? CreateRootHandler(), handlers) {
            this.BaseUri = baseUri;
            this.Credentials = credentials;
        }

        public ModelRepository ModelRepository { get; set; }

        // public IServiceProvider ServiceProvider { get; set; }

        protected virtual JsonSerializerSettings CreateSerializationSettings() {
            return new JsonSerializerSettings();
        }

        protected virtual JsonSerializerSettings CreateDeserializationSettings() {
            return new JsonSerializerSettings();
        }



        public virtual HttpRequestMessage CreateHttpRequestMessage(
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

        public virtual async Task<AzureOperationResponse<R>> SendAsync<R>(
            string requestDescription,
            HttpRequestMessage httpRequest,
            Func<AzureOperationResponse<R>, JsonSerializerSettings, Task> deserializeResponse = null,
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
                        var t = DeserializeJsonResponse(result, this.DeserializationSettings);
                        await t;
                    } else {
                        var t = deserializeResponse(result, this.DeserializationSettings);
                        await t;
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

        public virtual Task DeserializeJsonResponse<R>(AzureOperationResponse<R> result, JsonSerializerSettings deserializationSettings) {
            return DefaultDeserializeJsonResponse(result, deserializationSettings);
        }

        public static async Task DefaultDeserializeJsonResponse<R>(AzureOperationResponse<R> result, JsonSerializerSettings deserializationSettings) {
            HttpRequestMessage httpRequest = result.Request;
            HttpResponseMessage httpResponse = result.Response;
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            try {
                result.Body = SafeJsonConvert.DeserializeObject<R>(responseContent, deserializationSettings);
            } catch (JsonException ex) {
                throw new SerializationException("Unable to deserialize the response.", responseContent, ex);
            }
        }

        public virtual IEntity CreateEntityByExternalTypeName(string externalTypeName) => this.ModelRepository?.CreateEntityByExternalTypeName(externalTypeName);
    }
}
