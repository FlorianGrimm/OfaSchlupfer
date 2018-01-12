using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class RevertStatement : TSqlStatement {
        private ScalarExpression _cookie;

        public ScalarExpression Cookie {
            get {
                return this._cookie;
            }

            set {
                this.UpdateTokenInfo(value);
                this._cookie = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Cookie?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
