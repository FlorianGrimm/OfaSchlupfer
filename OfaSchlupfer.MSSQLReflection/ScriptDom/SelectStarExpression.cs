using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SelectStarExpression : SelectElement {
        private MultiPartIdentifier _qualifier;

        public MultiPartIdentifier Qualifier {
            get {
                return this._qualifier;
            }
            set {
                base.UpdateTokenInfo(value);
                this._qualifier = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Qualifier?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
