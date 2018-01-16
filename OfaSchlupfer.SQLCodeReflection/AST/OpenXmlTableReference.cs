namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class OpenXmlTableReference : TableReferenceWithAlias {
        private VariableReference _variable;

        private ValueExpression _rowPattern;

        private ValueExpression _flags;

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

        public List<SchemaDeclarationItem> SchemaDeclarationItems { get; } = new List<SchemaDeclarationItem>();

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
            this.SchemaDeclarationItems.Accept(visitor);
            this.TableName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
