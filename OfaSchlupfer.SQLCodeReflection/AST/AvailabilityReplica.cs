using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AvailabilityReplica : TSqlFragment {
        private StringLiteral _serverName;

        private List<AvailabilityReplicaOption> _options = new List<AvailabilityReplicaOption>();

        public StringLiteral ServerName {
            get {
                return this._serverName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._serverName = value;
            }
        }

        public List<AvailabilityReplicaOption> Options {
            get {
                return this._options;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.ServerName?.Accept(visitor);
            for (int i = 0, count = this.Options.Count; i < count; i++) {
                this.Options[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
