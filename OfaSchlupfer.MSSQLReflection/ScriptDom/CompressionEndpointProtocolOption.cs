using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CompressionEndpointProtocolOption : EndpointProtocolOption {
        private bool _isEnabled;

        public bool IsEnabled {
            get {
                return this._isEnabled;
            }
            set {
                this._isEnabled = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
