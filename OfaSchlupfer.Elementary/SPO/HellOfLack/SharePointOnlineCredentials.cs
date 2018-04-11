namespace OfaSchlupfer.SPO {
    using System;
    using System.Collections;
    using System.Net;
    using System.Net.Http;
    using System.Security;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using OfaSchlupfer.HttpAccess;

    internal sealed class SharePointOnlineCredentials 
        : ICredentials, ISharePointOnlineCredentials {
        private class CookieCacheEntry {
            public string Cookie;

            public DateTime Expires;

            public bool IsValid {
                get {
                    return DateTime.UtcNow < this.Expires;
                }
            }
        }

        private const int CacheHours = 1;

        private ILogger _Logger;

        private string _Password;

        private readonly Hashtable _CachedCookies;

        public string UserName { get; }

        public bool IsSupportedGetAuthenticationAsync => false;

        public bool IsSupportedGetAuthentication => true;

        public event EventHandler<WebRequestEventArgs> ExecutingWebRequest;

        public SharePointOnlineCredentials(string username, string password, ILogger logger) {
            if (string.IsNullOrEmpty(username)) {
                throw new ArgumentNullException(nameof(username));
            }
            this._Logger = logger;
            this._CachedCookies = new Hashtable();
            int num = username.IndexOf('@');
            if (num >= 0 && num != username.Length - 1) {
                if (password == null) {
                    throw new ArgumentNullException(nameof(password));
                }
                // SharePointOnlineAuthenticationModule.EnsureRegistered();
                this.UserName = username;
                this._Password = password;
            } else {
                throw new ArgumentNullException(nameof(username));
            }
        }

        public NetworkCredential GetCredential(Uri uri, string authType) => null;

        public Task<IHttpClientCredentialsData> GetAuthenticationAsync(Uri uri, bool refresh, bool alwaysThrowOnFailure)
            => Task.FromResult<IHttpClientCredentialsData>(
                    new SharePointOnlineCredentialsData(uri, this.GetAuthenticationCookie(uri, refresh, alwaysThrowOnFailure))
                );

        public IHttpClientCredentialsData GetAuthentication(Uri uri, bool refresh, bool alwaysThrowOnFailure)
            => new SharePointOnlineCredentialsData(uri, this.GetAuthenticationCookie(uri, refresh, alwaysThrowOnFailure));

        public string GetAuthenticationCookie(Uri url, bool refresh, bool alwaysThrowOnFailure) {
            if (url == (Uri)null) {
                throw new ArgumentNullException(nameof(url));
            }
            if (!url.IsAbsoluteUri) {
                throw new ArgumentNullException(nameof(url));
            }
            Uri uri = new Uri(url, "/");
            if (!refresh) {
                CookieCacheEntry cookieCacheEntry;
                lock (this._CachedCookies) {
                    cookieCacheEntry = (CookieCacheEntry)this._CachedCookies[uri];
                }
                if (cookieCacheEntry != null && cookieCacheEntry.IsValid) {
                    this._Logger?.LogInformation("Get cookie from cache for URL {0}", uri);
                    return cookieCacheEntry.Cookie;
                }
            }
            {
                var sharePointOnlineAuthenticationProvider = new SharePointOnlineAuthenticationProvider(this._Logger);
                var resultCookie = sharePointOnlineAuthenticationProvider.GetAuthenticationCookie(uri, this.UserName, this._Password, alwaysThrowOnFailure, this.ExecutingWebRequest);
                if (!string.IsNullOrEmpty(resultCookie)) {
                    this._Logger?.LogTrace("Put cookie in cache for URL {0}", uri);
                    lock (this._CachedCookies) {
                        this._CachedCookies[uri] = new CookieCacheEntry {
                            Cookie = resultCookie,
                            Expires = DateTime.UtcNow.AddHours(1.0)
                        };
                        return resultCookie;
                    }
                }
            }
            return null;
        }

        public Task<string> GetAuthenticationCookieAsync(Uri url, bool refresh, bool alwaysThrowOnFailure) {
            var result = this.GetAuthenticationCookie(url, refresh, alwaysThrowOnFailure);
            return Task.FromResult(result);
        }

        public void ConfigureHttpClientHandler(HttpClientHandler httpClientHandler, IHttpClientCredentialsData data) {
            var spoData = (SharePointOnlineCredentialsData)data;
            httpClientHandler.Credentials = this;
            httpClientHandler.CookieContainer.SetCookies(spoData.Uri, spoData.Cookie);
        }

        public void ConfigureHttpClient(HttpClient httpClient, IHttpClientCredentialsData httpClientCredentialsData) {
            // do nothing
        }
    }
    public class SharePointOnlineCredentialsData : IHttpClientCredentialsData {
        public readonly Uri Uri;
        public readonly string Cookie;

        public SharePointOnlineCredentialsData(Uri uri, string cookie) {
            this.Uri = uri;
            this.Cookie = cookie;
        }
    }
}
