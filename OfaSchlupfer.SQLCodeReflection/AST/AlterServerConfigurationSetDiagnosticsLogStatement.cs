namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlterServerConfigurationSetDiagnosticsLogStatement : TSqlStatement {
        public List<AlterServerConfigurationDiagnosticsLogOption> Options { get; } = new List<AlterServerConfigurationDiagnosticsLogOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Options.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
