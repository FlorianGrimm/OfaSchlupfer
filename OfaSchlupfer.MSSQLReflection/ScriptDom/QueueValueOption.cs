using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class QueueValueOption : QueueOption {
        private ValueExpression _optionValue;

        public ValueExpression OptionValue {
            get {
                return this._optionValue;
            }
            set {
                base.UpdateTokenInfo(value);
                this._optionValue = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.OptionValue?.Accept(visitor);
        }
    }
}
