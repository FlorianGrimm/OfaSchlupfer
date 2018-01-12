namespace OfaSchlupfer.ScriptDom {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class DeclareVariableStatement : TSqlStatement {
        public List<DeclareVariableElement> Declarations { get; } = new List<DeclareVariableElement>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            var declarations = this.Declarations;
            for (int i = 0, count = declarations.Count; i < count; i++) {
                declarations[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
