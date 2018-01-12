using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class PortsEndpointProtocolOption : EndpointProtocolOption {
        private PortTypes _portTypes;

        public PortTypes PortTypes {
            get {
                return this._portTypes;
            }
            set {
                this._portTypes = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
