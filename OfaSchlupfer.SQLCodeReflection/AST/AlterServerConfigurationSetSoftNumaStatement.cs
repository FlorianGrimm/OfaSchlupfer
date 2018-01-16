namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlterServerConfigurationSetSoftNumaStatement : TSqlStatement {
        public List<AlterServerConfigurationSoftNumaOption> Options { get; } = new List<AlterServerConfigurationSoftNumaOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Options.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
