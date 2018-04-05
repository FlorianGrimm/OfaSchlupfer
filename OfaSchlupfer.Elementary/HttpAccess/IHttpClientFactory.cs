namespace OfaSchlupfer.HttpAccess {
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using OfaSchlupfer.Elementary;


    public interface IHttpClientFactory {
        IHttpClient CreateHttpClient(RepositoryConnectionString connectionString);
    }

    public interface IHttpClientTypedFactory : IHttpClientFactory {
        string GetAuthenticationMode();
    }

    public interface IHttpClientDispatcherFactory : IHttpClientFactory {

    }

    public interface ICookieCredentials : ICredentials {
        bool IsSupportedGetAuthenticationCookie { get; }
        bool IsSupportedGetAuthenticationCookieAsync { get; }

        string GetAuthenticationCookie(Uri url, bool refresh, bool alwaysThrowOnFailure);
        Task<string> GetAuthenticationCookieAsync(Uri url, bool refresh, bool alwaysThrowOnFailure);

        event EventHandler<WebRequestEventArgs> ExecutingWebRequest;
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
    }
}
