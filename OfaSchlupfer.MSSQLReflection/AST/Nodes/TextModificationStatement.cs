#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public abstract class TextModificationStatement : SqlStatement {
        public TextModificationStatement() : base() { }
        public TextModificationStatement(ScriptDom.TextModificationStatement src) : base(src) {
            this.Bulk = src.Bulk;
            this.Column = Copier.Copy<ColumnReferenceExpression>(src.Column);
            this.TextId = Copier.Copy<ValueExpression>(src.TextId);
            this.WithLog = src.WithLog;
        }
        public bool Bulk;
        public ColumnReferenceExpression Column;
        public ValueExpression TextId;
        public Literal Timestamp;
        public bool WithLog;
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Column?.Accept(visitor);
            this.TextId?.Accept(visitor);
            this.Timestamp?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
