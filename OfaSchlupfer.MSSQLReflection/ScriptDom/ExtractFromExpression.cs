using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ExtractFromExpression : ScalarExpression {
        private ScalarExpression _expression;

        private Identifier _extractedElement;

        public ScalarExpression Expression {
            get {
                return this._expression;
            }
            set {
                base.UpdateTokenInfo(value);
                this._expression = value;
            }
        }

        public Identifier ExtractedElement {
            get {
                return this._extractedElement;
            }
            set {
                base.UpdateTokenInfo(value);
                this._extractedElement = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Expression?.Accept(visitor);
            this.ExtractedElement?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
