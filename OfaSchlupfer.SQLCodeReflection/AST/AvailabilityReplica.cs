namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AvailabilityReplica : TSqlFragment {
        private StringLiteral _serverName;

        public StringLiteral ServerName {
            get {
                return this._serverName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._serverName = value;
            }
        }

        public List<AvailabilityReplicaOption> Options { get; } = new List<AvailabilityReplicaOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.ServerName?.Accept(visitor);
            this.Options.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
