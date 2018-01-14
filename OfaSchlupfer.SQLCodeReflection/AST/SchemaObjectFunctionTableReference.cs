using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class SchemaObjectFunctionTableReference : TableReferenceWithAliasAndColumns {
        private SchemaObjectName _schemaObject;

        private List<ScalarExpression> _parameters = new List<ScalarExpression>();

        public SchemaObjectName SchemaObject {
            get {
                return this._schemaObject;
            }

            set {
                this.UpdateTokenInfo(value);
                this._schemaObject = value;
            }
        }

        public List<ScalarExpression> Parameters {
            get {
                return this._parameters;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SchemaObject?.Accept(visitor);
            base.AcceptChildren(visitor);
            for (int i = 0, count = this.Parameters.Count; i < count; i++) {
                this.Parameters[i].Accept(visitor);
            }
        }
    }
}
