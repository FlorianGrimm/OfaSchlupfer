namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class FileDeclaration : TSqlFragment {
        public List<FileDeclarationOption> Options { get; } = new List<FileDeclarationOption>();

        public bool IsPrimary { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Options.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
