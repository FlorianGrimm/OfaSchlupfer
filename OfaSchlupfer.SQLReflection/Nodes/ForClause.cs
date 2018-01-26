namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public abstract class ForClause : SqlNode {
        public ForClause() : base() { }
        public ForClause(ScriptDom.ForClause src) : base(src) { }
    }

    [System.Serializable]
    public sealed class XmlForClause : ForClause {
        public XmlForClause() : base() { }
        public XmlForClause(ScriptDom.XmlForClause src) : base(src) {
        }

        // public List<XmlForClauseOption> Options { get; } = new List<XmlForClauseOption>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            // this.Options.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
