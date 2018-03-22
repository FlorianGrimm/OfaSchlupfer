using System;
using System.Security;

namespace OfaSchlupfer.Elementary {
    public class RepositoryConnectionString {
        private SecureString _PasswordAsSecureString;

        public string Url { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public string GetUrlNormalized() {
            return (this.Url ?? string.Empty).TrimEnd('/');
        }

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
    }
}
