using System;
using System.Security;

namespace OfaSchlupfer.Elementary {
    public class RepositoryConnectionString {
        // private SecureString _PasswordAsSecureString;
        public string AuthenticationMode { get; set; }

        public string Url { get; set; }

        public string Suffix { get; set; }

        public string User { get; set; }

        public string Password { get; set; }
        
        private System.Tuple<string, string, string> _GetUrlNormalizedCache;
        public string GetUrlNormalized() {
            var cache = this._GetUrlNormalizedCache;
            System.Threading.Interlocked.MemoryBarrier();
            if (cache != null
                && string.Equals(cache.Item1, this.Url, StringComparison.Ordinal)
                && string.Equals(cache.Item2, this.Suffix, StringComparison.Ordinal)
                ) { return cache.Item3; }
            if (string.IsNullOrEmpty(this.Suffix)) {
                var result = (this.Url ?? string.Empty).TrimEnd('/');
                this._GetUrlNormalizedCache = Tuple.Create(this.Url, this.Suffix, result);
                return result;
            } else {
                var result = ((this.Url ?? string.Empty).TrimEnd('/') + "/" + (this.Suffix ?? string.Empty).Trim('/')).TrimEnd('/');
                this._GetUrlNormalizedCache = Tuple.Create(this.Url, this.Suffix, result);
                return result;
            }
        }
#if no
        public SecureString GetPasswordAsSecureString() {
            if (!string.IsNullOrEmpty(Password)) {
                var secureString = new SecureString();
                foreach (char c in this.Password) { secureString.AppendChar(c); }
                this._PasswordAsSecureString = secureString;
                this.Password = null;
                return secureString;
            }
            return this._PasswordAsSecureString;
        }
#endif
        public RepositoryConnectionString CreateWithSuffix(string suffix) {
            var result = new RepositoryConnectionString();
            result.AuthenticationMode = this.AuthenticationMode;
            result.Url = this.Url;
            result.Suffix = suffix;
            result.User = this.User;
            result.Password = this.Password;
            // result._PasswordAsSecureString = this._PasswordAsSecureString;
            return result;
        }
    }
}
