namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class IdentifierOrValueExpression : TSqlFragment {
        private Identifier _identifier;

        private ValueExpression _valueExpression;

        public string Value {
            get {
                if (this.Identifier != null) {
                    return this.Identifier.Value;
                }
                if (this.ValueExpression != null) {
                    Literal literal = this.ValueExpression as Literal;
                    if (literal != null) {
                        return literal.Value;
                    }
                    VariableReference variableReference = this.ValueExpression as VariableReference;
                    if (variableReference != null) {
                        return variableReference.Name;
                    }
                    GlobalVariableExpression globalVariableExpression = this.ValueExpression as GlobalVariableExpression;
                    if (globalVariableExpression != null) {
                        return globalVariableExpression.Name;
                    }
                    return null;
                }
                return null;
            }
        }

        public Identifier Identifier {
            get {
                return this._identifier;
            }

            set {
                this.UpdateTokenInfo(value);
                this._identifier = value;
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
            this.Identifier?.Accept(visitor);
            this.ValueExpression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
