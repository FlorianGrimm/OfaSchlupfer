#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class ReadTextStatement : SqlStatement {
        public ReadTextStatement() : base() { }
        public ReadTextStatement(ScriptDom.ReadTextStatement src) : base(src) {
            this.Column = Copier.Copy<ColumnReferenceExpression>(src.Column);
            this.TextPointer = Copier.Copy<ValueExpression>(src.TextPointer);
            this.Offset = Copier.Copy<ValueExpression>(src.Offset);
            this.Size = Copier.Copy<ValueExpression>(src.Size);
            this.HoldLock = src.HoldLock;
        }
        public ColumnReferenceExpression Column;
        public ValueExpression TextPointer;
        public ValueExpression Offset;
        public ValueExpression Size;
        public bool HoldLock;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Column?.Accept(visitor);
            this.TextPointer?.Accept(visitor);
            this.Offset?.Accept(visitor);
            this.Size?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
