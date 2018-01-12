using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class PartnerDatabaseOption : DatabaseOption {
        private Literal _partnerServer;

        private PartnerDatabaseOptionKind _partnerOption;

        private Literal _timeout;

        public Literal PartnerServer {
            get {
                return this._partnerServer;
            }
            set {
                base.UpdateTokenInfo(value);
                this._partnerServer = value;
            }
        }

        public PartnerDatabaseOptionKind PartnerOption {
            get {
                return this._partnerOption;
            }
            set {
                this._partnerOption = value;
            }
        }

        public Literal Timeout {
            get {
                return this._timeout;
            }
            set {
                base.UpdateTokenInfo(value);
                this._timeout = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.PartnerServer?.Accept(visitor);
            this.Timeout?.Accept(visitor);
        }
    }
}
