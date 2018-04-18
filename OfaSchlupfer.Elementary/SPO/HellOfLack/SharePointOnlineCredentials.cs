namespace OfaSchlupfer.SPO {
    using System;
    using System.Collections;
    using System.Net;
    using System.Net.Http;
    using System.Security;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using OfaSchlupfer.HttpAccess;

    internal sealed class SharePointOnlineCredentials {
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
                this.UserName = username;
                this._Password = password;
            } else {
                throw new ArgumentNullException(nameof(username));
            }
        }

        public async Task<string> GetAuthenticationCookieAsync(Uri url, bool refresh, bool alwaysThrowOnFailure) {
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
                var resultCookie = await sharePointOnlineAuthenticationProvider.GetAuthenticationCookieAsync(uri, this.UserName, this._Password, alwaysThrowOnFailure, this.ExecutingWebRequest);
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
    }
}
