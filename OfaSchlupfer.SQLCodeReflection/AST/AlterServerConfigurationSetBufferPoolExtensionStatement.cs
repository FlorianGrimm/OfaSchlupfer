namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlterServerConfigurationSetBufferPoolExtensionStatement : TSqlStatement {
        public List<AlterServerConfigurationBufferPoolExtensionOption> Options { get; } = new List<AlterServerConfigurationBufferPoolExtensionOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Options.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
