namespace OfaSchlupfer.ScriptDom {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class AlterCreateEndpointStatementBase : TSqlStatement {
        private Identifier _name;

        private EndpointAffinity _affinity;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public EndpointState State { get; set; }

        public EndpointAffinity Affinity {
            get {
                return this._affinity;
            }

            set {
                this.UpdateTokenInfo(value);
                this._affinity = value;
            }
        }

        public EndpointProtocol Protocol { get; set; }

        public List<EndpointProtocolOption> ProtocolOptions { get; } = new List<EndpointProtocolOption>();

        public EndpointType EndpointType { get; set; }

        public List<PayloadOption> PayloadOptions { get; } = new List<PayloadOption>();

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.Affinity?.Accept(visitor);
            var protocolOptions = this.ProtocolOptions;
            for (int i = 0, count = protocolOptions.Count; i < count; i++) {
                protocolOptions[i].Accept(visitor);
            }

            var payloadOptions = this.PayloadOptions;
            for (int i = 0, count = payloadOptions.Count; i < count; i++) {
                payloadOptions[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
