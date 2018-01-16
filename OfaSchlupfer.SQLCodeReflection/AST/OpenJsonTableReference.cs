namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class OpenJsonTableReference : TableReferenceWithAlias {
        private ScalarExpression _variable;

        private StringLiteral _rowPattern;

        public ScalarExpression Variable {
            get {
                return this._variable;
            }

            set {
                this.UpdateTokenInfo(value);
                this._variable = value;
            }
        }

        public StringLiteral RowPattern {
            get {
                return this._rowPattern;
            }

            set {
                this.UpdateTokenInfo(value);
                this._rowPattern = value;
            }
        }

        public List<SchemaDeclarationItemOpenjson> SchemaDeclarationItems { get; } = new List<SchemaDeclarationItemOpenjson>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Variable?.Accept(visitor);
            this.RowPattern?.Accept(visitor);
            this.SchemaDeclarationItems.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
