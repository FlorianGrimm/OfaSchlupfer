using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class WhenClause : TSqlFragment {
        private ScalarExpression _thenExpression;

        public ScalarExpression ThenExpression {
            get {
                return this._thenExpression;
            }

            set {
                this.UpdateTokenInfo(value);
                this._thenExpression = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.ThenExpression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
