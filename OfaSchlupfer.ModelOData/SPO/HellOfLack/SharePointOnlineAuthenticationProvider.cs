#define DontUseRegistry
namespace OfaSchlupfer.ModelOData.SPO {
    using Microsoft.Extensions.Logging;
    using Microsoft.Win32;
    using OfaSchlupfer.HttpAccess;
    using System;
    using System.Collections.Specialized;
    using System.Net;
    using System.Net.Security;
    using System.Runtime.InteropServices;
    using System.Security;

    internal sealed class SharePointOnlineAuthenticationProvider {
        private class IdcrlHeader {
            public string IdcrlType;

            public string ServiceTarget;

            public string ServicePolicy;

            public string Endpoint;
        }

#if UseRegistry
        private static string _idcrlEnvironmentCache;

        private string IdcrlServiceEnvironment {
            get {
                string text = SharePointOnlineAuthenticationProvider._idcrlEnvironmentCache;
                if (text == null) {
                    text = IdcrlConstants.ENV_PRODUCTION;
                    RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(IdcrlConstants.REGKEY_MSOIdentityCRL);
                    if (registryKey != null) {
                        string text2 = (string)registryKey.GetValue(IdcrlConstants.REGVAL_ServiceEnvironment, null);
                        if (string.Compare(text2, IdcrlConstants.ENV_INT_MSO, StringComparison.OrdinalIgnoreCase) == 0) {
                            text = "INT-MSO";
                        } else if (string.Equals(text2, IdcrlConstants.ENV_PPE_MSO, StringComparison.OrdinalIgnoreCase)) {
                            text = "PPE-MSO";
                        }
                        registryKey.Close();
                    }
                    this._Logger.LogWarning("IdcrlServiceEnvironment={0}", text);
                    SharePointOnlineAuthenticationProvider._idcrlEnvironmentCache = text;
                }
                return text;
            }
        }
#endif
        private ILogger _Logger;

        public SharePointOnlineAuthenticationProvider(ILogger logger) {
            this._Logger = logger;

        }
        public string GetAuthenticationCookie(Uri url, string username, string password, bool alwaysThrowOnFailure, EventHandler<WebRequestEventArgs> executingWebRequest) {
            if (url == (Uri)null) {
                throw new ArgumentNullException("url");
            }
            if (string.IsNullOrEmpty(username)) {
                throw new ArgumentNullException("username");
            }
            if (password == null) {
                throw new ArgumentNullException("password");
            }
            IdcrlHeader idcrlHeader = this.GetIdcrlHeader(url, alwaysThrowOnFailure, executingWebRequest);
            if (idcrlHeader == null) {
                this._Logger.LogWarning("Cannot get IDCRL header for {0}", url);
                if (alwaysThrowOnFailure) {
                    throw new ClientRequestException($"CannotContactSite {url}");
                }
                return null;
            }
#if UseRegistry
            IdcrlEnvironment env = (IdcrlEnvironment)((string.Compare(IdcrlServiceEnvironment, "INT-MSO", StringComparison.OrdinalIgnoreCase) == 0) ? 1 : (string.Equals(IdcrlServiceEnvironment, "PPE-MSO", StringComparison.OrdinalIgnoreCase) ? 2 : 0));
            IdcrlAuth idcrlAuth = new IdcrlAuth(env, executingWebRequest, this._Logger);
#else
            IdcrlAuth idcrlAuth = new IdcrlAuth(executingWebRequest, this._Logger);
#endif
            //string password2 = SharePointOnlineAuthenticationProvider.FromSecureString(password);
            string serviceToken = idcrlAuth.GetServiceToken(username, password, idcrlHeader.ServiceTarget, idcrlHeader.ServicePolicy);
            if (string.IsNullOrEmpty(serviceToken)) {
                this._Logger.LogWarning("Cannot get IDCRL ticket for username {0}", username);
                if (alwaysThrowOnFailure) {
                    throw new IdcrlException("PPCRL_REQUEST_E_UNKNOWN  -2147186615");
                }
                return null;
            }
            return this.GetCookie(url, idcrlHeader.Endpoint, serviceToken, alwaysThrowOnFailure, executingWebRequest);
        }

        private string GetCookie(Uri url, string endpoint, string ticket, bool throwIfFail, EventHandler<WebRequestEventArgs> executingWebRequest) {
            Uri uri = new Uri(url, endpoint);
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            CookieContainer cookieContainer2 = httpWebRequest.CookieContainer = new CookieContainer();
            httpWebRequest.Headers[HttpRequestHeader.Authorization] = IdcrlConstants.BPOSIDCRL_AUTHORIZATION_HEADER_PREFIX + ticket;
            ((NameValueCollection)httpWebRequest.Headers)[IdcrlConstants.HEADER_IDCRL_AUTH_ACCEPTED] = "t";
            if (executingWebRequest != null) {
                executingWebRequest(this, new WebRequestEventArgs(httpWebRequest));
            }
            WebResponse response = httpWebRequest.GetResponse();
            string cookieHeader = cookieContainer2.GetCookieHeader(uri);
            if (string.IsNullOrWhiteSpace(cookieHeader)) {
                UriBuilder uriBuilder = new UriBuilder(uri);
                uriBuilder.Host = httpWebRequest.Host;
                this._Logger.LogInformation("Try get cookie using {0}", uriBuilder.ToString());
                cookieHeader = cookieContainer2.GetCookieHeader(uriBuilder.Uri);
                this._Logger.LogWarning("Get cookie using {0} and cookie value is {0}", uriBuilder.ToString(), cookieHeader);
            }
            if (response != null) {
                response.Close();
            }
            if (string.IsNullOrWhiteSpace(cookieHeader)) {
                this._Logger.LogWarning("Cannot get cookie for {0}", url);
                if (throwIfFail) {
                    throw new ClientRequestException($"Cannot get cookie for {url}.");
                }
            }
            return cookieHeader;
        }

        private IdcrlHeader GetIdcrlHeader(Uri url, bool alwaysThrowOnFailure, EventHandler<WebRequestEventArgs> executingWebRequest) {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            ((NameValueCollection)httpWebRequest.Headers)[IdcrlConstants.HEADER_IDCRL_AUTH_ACCEPTED] = "t";
            httpWebRequest.AuthenticationLevel = AuthenticationLevel.None;
            if (executingWebRequest != null) {
                executingWebRequest(this, new WebRequestEventArgs(httpWebRequest));
            }
            HttpWebResponse httpWebResponse = null;
            try {
                httpWebResponse = (httpWebRequest.GetResponse() as HttpWebResponse);
            } catch (WebException ex) {
                this._Logger.LogWarning("Exception in request. Url={0}, WebException={1}", url, ex);
                httpWebResponse = (ex.Response as HttpWebResponse);
                if (!alwaysThrowOnFailure) {
                    goto end_IL_0048;
                }
                if (httpWebResponse != null) {
                    if (httpWebResponse.StatusCode == HttpStatusCode.Forbidden) {
                        goto end_IL_0048;
                    }
                    if (httpWebResponse.StatusCode == HttpStatusCode.Unauthorized) {
                        goto end_IL_0048;
                    }
                }
                throw;
                end_IL_0048:;
            }
            if (httpWebResponse == null) {
                this._Logger.LogError("Cannot get response for request to {0}", url);
                if (alwaysThrowOnFailure) {
                    throw new ClientRequestException($"Cannot get response for request to  {url}");
                }
                return null;
            }
            string webResponseHeader = IdcrlUtility.GetWebResponseHeader(httpWebResponse);
            HttpStatusCode statusCode = httpWebResponse.StatusCode;
            this._Logger.LogWarning("Response.StatusCode={0}, Headers={1}", statusCode, webResponseHeader);
            string text = ((NameValueCollection)httpWebResponse.Headers)[IdcrlConstants.HEADER_IDCRL_AUTH_PARAMS_V1];
            if (string.IsNullOrEmpty(text)) {
                text = httpWebResponse.Headers[HttpResponseHeader.WwwAuthenticate];
            }
            httpWebResponse.Close();
            this._Logger.LogWarning("IdcrlHeader={0}", text);
            return this.ParseIdcrlHeader(text, url, statusCode, webResponseHeader, alwaysThrowOnFailure);
        }

        private IdcrlHeader ParseIdcrlHeader(string headerValue, Uri url, HttpStatusCode statusCode, string allResponseHeaders, bool alwaysThrowOnFailure) {
            if (string.IsNullOrWhiteSpace(headerValue)) {
                this._Logger.LogWarning("IDCRL header value is empty");
                if (alwaysThrowOnFailure) {
                    throw new NotSupportedException($"SharePoint ClientCredentials are NOT supported {url.OriginalString} {statusCode} {allResponseHeaders}.");
                }
                return null;
            }
            IdcrlHeader idcrlHeader = new IdcrlHeader();
            string[] array = headerValue.Split(',');
            foreach (string text in array) {
                string text2 = text.Trim();
                string[] array2 = text2.Split('=');
                if (array2.Length == 2) {
                    array2[0] = array2[0].Trim().ToUpperInvariant();
                    array2[1] = array2[1].Trim(' ', '"');
                    switch (array2[0]) {
                        case IdcrlConstants.IDCRL_PARAM_IDCRL_TYPE/*"IDCRL TYPE"*/:
                            idcrlHeader.IdcrlType = array2[1];
                            break;
                        case IdcrlConstants.IDCRL_PARAM_ENDPOINT /*"ENDPOINT"*/:
                            idcrlHeader.Endpoint = array2[1];
                            break;
                        case IdcrlConstants.IDCRL_PARAM_ROOTDOMAIN /* "ROOTDOMAIN" */:
                            idcrlHeader.ServiceTarget = array2[1];
                            break;
                        case IdcrlConstants.IDCRL_PARAM_POLICY /* "POLICY" */:
                            idcrlHeader.ServicePolicy = array2[1];
                            break;
                    }
                }
            }
            if (idcrlHeader.IdcrlType != IdcrlConstants.IDCRLTYPE_BPOSIDRL
                || string.IsNullOrEmpty(idcrlHeader.ServicePolicy)
                || string.IsNullOrEmpty(idcrlHeader.ServiceTarget)
                || string.IsNullOrEmpty(idcrlHeader.Endpoint)) {
                this._Logger.LogWarning("Cannot extract required information from IDCRL header. Header={0}, IdcrlType={1}, ServicePolicy={2}, ServiceTarget={3}, Endpoint={4}", headerValue, idcrlHeader.IdcrlType, idcrlHeader.ServicePolicy, idcrlHeader.ServiceTarget, idcrlHeader.Endpoint);
                if (alwaysThrowOnFailure) {
                    throw new ClientRequestException($"Invalid IDCRL Header {url.OriginalString}, {headerValue}, {statusCode}, {allResponseHeaders}");
                }
                idcrlHeader = null;
            }
            return idcrlHeader;
        }

        private static string FromSecureString(SecureString value) {
            IntPtr intPtr = Marshal.SecureStringToBSTR(value);
            if (intPtr == IntPtr.Zero) {
                return string.Empty;
            }
            try {
                return Marshal.PtrToStringBSTR(intPtr);
            } finally {
                Marshal.FreeBSTR(intPtr);
            }
        }

        internal bool DoesSupportIdcrl(Uri uri) {
            if (uri == (Uri)null) {
                throw new ArgumentNullException("uri");
            }
            return this.GetIdcrlHeader(uri, true, null) != null;
        }
    }
#if UseRegistry
    internal enum IdcrlEnvironment {
        Production,
        Int,
        Ppe
    }
#endif
}
