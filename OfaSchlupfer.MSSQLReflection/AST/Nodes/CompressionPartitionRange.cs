#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class CompressionPartitionRange : SqlNode {
        public CompressionPartitionRange() : base() { }
        public CompressionPartitionRange(ScriptDom.CompressionPartitionRange src) : base(src) {
            this.From = Copier.Copy<ScalarExpression>(src.From);
            this.To = Copier.Copy<ScalarExpression>(src.To);
        }
        public ScalarExpression From;
        public ScalarExpression To;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.From?.Accept(visitor);
            this.To?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
