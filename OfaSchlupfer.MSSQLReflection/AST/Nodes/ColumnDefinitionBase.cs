#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public class ColumnDefinitionBase : SqlNode {
        public ColumnDefinitionBase() : base() { }
        public ColumnDefinitionBase(ScriptDom.ColumnDefinitionBase src) : base(src) {
            this.ColumnIdentifier = Copier.Copy<Identifier>(src.ColumnIdentifier);
            this.DataType = Copier.Copy<DataTypeReference>(src.DataType);
            this.Collation = Copier.Copy<Identifier>(src.Collation);
        }
        public Identifier ColumnIdentifier;
        public DataTypeReference DataType;
        public Identifier Collation;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.ColumnIdentifier?.Accept(visitor);
            this.DataType?.Accept(visitor);
            this.Collation?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
