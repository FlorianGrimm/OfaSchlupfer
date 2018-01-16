namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class DeclareVariableStatement : TSqlStatement {
        public List<DeclareVariableElement> Declarations { get; } = new List<DeclareVariableElement>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Declarations.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
