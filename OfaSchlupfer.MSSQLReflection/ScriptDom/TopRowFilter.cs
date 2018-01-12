using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class TopRowFilter : TSqlFragment {
        private ScalarExpression _expression;

        private bool _percent;

        private bool _withTies;

        public ScalarExpression Expression {
            get {
                return this._expression;
            }
            set {
                base.UpdateTokenInfo(value);
                this._expression = value;
            }
        }

        public bool Percent {
            get {
                return this._percent;
            }
            set {
                this._percent = value;
            }
        }

        public bool WithTies {
            get {
                return this._withTies;
            }
            set {
                this._withTies = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Expression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
