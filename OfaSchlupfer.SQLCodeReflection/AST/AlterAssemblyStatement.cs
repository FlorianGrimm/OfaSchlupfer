namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlterAssemblyStatement : AssemblyStatement {
        public List<Literal> DropFiles { get; } = new List<Literal>();

        public bool IsDropAll { get; set; }

        public List<AddFileSpec> AddFiles { get; } = new List<AddFileSpec>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.DropFiles.Accept(visitor);
            this.AddFiles.Accept(visitor);
        }
    }
}
