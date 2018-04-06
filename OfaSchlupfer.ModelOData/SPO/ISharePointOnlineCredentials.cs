namespace OfaSchlupfer.ModelOData.SPO {
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using OfaSchlupfer.Elementary;
    using OfaSchlupfer.HttpAccess;

    public interface ISharePointOnlineClientFactory : IHttpClientFactory, IHttpClientTypedFactory {
        // weichei
        //ISharePointOnlineCredentials CreateCredentials(string username, string password);

        //weichei
        //ISharePointOnlineHttpClient CreateSPOHttpClient(RepositoryConnectionString connectionString);
    }

    public interface ISharePointOnlineCredentials : ICredentials, IHttpClientCookieCredentials {
        // weichei
        //string GetAuthenticationCookie(Uri url);
        //string GetAuthenticationCookie(Uri url, bool alwaysThrowOnFailure);

        //string GetAuthenticationCookie(Uri url, bool refresh, bool alwaysThrowOnFailure);

        //event EventHandler<WebRequestEventArgs> ExecutingWebRequest;
    }

    public interface ISharePointOnlineHttpClient : IHttpClient, System.IDisposable {
        // weichei
        // bool Authenticate();

        //Task<string> GetAsStringAsync(string requestUrl, Action<HttpClient> configureHttpClient);
    }
}