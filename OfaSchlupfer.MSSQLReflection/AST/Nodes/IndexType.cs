#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public sealed class IndexType : SqlNode {
        public IndexType() : base() { }
        public IndexType(ScriptDom.IndexType src) : base(src) {
            this.IndexTypeKind = src.IndexTypeKind;
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.IndexTypeKind? IndexTypeKind { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
