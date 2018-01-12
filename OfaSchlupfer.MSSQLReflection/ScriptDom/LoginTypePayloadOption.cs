using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class LoginTypePayloadOption : PayloadOption {
        private bool _isWindows;

        public bool IsWindows {
            get {
                return this._isWindows;
            }
            set {
                this._isWindows = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
