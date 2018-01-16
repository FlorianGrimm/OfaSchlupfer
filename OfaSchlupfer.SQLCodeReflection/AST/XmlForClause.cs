namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class XmlForClause : ForClause {
        public List<XmlForClauseOption> Options { get; } = new List<XmlForClauseOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Options.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
