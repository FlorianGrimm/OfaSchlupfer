namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public abstract class DataTypeReference : SqlNode {
        public DataTypeReference() : base() { }
        public DataTypeReference(ScriptDom.DataTypeReference src) : base(src) {
            this.Name = Copier.Copy<SchemaObjectName>(src.Name);
        }
        public SchemaObjectName Name { get; set; }

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public sealed class XmlDataTypeReference : DataTypeReference {
        public XmlDataTypeReference() : base() { }
        public XmlDataTypeReference(ScriptDom.XmlDataTypeReference src) : base(src) {
            this.XmlDataTypeOption = src.XmlDataTypeOption;
            this.XmlSchemaCollection = Copier.Copy<SchemaObjectName>(src.XmlSchemaCollection);
        }

        public Microsoft.SqlServer.TransactSql.ScriptDom.XmlDataTypeOption XmlDataTypeOption { get; set; }

        public SchemaObjectName XmlSchemaCollection { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.XmlSchemaCollection?.Accept(visitor);
        }
    }
}

