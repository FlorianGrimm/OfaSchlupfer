using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SchemaObjectNameOrValueExpression : TSqlFragment {
        private SchemaObjectName _schemaObjectName;

        private ValueExpression _valueExpression;

        public SchemaObjectName SchemaObjectName {
            get {
                return this._schemaObjectName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._schemaObjectName = value;
            }
        }

        public ValueExpression ValueExpression {
            get {
                return this._valueExpression;
            }

            set {
                this.UpdateTokenInfo(value);
                this._valueExpression = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SchemaObjectName?.Accept(visitor);
            this.ValueExpression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
