#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
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