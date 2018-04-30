namespace OfaSchlupfer.SPO {
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Linq;
    using Microsoft.Extensions.Logging;
    using OfaSchlupfer.HttpAccess;

    internal class IdcrlAuth {
        private class UserRealmInfo {
            public string STSAuthUrl {
                get;
                set;
            }

            public bool IsFederated {
                get;
                set;
            }
        }

        private class FederationProviderInfo {
            public string UserRealmServiceUrl {
                get;
                set;
            }

            public string SecurityTokenServiceUrl {
                get;
                set;
            }

            public string FederationTokenIssuer {
                get;
                set;
            }
        }

        private class FederationProviderInfoCacheEntry {
            public FederationProviderInfo Value;

            public DateTime Expires;
        }

        private class FederationProviderInfoCache {
            private const int CacheLifetimeMinutes = 30;

            private readonly object m_lock = new object();

            private readonly Dictionary<string, FederationProviderInfoCacheEntry> m_cache = new Dictionary<string, FederationProviderInfoCacheEntry>(StringComparer.OrdinalIgnoreCase);

            public bool TryGetValue(string domainname, out FederationProviderInfo value) {
                lock (this.m_lock) {
                    if (this.m_cache.TryGetValue(domainname, out var federationProviderInfoCacheEntry) && federationProviderInfoCacheEntry.Expires > DateTime.UtcNow) {
                        value = federationProviderInfoCacheEntry.Value;
                        return true;
                    }
                }
                value = null;
                return false;
            }

            public void Put(string domainname, FederationProviderInfo value) {
                lock (this.m_lock) {
                    this.m_cache[domainname] = new FederationProviderInfoCacheEntry {
                        Value = value,
                        Expires = DateTime.UtcNow.AddMinutes(30.0)
                    };
                }
            }
        }

        private readonly ILogger _Logger;
#if UseRegistry
        private IdcrlEnvironment m_env;
#endif
        private string m_userRealmServiceUrl;
        private string m_securityTokenServiceUrl;
        private string m_federationTokenIssuer;

        private readonly EventHandler<WebRequestEventArgs> m_executingWebRequest;

        private static Dictionary<string, int> s_partnerSoapErrorMap = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
        {
            {
                "InvalidRequest",
                -2147186474
            },
            {
                "FailedAuthentication",
                -2147186446
            },
            {
                "RequestFailed",
                -2147186473
            },
            {
                "InvalidSecurityToken",
                -2147186472
            },
            {
                "AuthenticationBadElements",
                -2147186471
            },
            {
                "BadRequest",
                -2147186470
            },
            {
                "ExpiredData",
                -2147186469
            },
            {
                "InvalidTimeRange",
                -2147186468
            },
            {
                "InvalidScope",
                -2147186467
            },
            {
                "RenewNeeded",
                -2147186466
            },
            {
                "UnableToRenew",
                -2147186465
            }
        };

        private static FederationProviderInfoCache s_FederationProviderInfoCache = new FederationProviderInfoCache();

        private string UserRealmServiceUrl => this.m_userRealmServiceUrl;

        private string ServiceTokenUrl => this.m_securityTokenServiceUrl;

        private string FederationTokenIssuer => this.m_federationTokenIssuer;

#if UseRegistry
        public IdcrlAuth(IdcrlEnvironment env, EventHandler<WebRequestEventArgs> executingWebRequest, ILogger logger) {
            this.m_env = env;
            this._Logger = logger;
            this._Logger?.LogInformation("IDCRL Environment {0}", env);
            if (this.m_env == IdcrlEnvironment.Production) {
                this.m_userRealmServiceUrl = "https://login.microsoftonline.com/GetUserRealm.srf";
                this.m_securityTokenServiceUrl = "https://login.microsoftonline.com/rst2.srf";
                this.m_federationTokenIssuer = "urn:federation:MicrosoftOnline";
            } else if (this.m_env == IdcrlEnvironment.Ppe) {
                this.m_userRealmServiceUrl = "https://login.windows-ppe.net/GetUserRealm.srf";
                this.m_securityTokenServiceUrl = "https://login.windows-ppe.net/rst2.srf";
                this.m_federationTokenIssuer = "urn:federation:MicrosoftOnline";
            } else {
                this.m_userRealmServiceUrl = "https://login.microsoftonline-int.com/GetUserRealm.srf";
                this.m_securityTokenServiceUrl = "https://login.microsoftonline-int.com/rst2.srf";
                this.m_federationTokenIssuer = "urn:federation:MicrosoftOnline-int";
            }
            this.m_executingWebRequest = executingWebRequest;
        }
#else
        public IdcrlAuth(EventHandler<WebRequestEventArgs> executingWebRequest, ILogger logger) {
            this._Logger = logger;
            this.m_userRealmServiceUrl = IdcrlMessageConstants.UserRealmServiceUrl_Prod;
            this.m_securityTokenServiceUrl = IdcrlMessageConstants.SecurityTokenServiceUrl_Prod;
            this.m_federationTokenIssuer = IdcrlMessageConstants.FederationTokenIssuer_Prod;
            this.m_executingWebRequest = executingWebRequest;
        }
#endif



        public async Task<string> GetServiceTokenAsync(string username, string password, string serviceTarget, string servicePolicy) {
            if (string.IsNullOrEmpty(username)) {
                throw new ArgumentNullException("username");
            }
            if (string.IsNullOrEmpty(password)) {
                throw new ArgumentNullException("password");
            }
            if (string.IsNullOrEmpty(serviceTarget)) {
                throw new ArgumentNullException("serviceTarget");
            }
            await this.InitFederationProviderInfoForUserAsync(username);
            UserRealmInfo userRealm = await this.GetUserRealmAsync(username);
            if (userRealm.IsFederated) {
                string partnerTicketFromAdfs = await this.GetPartnerTicketFromAdfsAsync(userRealm.STSAuthUrl, username, password);
                return await this.GetServiceTokenAsync(partnerTicketFromAdfs, serviceTarget, servicePolicy);
            }
            string securityXml = this.BuildWsSecurityUsingUsernamePassword(username, password);
            return await this.GetServiceTokenAsync(securityXml, serviceTarget, servicePolicy);
        }

        private async Task<UserRealmInfo> GetUserRealmAsync(string login) {
            if (string.IsNullOrWhiteSpace(login)) {
                throw new ArgumentNullException("login");
            }
            string userRealmServiceUrl = this.UserRealmServiceUrl;
            string body = string.Format(CultureInfo.InvariantCulture, IdcrlMessageConstants.GetUserRealmMessage, new object[1]
            {
                Uri.EscapeDataString(login)
            });
            XDocument xDocument = await this.DoPostAsync(userRealmServiceUrl, IdcrlMessageConstants.GetUserRealmContentType, body, null);
            XAttribute xAttribute = xDocument.Root.Attribute("Success");
            if (xAttribute != null && string.Compare(xAttribute.Value, "true", StringComparison.OrdinalIgnoreCase) == 0) {
                XElement xElement = xDocument.Root.Element("NameSpaceType");
                if (xElement == null) {
                    this._Logger?.LogError("There is no NameSpaceType element in the response when get user realm for user {0}", login);
                    throw IdcrlAuth.CreateIdcrlException(-2147186539);
                }
                if (string.Compare(xElement.Value, "Federated", StringComparison.OrdinalIgnoreCase) != 0 && string.Compare(xElement.Value, "Managed", StringComparison.OrdinalIgnoreCase) != 0) {
                    this._Logger?.LogError("Unknown namespace type for user {0}", login);
                    throw IdcrlAuth.CreateIdcrlException(-2147186539);
                }
                UserRealmInfo userRealmInfo = new UserRealmInfo {
                    IsFederated = (0 == string.Compare(xElement.Value, "Federated", StringComparison.OrdinalIgnoreCase))
                };
                xElement = xDocument.Root.Element("STSAuthURL");
                if (xElement != null) {
                    userRealmInfo.STSAuthUrl = xElement.Value;
                }
                if (userRealmInfo.IsFederated && string.IsNullOrEmpty(userRealmInfo.STSAuthUrl)) {
                    this._Logger?.LogError("User {0} is a federated account, but there is no STSAuthUrl for the user.", login);
                    throw CreateIdcrlException(-2147186539);
                }
                this._Logger?.LogDebug("User={0}, IsFederated={1}, STSAuthUrl={2}", login, userRealmInfo.IsFederated, userRealmInfo.STSAuthUrl);
                return userRealmInfo;
            }
            this._Logger?.LogError("Failed to get user's realm for user {0}", login);
            throw CreateIdcrlException(-2147186539);
        }

        private async Task<string> GetPartnerTicketFromAdfsAsync(string adfsUrl, string username, string password) {
            string body = string.Format(
                CultureInfo.InvariantCulture,
                /*
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?><s:Envelope xmlns:s=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\" xmlns:saml=\"urn:oasis:names:tc:SAML:1.0:assertion\" xmlns:wsp=\"http://schemas.xmlsoap.org/ws/2004/09/policy\" xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\" xmlns:wsa=\"http://www.w3.org/2005/08/addressing\" xmlns:wssc=\"http://schemas.xmlsoap.org/ws/2005/02/sc\" xmlns:wst=\"http://schemas.xmlsoap.org/ws/2005/02/trust\"><s:Header><wsa:Action s:mustUnderstand=\"1\">http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Issue</wsa:Action><wsa:To s:mustUnderstand=\"1\">{0}</wsa:To><wsa:MessageID>{1}</wsa:MessageID><ps:AuthInfo xmlns:ps=\"http://schemas.microsoft.com/Passport/SoapServices/PPCRL\" Id=\"PPAuthInfo\"><ps:HostingApp>Managed IDCRL</ps:HostingApp><ps:BinaryVersion>6</ps:BinaryVersion><ps:UIVersion>1</ps:UIVersion><ps:Cookies></ps:Cookies><ps:RequestParams>AQAAAAIAAABsYwQAAAAxMDMz</ps:RequestParams></ps:AuthInfo><wsse:Security><wsse:UsernameToken wsu:Id=\"user\"><wsse:Username>{2}</wsse:Username><wsse:Password>{3}</wsse:Password></wsse:UsernameToken><wsu:Timestamp Id=\"Timestamp\"><wsu:Created>{4}</wsu:Created><wsu:Expires>{5}</wsu:Expires></wsu:Timestamp></wsse:Security></s:Header><s:Body><wst:RequestSecurityToken Id=\"RST0\"><wst:RequestType>http://schemas.xmlsoap.org/ws/2005/02/trust/Issue</wst:RequestType><wsp:AppliesTo><wsa:EndpointReference><wsa:Address>{6}</wsa:Address></wsa:EndpointReference></wsp:AppliesTo><wst:KeyType>http://schemas.xmlsoap.org/ws/2005/05/identity/NoProofKey</wst:KeyType></wst:RequestSecurityToken></s:Body></s:Envelope>",
                 */
                IdcrlMessageConstants.AdfsAuthMessage,
                IdcrlUtility.XmlValueEncode(adfsUrl),
                Guid.NewGuid().ToString(),
                IdcrlUtility.XmlValueEncode(username),
                IdcrlUtility.XmlValueEncode(password),
                DateTime.UtcNow.ToString("o", CultureInfo.InvariantCulture),
                DateTime.UtcNow.AddMinutes(10.0).ToString("o", CultureInfo.InvariantCulture),
                this.FederationTokenIssuer);
            XDocument xDocument = await this.DoPostAsync(adfsUrl, IdcrlMessageConstants.SoapContentType, body, this.HandleWebException);
            Exception soapException = this.GetSoapException(xDocument);
            if (soapException != null) {
                this._Logger?.LogError("SOAP error from {0}. Exception={1}", adfsUrl, soapException);
                throw soapException;
            }
            XElement elementAtPath = IdcrlUtility.GetElementAtPath(xDocument.Root, "{http://www.w3.org/2003/05/soap-envelope}Body", "{http://schemas.xmlsoap.org/ws/2005/02/trust}RequestSecurityTokenResponse", "{http://schemas.xmlsoap.org/ws/2005/02/trust}RequestedSecurityToken", "{urn:oasis:names:tc:SAML:1.0:assertion}Assertion");
            if (elementAtPath == null) {
                this._Logger?.LogError("Cannot get security assertion for user {0} from {1}", username, adfsUrl);
                throw CreateIdcrlException(-2147186451);
            }
            return elementAtPath.ToString(SaveOptions.DisableFormatting | SaveOptions.OmitDuplicateNamespaces);
        }

        private async Task< string> GetServiceTokenAsync(string securityXml, string serviceTarget, string servicePolicy) {
            string serviceTokenUrl = this.ServiceTokenUrl;
            string text = string.Empty;
            if (!string.IsNullOrEmpty(servicePolicy)) {
                text = string.Format(CultureInfo.InvariantCulture, "<wsp:PolicyReference URI=\"{0}\"></wsp:PolicyReference>", new object[1] { servicePolicy });
            }
            string body = string.Format(
                CultureInfo.InvariantCulture,
                /*
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?><S:Envelope xmlns:S=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\" xmlns:wsp=\"http://schemas.xmlsoap.org/ws/2004/09/policy\" xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\" xmlns:wsa=\"http://www.w3.org/2005/08/addressing\" xmlns:wst=\"http://schemas.xmlsoap.org/ws/2005/02/trust\"><S:Header><wsa:Action S:mustUnderstand=\"1\">http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Issue</wsa:Action><wsa:To S:mustUnderstand=\"1\">{0}</wsa:To><ps:AuthInfo xmlns:ps=\"http://schemas.microsoft.com/LiveID/SoapServices/v1\" Id=\"PPAuthInfo\"><ps:BinaryVersion>5</ps:BinaryVersion><ps:HostingApp>Managed IDCRL</ps:HostingApp></ps:AuthInfo><wsse:Security>{1}</wsse:Security></S:Header><S:Body><wst:RequestSecurityToken xmlns:wst=\"http://schemas.xmlsoap.org/ws/2005/02/trust\" Id=\"RST0\"><wst:RequestType>http://schemas.xmlsoap.org/ws/2005/02/trust/Issue</wst:RequestType><wsp:AppliesTo><wsa:EndpointReference><wsa:Address>{2}</wsa:Address></wsa:EndpointReference></wsp:AppliesTo>{3}</wst:RequestSecurityToken></S:Body></S:Envelope>\r\n",
                */
                IdcrlMessageConstants.AuthMessage,
                IdcrlUtility.XmlValueEncode(serviceTokenUrl),
                securityXml,
                IdcrlUtility.XmlValueEncode(serviceTarget),
                text);
            XDocument xDocument = await this.DoPostAsync(serviceTokenUrl, IdcrlMessageConstants.SoapContentType, body, this.HandleWebException);
            Exception soapException = GetSoapException(xDocument);
            if (soapException != null) {
                this._Logger?.LogError("Soap error from {0}. Exception={1}", serviceTokenUrl, soapException);
                throw soapException;
            }
            XElement elementAtPath = IdcrlUtility.GetElementAtPath(xDocument.Root, "{http://www.w3.org/2003/05/soap-envelope}Body", "{http://schemas.xmlsoap.org/ws/2005/02/trust}RequestSecurityTokenResponse", "{http://schemas.xmlsoap.org/ws/2005/02/trust}RequestedSecurityToken", "{http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd}BinarySecurityToken");
            if (elementAtPath == null) {
                this._Logger?.LogError("Cannot get binary security token for from {0}", serviceTokenUrl);
                throw IdcrlAuth.CreateIdcrlException(-2147186656);
            }
            return elementAtPath.Value;
        }

        private string BuildWsSecurityUsingUsernamePassword(string username, string password) {
            DateTime utcNow = DateTime.UtcNow;
            return string.Format(
                CultureInfo.InvariantCulture,
                "<wsse:UsernameToken wsu:Id=\"user\"><wsse:Username>{0}</wsse:Username><wsse:Password>{1}</wsse:Password></wsse:UsernameToken><wsu:Timestamp Id=\"Timestamp\"><wsu:Created>{2}</wsu:Created><wsu:Expires>{3}</wsu:Expires></wsu:Timestamp>\r\n",
                IdcrlUtility.XmlValueEncode(username),
                IdcrlUtility.XmlValueEncode(password),
                utcNow.ToString("o", CultureInfo.InvariantCulture),
                utcNow.AddDays(1.0).ToString("o", CultureInfo.InvariantCulture));
        }

        private async Task<XDocument> DoPostAsync(string url, string contentType, string body, Func<WebException, Exception> webExceptionHandler) {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = contentType;
            this._Logger?.LogDebug("Sending POST request to {0}", url);
            this.m_executingWebRequest?.Invoke(this, new WebRequestEventArgs(httpWebRequest));
            using (Stream stream = httpWebRequest.GetRequestStream()) {
                if (body != null) {
                    byte[] bytes = Encoding.UTF8.GetBytes(body);
                    stream.Write(bytes, 0, bytes.Length);
                }
            }
            try {
                var httpWebResponse = (HttpWebResponse)(await httpWebRequest.GetResponseAsync());
                if (httpWebResponse == null) {
                    this._Logger?.LogError("Unexpected response for POST request to {0}", url);
                    throw new InvalidOperationException();
                }
                using (httpWebResponse) {
                    using (TextReader textReader = new StreamReader(httpWebResponse.GetResponseStream())) {
                        string text = textReader.ReadToEnd();
                        this._Logger?.LogDebug("URL={0}, StatusCode={1}, ResponseText={2}", url, (int)httpWebResponse.StatusCode, text);
                        using (XmlReader reader = XmlReader.Create(new StringReader(text))) {
                            return XDocument.Load(reader);
                        }
                    }
                }
            } catch (WebException webException) {
                this._Logger?.LogError("URL={0}, WebException={1}", url, webException);
                if (webExceptionHandler == null) {
                    throw;
                } else {
                    Exception exceptionHandled = webExceptionHandler(webException);
                    if (exceptionHandled == null) {
                        throw;
                    }
                    throw exceptionHandled;
                }
            }
        }

        private Exception HandleWebException(WebException webException) {
            var httpWebResponse = (HttpWebResponse)webException.Response;
            if (httpWebResponse != null && httpWebResponse.ContentType != null && httpWebResponse.ContentType.IndexOf("application/soap+xml", StringComparison.OrdinalIgnoreCase) >= 0) {
                try {
                    using (TextReader textReader = new StreamReader(httpWebResponse.GetResponseStream())) {
                        string text = textReader.ReadToEnd();
                        this._Logger?.LogError("StatusCode={0}, ResponseText={1}", (int)httpWebResponse.StatusCode, text);
                        using (XmlReader reader = XmlReader.Create(new StringReader(text))) {
                            XDocument xdoc = XDocument.Load(reader);
                            return GetSoapException(xdoc);
                        }
                    }
                } catch (XmlException xmlException) {
                    this._Logger?.LogWarning("Error when read error response. Exception={0}", xmlException);
                } catch (IOException ioException) {
                    this._Logger?.LogWarning("Error when read error response. Exception={0}", ioException);
                }
            }
            return null;
        }

        private Exception GetSoapException(XDocument xdoc) {
            XElement elementAtPath = IdcrlUtility.GetElementAtPath(xdoc.Root, "{http://www.w3.org/2003/05/soap-envelope}Body", "{http://www.w3.org/2003/05/soap-envelope}Fault");
            if (elementAtPath == null) {
                return null;
            }
            XElement elementAtPathCode = IdcrlUtility.GetElementAtPath(xdoc.Root, "{http://www.w3.org/2003/05/soap-envelope}Body", "{http://www.w3.org/2003/05/soap-envelope}Fault", "{http://www.w3.org/2003/05/soap-envelope}Code", "{http://www.w3.org/2003/05/soap-envelope}Subcode", "{http://www.w3.org/2003/05/soap-envelope}Value");
            XElement elementAtPathValue = IdcrlUtility.GetElementAtPath(xdoc.Root, "{http://www.w3.org/2003/05/soap-envelope}Body", "{http://www.w3.org/2003/05/soap-envelope}Fault", "{http://www.w3.org/2003/05/soap-envelope}Detail", "{http://schemas.microsoft.com/Passport/SoapServices/SOAPFault}error", "{http://schemas.microsoft.com/Passport/SoapServices/SOAPFault}value");
            XElement elementAtPathInternalError = IdcrlUtility.GetElementAtPath(xdoc.Root, "{http://www.w3.org/2003/05/soap-envelope}Body", "{http://www.w3.org/2003/05/soap-envelope}Fault", "{http://www.w3.org/2003/05/soap-envelope}Detail", "{http://schemas.microsoft.com/Passport/SoapServices/SOAPFault}error", "{http://schemas.microsoft.com/Passport/SoapServices/SOAPFault}internalerror", "{http://schemas.microsoft.com/Passport/SoapServices/SOAPFault}text");
            string textCode = null;
            if (elementAtPathCode != null) {
                textCode = elementAtPathCode.Value;
                int num = textCode.IndexOf(':');
                if (num >= 0) {
                    textCode = textCode.Substring(num + 1);
                }
            }
            string textValue = null;
            if (elementAtPathValue != null) {
                textValue = elementAtPathValue.Value;
            }
            string textInternalError = null;
            if (elementAtPathInternalError != null) {
                textInternalError = elementAtPathInternalError.Value;
            }
            this._Logger?.LogError("PassportErrorCode={0}, PassportDetailCode={1}, PassportErrorText={2}", textCode, textValue, textInternalError);
            int errorCode;
            long errorCodeValue = default(long);
            if (string.IsNullOrEmpty(textValue)) {
                errorCode = IdcrlAuth.MapPartnerSoapFault(textCode);
            } else {
                if ((textValue.StartsWith("0x", StringComparison.OrdinalIgnoreCase) && long.TryParse(textValue.Substring(2), NumberStyles.HexNumber, (IFormatProvider)CultureInfo.InvariantCulture, out errorCodeValue))
                    || (long.TryParse(textValue, NumberStyles.Integer, (IFormatProvider)CultureInfo.InvariantCulture, out errorCodeValue))) {
                    errorCode = (int)errorCodeValue;
                    if (string.Compare(textCode, "FailedAuthentication", StringComparison.OrdinalIgnoreCase) == 0) {
                        errorCode = ((errorCode == -2147186639) ? errorCode : (-2147186655));
                    }
                } else {
                    errorCode = -2147186656;
                }
            }
            return IdcrlAuth.CreateIdcrlException(errorCode);
        }

        private static int MapPartnerSoapFault(string code) {
            if (IdcrlAuth.s_partnerSoapErrorMap.TryGetValue(code, out var result)) {
                return result;
            } else {
                return -2147186451;
            }
        }

        private static Exception CreateIdcrlException(int hr) {
            if (!IdcrlErrorCodes.TryGetErrorStringId(hr, out var resourceId)) {
                resourceId = "PPCRL_REQUEST_E_UNKNOWN";
            }
            return new IdcrlException(resourceId, hr);
        }

        private async Task InitFederationProviderInfoForUserAsync(string username) {
            int pos = username.IndexOf('@');
            if (pos >= 0 && pos != username.Length - 1) {
                string domainname = username.Substring(pos + 1);
                FederationProviderInfo federationProviderInfo = await this.GetFederationProviderInfoAsync(domainname);
                if (federationProviderInfo != null) {
                    this.m_userRealmServiceUrl = federationProviderInfo.UserRealmServiceUrl;
                    this.m_securityTokenServiceUrl = federationProviderInfo.SecurityTokenServiceUrl;
                    this.m_federationTokenIssuer = federationProviderInfo.FederationTokenIssuer;
                }
                this._Logger?.LogDebug("UserName={0}, UserRealmServiceUrl={1}, SecurityTokenServiceUrl={1}, FederationTokenIssuer={2}", username, this.m_userRealmServiceUrl, this.m_securityTokenServiceUrl, this.m_federationTokenIssuer);
                return;
            }
            throw new ArgumentException(nameof(username));
        }

        private async Task<FederationProviderInfo> GetFederationProviderInfoAsync(string domainname) {
            if (IdcrlAuth.s_FederationProviderInfoCache.TryGetValue(domainname, out var federationProviderInfo)) {
                this._Logger?.LogDebug("Get federation provider information for {0} from cache. UserRealmServiceUrl={1}, SecurityTokenServiceUrl={2}, FederationTokenIssuer={3}", domainname, federationProviderInfo?.UserRealmServiceUrl, federationProviderInfo?.SecurityTokenServiceUrl, federationProviderInfo?.FederationTokenIssuer);
                return federationProviderInfo;
            }
            {
                federationProviderInfo = await this.RequestFederationProviderInfoAsync(domainname);
                IdcrlAuth.s_FederationProviderInfoCache.Put(domainname, federationProviderInfo);
                this._Logger?.LogWarning("Get federation provider information for {0} and put it in cache. UserRealmServcieUrl={1}, SecurityTokenServiceUrl={2}, FederationTokenIssuer={3}", domainname, federationProviderInfo?.UserRealmServiceUrl, federationProviderInfo?.SecurityTokenServiceUrl, federationProviderInfo?.FederationTokenIssuer);
                return federationProviderInfo;
            }
        }

        private async Task<FederationProviderInfo> RequestFederationProviderInfoAsync(string domainname) {
            int posDot;
            while ((posDot = domainname.IndexOf('.')) > 0) {
                string url = string.Format(CultureInfo.InvariantCulture, IdcrlMessageConstants.FPUrlFullUrlFormat, new object[1]
                {
                    domainname
                });
                try {
                    XDocument xdoc = await this.DoGetAsync(url);
                    if (xdoc == null) { continue; }
                    string fpDomainName = ParseFPDomainName(xdoc);
                    url = string.Format(CultureInfo.InvariantCulture, IdcrlMessageConstants.FPListFullUrlFormat, new object[1]
                    {
                        domainname
                    });
                    xdoc = await this.DoGetAsync(url);
                    return ParseFederationProviderInfo(xdoc, fpDomainName);
                } catch (AggregateException a) {
                    if (a.InnerExceptions.Any(_ => _ is WebException)) {
                        // fall through
                    } else {
                        throw;
                    }
                } catch (WebException) {
                    //this._Logger?.LogWarning("Exception when request {0}. Exception={1}", text, ex);
                }
                domainname = domainname.Substring(posDot + 1);
            }
            return null;
        }

        private string ParseFPDomainName(XDocument xdoc) {
            XElement elementAtPath = IdcrlUtility.GetElementAtPath(xdoc.Root, IdcrlMessageConstants.FPDOMAINNAME);
            if (elementAtPath == null) {
                this._Logger?.LogError("Cannot find FPDOMAINNAME element");
                throw IdcrlAuth.CreateIdcrlException(-2147186646);
            }
            return elementAtPath.Value;
        }

        private FederationProviderInfo ParseFederationProviderInfo(XDocument xdoc, string fpDomainName) {
            foreach (XElement item in xdoc.Root.Elements("FP")) {
                if (item.Attribute("DomainName") != null && string.Equals(item.Attribute("DomainName").Value, fpDomainName, StringComparison.OrdinalIgnoreCase)) {
                    XElement elementAtPath = IdcrlUtility.GetElementAtPath(item, IdcrlMessageConstants.URL, IdcrlMessageConstants.GETUSERREALM);
                    XElement elementAtPath2 = IdcrlUtility.GetElementAtPath(item, IdcrlMessageConstants.URL, IdcrlMessageConstants.RST2);
                    XElement elementAtPath3 = IdcrlUtility.GetElementAtPath(item, IdcrlMessageConstants.URL, IdcrlMessageConstants.ENTITYID);
                    if (elementAtPath != null && elementAtPath2 != null && elementAtPath3 != null) {
                        this._Logger?.LogError("Find federation provider information for federation provider domain name {0}. UserRealmServiceUrl={1}, SecurityTokenServiceUrl={2}, FederationTokenIssuer={3}", fpDomainName, elementAtPath.Value, elementAtPath2.Value, elementAtPath3.Value);
                        var federationProviderInfo = new FederationProviderInfo {
                            UserRealmServiceUrl = elementAtPath.Value,
                            SecurityTokenServiceUrl = elementAtPath2.Value,
                            FederationTokenIssuer = elementAtPath3.Value
                        };
                        return federationProviderInfo;
                    }
                    this._Logger?.LogError("Cannot get the user realm service url or security token service url for federation provider {0}", fpDomainName);
                    throw IdcrlAuth.CreateIdcrlException(-2147186646);
                }
            }
            this._Logger?.LogError("Cannot find federation provider information for federation domain {0}", fpDomainName);
            throw IdcrlAuth.CreateIdcrlException(-2147186646);
        }

        private async Task<XDocument> DoGetAsync(string url) {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            this._Logger?.LogDebug("Sending GET request to {0}", url);
            this.m_executingWebRequest?.Invoke(this, new WebRequestEventArgs(httpWebRequest));
#pragma warning disable IDE0019 // Use pattern matching
            var httpWebResponse = (await httpWebRequest.GetResponseAsync()) as HttpWebResponse;
            if (httpWebResponse == null) {
                this._Logger?.LogError("Unexpected response for GET request to URL {0}", url);
                throw new InvalidOperationException();
            }
            try {
                using (httpWebResponse) {
                    using (var responseReader = new StreamReader(httpWebResponse.GetResponseStream())) {
                        string responseText = responseReader.ReadToEnd();
                        this._Logger?.LogDebug("StatusCode={0}, ResponseText={1}", (int)httpWebResponse.StatusCode, responseText);
                        using (XmlReader reader = XmlReader.Create(new StringReader(responseText))) {
                            return XDocument.Load(reader);
                        }
                    }
                }
            } catch (System.Xml.XmlException) {
                // aaarg internet provider 404 redirect ... shutup
                // t-online navigationhilfe
                throw new WebException();
            }
        }
    }
}
