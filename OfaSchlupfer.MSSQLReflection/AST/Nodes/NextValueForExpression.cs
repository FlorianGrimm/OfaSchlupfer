#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class NextValueForExpression : PrimaryExpression {
        public NextValueForExpression() : base() { }
        public NextValueForExpression(ScriptDom.NextValueForExpression src) : base(src) {
            this.SequenceName = Copier.Copy<SchemaObjectName>(src.SequenceName);
            this.OverClause = Copier.Copy<OverClause>(src.OverClause);
        }
        public SchemaObjectName SequenceName;
        public OverClause OverClause;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.SequenceName?.Accept(visitor);
            this.OverClause?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
