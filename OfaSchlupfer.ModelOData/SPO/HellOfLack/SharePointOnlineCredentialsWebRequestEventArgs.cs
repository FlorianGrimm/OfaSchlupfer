namespace OfaSchlupfer.ModelOData.SPO {
    using System;
    using System.Net;


    public sealed class SharePointOnlineCredentialsWebRequestEventArgs : EventArgs {
        private HttpWebRequest m_webRequest;

        public HttpWebRequest WebRequest {
            get {
                return this.m_webRequest;
            }
        }

        internal SharePointOnlineCredentialsWebRequestEventArgs(HttpWebRequest webRequest) {
            this.m_webRequest = webRequest;
        }
    }
}
