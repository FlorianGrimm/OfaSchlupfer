namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class SchemaObjectFunctionTableReference : TableReferenceWithAliasAndColumns {
        private SchemaObjectName _schemaObject;

        public SchemaObjectName SchemaObject {
            get {
                return this._schemaObject;
            }

            set {
                this.UpdateTokenInfo(value);
                this._schemaObject = value;
            }
        }

        public List<ScalarExpression> Parameters { get; } = new List<ScalarExpression>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SchemaObject?.Accept(visitor);
            base.AcceptChildren(visitor);
            this.Parameters.Accept(visitor);
        }
    }
}
