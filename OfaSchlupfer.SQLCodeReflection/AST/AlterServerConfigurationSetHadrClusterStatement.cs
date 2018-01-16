namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlterServerConfigurationSetHadrClusterStatement : TSqlStatement {
        public List<AlterServerConfigurationHadrClusterOption> Options { get; } = new List<AlterServerConfigurationHadrClusterOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Options.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
