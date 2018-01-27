#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class SchemaDeclarationItemOpenjson : SchemaDeclarationItem {
        public SchemaDeclarationItemOpenjson() : base() { }
        public SchemaDeclarationItemOpenjson(ScriptDom.SchemaDeclarationItemOpenjson src) : base(src) {
            this.AsJson = src.AsJson;
        }
        public bool AsJson;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
