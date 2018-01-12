using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ScalarExpressionDialogOption : DialogOption {
        private ScalarExpression _value;

        public ScalarExpression Value {
            get {
                return this._value;
            }
            set {
                base.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Value?.Accept(visitor);
        }
    }
}
