#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public sealed class SetTextSizeStatement : SqlStatement {
        public SetTextSizeStatement() : base() { }

        public SetTextSizeStatement(ScriptDom.SetTextSizeStatement src) : base(src) {
            this.TextSize = Copier.Copy<ScalarExpression>(src.TextSize);
        }

        public ScalarExpression TextSize { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.TextSize?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
