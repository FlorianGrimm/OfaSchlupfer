namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public class ColumnDefinitionBase : SqlNode, ICollationSetter {
        public ColumnDefinitionBase() : base() { }
        public ColumnDefinitionBase(ScriptDom.ColumnDefinitionBase src) : base(src) {
            this.ColumnIdentifier = Copier.Copy<Identifier>(src.ColumnIdentifier);
            this.DataType = Copier.Copy<DataTypeReference>(src.DataType);
            this.Collation = Copier.Copy<Identifier>(src.Collation);
        }
        public Identifier ColumnIdentifier { get; set; }

        public DataTypeReference DataType { get; set; }

        public Identifier Collation { get; set; }


        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.ColumnIdentifier?.Accept(visitor);
            this.DataType?.Accept(visitor);
            this.Collation?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
