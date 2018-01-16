namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlterServerConfigurationSetFailoverClusterPropertyStatement : TSqlStatement {
        public List<AlterServerConfigurationFailoverClusterPropertyOption> Options { get; } = new List<AlterServerConfigurationFailoverClusterPropertyOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Options?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
