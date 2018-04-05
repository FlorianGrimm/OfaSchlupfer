namespace OfaSchlupfer.ModelOData.SPO {
    internal static class IdcrlMessageConstants {
        public const string UserRealmServiceUrl_Prod = "https://login.microsoftonline.com/GetUserRealm.srf";

        public const string UserRealmServiceUrl_Int = "https://login.microsoftonline-int.com/GetUserRealm.srf";

        public const string UserRealmServiceUrl_Ppe = "https://login.windows-ppe.net/GetUserRealm.srf";

        public const string SecurityTokenServiceUrl_Prod = "https://login.microsoftonline.com/rst2.srf";

        public const string SecurityTokenServiceUrl_Int = "https://login.microsoftonline-int.com/rst2.srf";

        public const string SecurityTokenServiceUrl_Ppe = "https://login.windows-ppe.net/rst2.srf";

        public const string FederationTokenIssuer_Prod = "urn:federation:MicrosoftOnline";

        public const string FederationTokenIssuer_Int = "urn:federation:MicrosoftOnline-int";

        public const string FederationTokenIssuer_Ppe = "urn:federation:MicrosoftOnline";

        // public const string FederationProvider = "FederationProvider";

        public const string FPDOMAINNAME = "FPDOMAINNAME";

        public const string FPList = "FPList";

        public const string FP = "FP";

        public const string DomainName = "DomainName";

        public const string URL = "URL";

        public const string GETUSERREALM = "GETUSERREALM";

        public const string RST2 = "RST2";

        public const string ENTITYID = "ENTITYID";

        public const string AuthURL = "AuthURL";

        public const string NameSpaceType = "NameSpaceType";

        public const string Federated = "Federated";

        public const string Managed = "Managed";

        public const string Success = "Success";

        public const string STSAuthURL = "STSAuthURL";

        public const string GetUserRealmMessage = "login={0}&xml=1";

        public const string GetUserRealmContentType = "application/x-www-form-urlencoded";

        public const string SoapContentType = "application/soap+xml; charset=utf-8";

        public const string SoapNamespace = "http://www.w3.org/2003/05/soap-envelope";

        public const string EnvelopeElementFullName = "{http://www.w3.org/2003/05/soap-envelope}Envelope";

        public const string BodyElementFullName = "{http://www.w3.org/2003/05/soap-envelope}Body";

        public const string TrustNamespace = "http://schemas.xmlsoap.org/ws/2005/02/trust";

        public const string RequestSecurityTokenResponseFullName = "{http://schemas.xmlsoap.org/ws/2005/02/trust}RequestSecurityTokenResponse";

        public const string RequestedSecurityTokenFullName = "{http://schemas.xmlsoap.org/ws/2005/02/trust}RequestedSecurityToken";

        public const string SamlNamespace = "urn:oasis:names:tc:SAML:1.0:assertion";

        public const string AssertionFullName = "{urn:oasis:names:tc:SAML:1.0:assertion}Assertion";

        public const string WsSecurityNamespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";

        public const string BinarySecurityTokenFullName = "{http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd}BinarySecurityToken";

        public const string FaultFullName = "{http://www.w3.org/2003/05/soap-envelope}Fault";

        public const string DetailFullName = "{http://www.w3.org/2003/05/soap-envelope}Detail";

        public const string CodeFullName = "{http://www.w3.org/2003/05/soap-envelope}Code";

        public const string ValueFullName = "{http://www.w3.org/2003/05/soap-envelope}Value";

        public const string SubcodeFullName = "{http://www.w3.org/2003/05/soap-envelope}Subcode";

        public const string ReasonFullName = "{http://www.w3.org/2003/05/soap-envelope}Reason";

        public const string TextFullName = "{http://www.w3.org/2003/05/soap-envelope}Text";

        public const string PassportNamespace = "http://schemas.microsoft.com/Passport/SoapServices/SOAPFault";

        public const string PassportErrorFullName = "{http://schemas.microsoft.com/Passport/SoapServices/SOAPFault}error";

        public const string PassportValueFullName = "{http://schemas.microsoft.com/Passport/SoapServices/SOAPFault}value";

        public const string PassportInternalErrorFullName = "{http://schemas.microsoft.com/Passport/SoapServices/SOAPFault}internalerror";

        public const string PassportCodeFullName = "{http://schemas.microsoft.com/Passport/SoapServices/SOAPFault}code";

        public const string PassportTextFullName = "{http://schemas.microsoft.com/Passport/SoapServices/SOAPFault}text";

        public const string AdfsAuthMessage = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><s:Envelope xmlns:s=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\" xmlns:saml=\"urn:oasis:names:tc:SAML:1.0:assertion\" xmlns:wsp=\"http://schemas.xmlsoap.org/ws/2004/09/policy\" xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\" xmlns:wsa=\"http://www.w3.org/2005/08/addressing\" xmlns:wssc=\"http://schemas.xmlsoap.org/ws/2005/02/sc\" xmlns:wst=\"http://schemas.xmlsoap.org/ws/2005/02/trust\"><s:Header><wsa:Action s:mustUnderstand=\"1\">http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Issue</wsa:Action><wsa:To s:mustUnderstand=\"1\">{0}</wsa:To><wsa:MessageID>{1}</wsa:MessageID><ps:AuthInfo xmlns:ps=\"http://schemas.microsoft.com/Passport/SoapServices/PPCRL\" Id=\"PPAuthInfo\"><ps:HostingApp>Managed IDCRL</ps:HostingApp><ps:BinaryVersion>6</ps:BinaryVersion><ps:UIVersion>1</ps:UIVersion><ps:Cookies></ps:Cookies><ps:RequestParams>AQAAAAIAAABsYwQAAAAxMDMz</ps:RequestParams></ps:AuthInfo><wsse:Security><wsse:UsernameToken wsu:Id=\"user\"><wsse:Username>{2}</wsse:Username><wsse:Password>{3}</wsse:Password></wsse:UsernameToken><wsu:Timestamp Id=\"Timestamp\"><wsu:Created>{4}</wsu:Created><wsu:Expires>{5}</wsu:Expires></wsu:Timestamp></wsse:Security></s:Header><s:Body><wst:RequestSecurityToken Id=\"RST0\"><wst:RequestType>http://schemas.xmlsoap.org/ws/2005/02/trust/Issue</wst:RequestType><wsp:AppliesTo><wsa:EndpointReference><wsa:Address>{6}</wsa:Address></wsa:EndpointReference></wsp:AppliesTo><wst:KeyType>http://schemas.xmlsoap.org/ws/2005/05/identity/NoProofKey</wst:KeyType></wst:RequestSecurityToken></s:Body></s:Envelope>";

        public const string PolicyReferenceFragment = "<wsp:PolicyReference URI=\"{0}\"></wsp:PolicyReference>";

        public const string AuthMessage = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><S:Envelope xmlns:S=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\" xmlns:wsp=\"http://schemas.xmlsoap.org/ws/2004/09/policy\" xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\" xmlns:wsa=\"http://www.w3.org/2005/08/addressing\" xmlns:wst=\"http://schemas.xmlsoap.org/ws/2005/02/trust\"><S:Header><wsa:Action S:mustUnderstand=\"1\">http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Issue</wsa:Action><wsa:To S:mustUnderstand=\"1\">{0}</wsa:To><ps:AuthInfo xmlns:ps=\"http://schemas.microsoft.com/LiveID/SoapServices/v1\" Id=\"PPAuthInfo\"><ps:BinaryVersion>5</ps:BinaryVersion><ps:HostingApp>Managed IDCRL</ps:HostingApp></ps:AuthInfo><wsse:Security>{1}</wsse:Security></S:Header><S:Body><wst:RequestSecurityToken xmlns:wst=\"http://schemas.xmlsoap.org/ws/2005/02/trust\" Id=\"RST0\"><wst:RequestType>http://schemas.xmlsoap.org/ws/2005/02/trust/Issue</wst:RequestType><wsp:AppliesTo><wsa:EndpointReference><wsa:Address>{2}</wsa:Address></wsa:EndpointReference></wsp:AppliesTo>{3}</wst:RequestSecurityToken></S:Body></S:Envelope>\r\n";

        public const string UsernameTokenSecurityFragment = "\r\n<wsse:UsernameToken wsu:Id=\"user\"><wsse:Username>{0}</wsse:Username><wsse:Password>{1}</wsse:Password></wsse:UsernameToken><wsu:Timestamp Id=\"Timestamp\"><wsu:Created>{2}</wsu:Created><wsu:Expires>{3}</wsu:Expires></wsu:Timestamp>\r\n";

        public static readonly string FPUrlFullUrlFormat = "http://msoid.{0}/FPUrl.xml";

        public static readonly string FPListFullUrlFormat = "http://msoid.{0}/FPList.xml";
    }
}
