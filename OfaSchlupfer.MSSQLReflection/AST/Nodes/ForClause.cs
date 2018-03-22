#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public abstract class ForClause : SqlNode {
        public ForClause() : base() { }
        public ForClause(ScriptDom.ForClause src) : base(src) { }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class XmlForClause : ForClause {
        public XmlForClause() : base() { }
        public XmlForClause(ScriptDom.XmlForClause src) : base(src) { }

        /* public List<XmlForClauseOption> Options { get; } = new List<XmlForClauseOption>(); */
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            // this.Options.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
