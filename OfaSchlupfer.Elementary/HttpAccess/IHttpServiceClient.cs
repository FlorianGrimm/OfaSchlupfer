namespace OfaSchlupfer.HttpAccess {
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Rest;
    using Microsoft.Rest.Azure;

    using Newtonsoft.Json;

    public interface IHttpServiceClient {
        /// <summary>
        /// ApiVersion.
        /// </summary>
        string ApiVersion { get; set; }

        /// <summary>
        /// The base URI of the service.
        /// </summary>
        System.Uri BaseUri { get; set; }

        /// <summary>
        /// Gets or sets json serialization settings.
        /// </summary>
        JsonSerializerSettings SerializationSettings { get; }

        /// <summary>
        /// Gets or sets json deserialization settings.
        /// </summary>
        JsonSerializerSettings DeserializationSettings { get; }

        /// <summary>
        /// Credentials needed for the client to connect to Azure.
        /// </summary>
        ServiceClientCredentials Credentials { get; set; }

        bool? GenerateClientRequestId { get; set; }

        /// <summary>
        /// Gets or sets the preferred language for the response.
        /// </summary>
        string AcceptLanguage { get; set; }

        HttpRequestMessage CreateHttpRequestMessage(
          HttpMethod httpMethod,
          string requestSuffix,
          object requestData,
          string contentType = null,
          Dictionary<string, List<string>> customHeaders = null
          );

        Task<AzureOperationResponse<R>> SendAsync<R>(
            string requestDescription,
            HttpRequestMessage httpRequest,
            Func<AzureOperationResponse<R>, JsonSerializerSettings, Task> deserializeResponse = null,
            CancellationToken cancellationToken = default(CancellationToken));

        Task DeserializeJsonResponse<R>(AzureOperationResponse<R> result, JsonSerializerSettings deserializationSettings);
    }

    //public interface IHttpServiceClientFactory IHttpServiceClient

    // public interface IHttpServiceClient<T> : IHttpServiceClient { }
}