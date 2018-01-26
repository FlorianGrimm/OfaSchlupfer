namespace OfaSchlupfer.SQLReflection {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public sealed class OpenXmlTableReference : TableReferenceWithAlias {
        public OpenXmlTableReference() : base() { }
        public OpenXmlTableReference(ScriptDom.OpenXmlTableReference src) : base(src) {
            this.Variable = Copier.Copy<VariableReference>(src.Variable);
            this.RowPattern = Copier.Copy<ValueExpression>(src.RowPattern);
            this.Flags = Copier.Copy<ValueExpression>(src.Flags);
            Copier.CopyList(this.SchemaDeclarationItems, src.SchemaDeclarationItems);
            this.TableName = Copier.Copy<SchemaObjectName>(src.TableName);
        }

        public VariableReference Variable { get; set; }

        public ValueExpression RowPattern { get; set; }

        public ValueExpression Flags { get; set; }

        public List<SchemaDeclarationItem> SchemaDeclarationItems { get; } = new List<SchemaDeclarationItem>();

        public SchemaObjectName TableName { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Variable?.Accept(visitor);
            this.RowPattern?.Accept(visitor);
            this.Flags?.Accept(visitor);
            this.SchemaDeclarationItems.Accept(visitor);
            this.TableName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
