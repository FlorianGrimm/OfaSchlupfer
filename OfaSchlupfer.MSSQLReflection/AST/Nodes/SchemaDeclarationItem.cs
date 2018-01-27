#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public class SchemaDeclarationItem : SqlNode {
        public SchemaDeclarationItem() : base() { }
        public SchemaDeclarationItem(ScriptDom.SchemaDeclarationItem src) : base(src) {
            this.ColumnDefinition = Copier.Copy<ColumnDefinitionBase>(src.ColumnDefinition);
        }
        public ColumnDefinitionBase ColumnDefinition;
        public ValueExpression Mapping;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.ColumnDefinition?.Accept(visitor);
            this.Mapping?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
