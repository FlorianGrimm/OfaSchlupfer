namespace OfaSchlupfer.HttpAccess {
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using OfaSchlupfer.Elementary;


    public interface IHttpClientFactory {

        IHttpClientCredentials CreateHttpClientCredentials(RepositoryConnectionString connectionString);

        IHttpClient CreateHttpClient(RepositoryConnectionString connectionString, IHttpClientCredentials credentials);
    }

    public interface IHttpClientTypedFactory : IHttpClientFactory {
        string GetAuthenticationMode();
    }

    public interface IHttpClientDispatcherFactory : IHttpClientFactory {
        IHttpClient CreateHttpClient(RepositoryConnectionString connectionString);
    }

    public interface IHttpClientCredentials {
        bool IsSupportedGetAuthenticationAsync { get; }
        bool IsSupportedGetAuthentication { get; }

        Task<IHttpClientCredentialsData> GetAuthenticationAsync(Uri uri, bool refresh, bool alwaysThrowOnFailure);
        IHttpClientCredentialsData GetAuthentication(Uri uri, bool refresh, bool alwaysThrowOnFailure);

        void ConfigureHttpClientHandler(HttpClientHandler httpClientHandler, IHttpClientCredentialsData data);

        event EventHandler<WebRequestEventArgs> ExecutingWebRequest;

        void ConfigureHttpClient(HttpClient httpClient, IHttpClientCredentialsData httpClientCredentialsData);
    }

    public interface IHttpClientCredentialsData {
    }

    //HttpClientCookieCredentialsData
    public interface IHttpClientCookieCredentials : ICredentials, IHttpClientCredentials {
        //bool IsSupportedGetAuthenticationCookie { get; }
        //bool IsSupportedGetAuthenticationCookieAsync { get; }

        //IHttpClientCredentialsData GetAuthenticationCookie(Uri url, bool refresh, bool alwaysThrowOnFailure);
        //Task<IHttpClientCredentialsData> GetAuthenticationCookieAsync(Uri url, bool refresh, bool alwaysThrowOnFailure);
    }



    public interface IHttpClient : System.IDisposable {
        Task<string> GetAsStringAsync(
            string requestUrl,
            Action<System.Net.Http.HttpClient> configureHttpClient,
            Func<HttpResponseMessage, int, bool> shouldRetry);

        Task<R> ExecuteAsync<R>(
           string requestUrl,
           Action<System.Net.Http.HttpClient> configureHttpClient,
           CancellationToken cancellationToken,
           Func<System.Net.Http.HttpClient, string, CancellationToken, Task<HttpResponseMessage>> executeAsync,
           Func<HttpContent, Task<R>> readAsync,
           Func<HttpResponseMessage, int, bool> shouldRetry
           );

        Task<R> SendAsync<R>(
           HttpRequestMessage request,
           Action<System.Net.Http.HttpClient> configureHttpClient,
           CancellationToken cancellationToken,
           Func<System.Net.Http.HttpClient, System.Net.Http.HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> executeAsync,
           Func<HttpContent, Task<R>> readAsync,
           Func<HttpResponseMessage, int, bool> shouldRetry
           );
    }
}
