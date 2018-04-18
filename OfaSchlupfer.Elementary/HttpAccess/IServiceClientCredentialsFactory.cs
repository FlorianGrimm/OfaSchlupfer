namespace OfaSchlupfer.HttpAccess {
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using OfaSchlupfer.Elementary;

    public interface IServiceClientCredentialsFactory {
        ServiceClientCredentials CreateServiceClientCredentials(RepositoryConnectionString connectionString);
    }
    public interface IServiceClientCredentialsConcreteFactory : IServiceClientCredentialsFactory {
        string GetAuthenticationMode();
    }

    public interface IServiceClientCredentialsDispatcherFactory : IServiceClientCredentialsFactory {
    }

#warning TODO thinkoif IHttpServiceClientFactory
#if no
    public interface IHttpServiceClientFactory {

        ServiceClientCredentials CreateServiceClientCredentials(RepositoryConnectionString connectionString);

        IHttpServiceClient CreateHttpClient(RepositoryConnectionString connectionString, ServiceClientCredentials credentials);
    }

    public interface IHttpServiceClientTypedFactory : IHttpServiceClientFactory {
        string GetAuthenticationMode();
    }

    public interface IHttpServiceClientDispatcherFactory : IHttpServiceClientFactory {
        IHttpServiceClient CreateHttpClient(RepositoryConnectionString connectionString);
    }

    //public interface IHttpServiceClientCredentials {
    //bool IsSupportedGetAuthenticationAsync { get; }
    //bool IsSupportedGetAuthentication { get; }

    //Task<IHttpClientCredentialsData> GetAuthenticationAsync(Uri uri, bool refresh, bool alwaysThrowOnFailure);
    //IHttpClientCredentialsData GetAuthentication(Uri uri, bool refresh, bool alwaysThrowOnFailure);

    //void ConfigureHttpClientHandler(HttpClientHandler httpClientHandler, IHttpClientCredentialsData data);

    //event EventHandler<WebRequestEventArgs> ExecutingWebRequest;

    //void ConfigureHttpClient(HttpClient httpClient, IHttpClientCredentialsData httpClientCredentialsData);
    //}

    //public interface IHttpClientCredentialsData {
    //}

    //public interface IHttpClientCookieCredentials : ICredentials, IHttpServiceClientCredentials {
    //}
#endif
}