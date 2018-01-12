using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterXmlSchemaCollectionStatement : TSqlStatement {
        private SchemaObjectName _name;

        private ScalarExpression _expression;

        public SchemaObjectName Name {
            get {
                return this._name;
            }
            set {
                base.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public ScalarExpression Expression {
            get {
                return this._expression;
            }
            set {
                base.UpdateTokenInfo(value);
                this._expression = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.Expression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
