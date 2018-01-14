using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class OpenXmlTableReference : TableReferenceWithAlias {
        private VariableReference _variable;

        private ValueExpression _rowPattern;

        private ValueExpression _flags;

        private List<SchemaDeclarationItem> _schemaDeclarationItems = new List<SchemaDeclarationItem>();

        private SchemaObjectName _tableName;

        public VariableReference Variable {
            get {
                return this._variable;
            }

            set {
                this.UpdateTokenInfo(value);
                this._variable = value;
            }
        }

        public ValueExpression RowPattern {
            get {
                return this._rowPattern;
            }

            set {
                this.UpdateTokenInfo(value);
                this._rowPattern = value;
            }
        }

        public ValueExpression Flags {
            get {
                return this._flags;
            }

            set {
                this.UpdateTokenInfo(value);
                this._flags = value;
            }
        }

        public List<SchemaDeclarationItem> SchemaDeclarationItems {
            get {
                return this._schemaDeclarationItems;
            }
        }

        public SchemaObjectName TableName {
            get {
                return this._tableName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._tableName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Variable?.Accept(visitor);
            this.RowPattern?.Accept(visitor);
            this.Flags?.Accept(visitor);
            for (int i = 0, count = this.SchemaDeclarationItems.Count; i < count; i++) {
                this.SchemaDeclarationItems[i].Accept(visitor);
            }
            this.TableName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
