namespace OfaSchlupfer.HttpAccess {
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using Microsoft.Rest;
    using Newtonsoft.Json;

    public class HttpClientDynamic
        : ServiceClient<HttpClientDynamic> {
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
        public HttpClientDynamic(
            System.Uri baseUri,
            ServiceClientCredentials credentials,
            HttpClientHandler rootHandler,
            params DelegatingHandler[] handlers
            ) : base(rootHandler ?? CreateRootHandler(), handlers) {
            this.Credentials = credentials;
            this.Credentials?.InitializeServiceClient(this);

        }
    }
}
