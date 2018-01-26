#pragma warning disable SA1600 // Elements must be documented

namespace OfaSchlupfer.SQLReflection {using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class CompressionPartitionRange : SqlNode {
        public CompressionPartitionRange() : base() { }
        public CompressionPartitionRange(ScriptDom.CompressionPartitionRange src) : base(src) {
            this.From = Copier.Copy<ScalarExpression>(src.From);
            this.To = Copier.Copy<ScalarExpression>(src.To);
        }
        public ScalarExpression From { get; set; }

        public ScalarExpression To { get; set; }


        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.From?.Accept(visitor);
            this.To?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
