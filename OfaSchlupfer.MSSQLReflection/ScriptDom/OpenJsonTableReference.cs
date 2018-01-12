using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class OpenJsonTableReference : TableReferenceWithAlias {
        private ScalarExpression _variable;

        private StringLiteral _rowPattern;

        private List<SchemaDeclarationItemOpenjson> _schemaDeclarationItems = new List<SchemaDeclarationItemOpenjson>();

        public ScalarExpression Variable {
            get {
                return this._variable;
            }
            set {
                base.UpdateTokenInfo(value);
                this._variable = value;
            }
        }

        public StringLiteral RowPattern {
            get {
                return this._rowPattern;
            }
            set {
                base.UpdateTokenInfo(value);
                this._rowPattern = value;
            }
        }

        public List<SchemaDeclarationItemOpenjson> SchemaDeclarationItems {
            get {
                return this._schemaDeclarationItems;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Variable?.Accept(visitor);
            this.RowPattern?.Accept(visitor);
            for (int i=0, count = this.SchemaDeclarationItems.Count; i < count; i++) {
                this.SchemaDeclarationItems[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
