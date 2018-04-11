namespace OfaSchlupfer.SPO {
    using System;
    using System.Net;

    internal class SharePointOnlineAuthenticationModule : IAuthenticationModule {
        private const string EmptyAuthorization = " ";

        private static object s_lock = new object();

        private static SharePointOnlineAuthenticationModule _Instance;

        public string AuthenticationType => "SPOIDCRL";

        public bool CanPreAuthenticate => true;

        private SharePointOnlineAuthenticationModule() {
        }

        public Authorization Authenticate(string challenge, WebRequest request, ICredentials credentials) {
            SharePointOnlineCredentials sharePointOnlineCredentials = credentials as SharePointOnlineCredentials;
            if (sharePointOnlineCredentials != null
                && this.GetSpoAuthCookieAndUpdateRequest(request, sharePointOnlineCredentials, false)) {
                return new Authorization(" ");
            }
            return null;
        }

        public Authorization PreAuthenticate(WebRequest request, ICredentials credentials) {
            SharePointOnlineCredentials sharePointOnlineCredentials = credentials as SharePointOnlineCredentials;
            if (sharePointOnlineCredentials != null) {
                this.GetSpoAuthCookieAndUpdateRequest(request, sharePointOnlineCredentials, true);
            }
            return null;
        }

        private bool GetSpoAuthCookieAndUpdateRequest(WebRequest request, SharePointOnlineCredentials spoCredentials, bool preAuthentication) {
            string text = request.RequestUri.ToString();
            int pos = text.IndexOf('?');
            if (pos > 0) {
                text = text.Substring(0, pos);
            }
            pos = text.IndexOf('#');
            if (pos > 0) {
                text = text.Substring(0, pos);
            }
            pos = text.IndexOf("/_vti_bin", StringComparison.OrdinalIgnoreCase);
            if (pos > 0) {
                text = text.Substring(0, pos);
            }
            pos = text.IndexOf("/_api", StringComparison.OrdinalIgnoreCase);
            if (pos > 0) {
                text = text.Substring(0, pos);
            }
            Uri url = new Uri(text);
            string authenticationCookie;
            if (preAuthentication) {
                authenticationCookie = spoCredentials.GetAuthenticationCookie(url, false, true);
                if (string.IsNullOrEmpty(authenticationCookie)) {
                    authenticationCookie = spoCredentials.GetAuthenticationCookie(url, true, true);
                }
            } else {
                authenticationCookie = spoCredentials.GetAuthenticationCookie(url, true, true);
            }
            if (!string.IsNullOrEmpty(authenticationCookie)) {
                request.Headers[HttpRequestHeader.Cookie] = authenticationCookie;
                return true;
            }
            return false;
        }

        internal static void EnsureRegistered() {
            if (SharePointOnlineAuthenticationModule._Instance == null) {
                lock (SharePointOnlineAuthenticationModule.s_lock) {
                    if (SharePointOnlineAuthenticationModule._Instance == null) {
                        SharePointOnlineAuthenticationModule._Instance = new SharePointOnlineAuthenticationModule();
                        AuthenticationManager.Register(SharePointOnlineAuthenticationModule._Instance);
                    }
                }
            }
        }
    }
}
