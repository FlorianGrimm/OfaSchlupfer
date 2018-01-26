#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class FetchType : SqlNode {
        public FetchType() : base() { }
        public FetchType(ScriptDom.FetchType src) : base(src) {
            this.Orientation = src.Orientation;
            this.RowOffset = Copier.Copy<ScalarExpression>(src.RowOffset);
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.FetchOrientation Orientation { get; set; }

        public ScalarExpression RowOffset { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.RowOffset?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
