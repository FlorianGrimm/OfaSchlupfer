namespace OfaSchlupfer.AST {

    using System.Collections.Generic;
    [System.Serializable]
    public sealed class WindowsCreateLoginSource : CreateLoginSource {
        public List<PrincipalOption> Options { get; } = new List<PrincipalOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Options.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
