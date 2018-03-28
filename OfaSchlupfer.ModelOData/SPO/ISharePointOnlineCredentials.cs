namespace OfaSchlupfer.ModelOData.SPO {
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using OfaSchlupfer.Elementary;

    public interface ISharePointOnlineFactory {
        ISharePointOnlineCredentials CreateCredentials(string username, System.Security.SecureString password);

        ISharePointOnlineHttpClient CreateHttpClient(RepositoryConnectionString connectionString);
    }

    public interface ISharePointOnlineCredentials : ICredentials {
        string GetAuthenticationCookie(Uri url);

        string GetAuthenticationCookie(Uri url, bool alwaysThrowOnFailure);

        string GetAuthenticationCookie(Uri url, bool refresh, bool alwaysThrowOnFailure);

        event EventHandler<SharePointOnlineCredentialsWebRequestEventArgs> ExecutingWebRequest;
    }

    public interface ISharePointOnlineHttpClient : System.IDisposable {
        bool AuthenticateAsync();

        Task<string> GetAsync(string requestUrl, Action<HttpClient> configureHttpClient);
    }
}