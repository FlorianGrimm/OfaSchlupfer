namespace OfaSchlupfer.HttpAccess {
    using System.Net;

    public class WebRequestEventArgs {
        private HttpWebRequest _WebRequest;

        public HttpWebRequest WebRequest => this._WebRequest;

        public WebRequestEventArgs(HttpWebRequest webRequest) {
            this._WebRequest = webRequest;
        }
    }
}