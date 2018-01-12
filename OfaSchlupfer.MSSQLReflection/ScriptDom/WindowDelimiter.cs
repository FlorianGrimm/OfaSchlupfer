using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class WindowDelimiter : TSqlFragment {
        private WindowDelimiterType _windowDelimiterType;

        private ScalarExpression _offsetValue;

        public WindowDelimiterType WindowDelimiterType {
            get {
                return this._windowDelimiterType;
            }
            set {
                this._windowDelimiterType = value;
            }
        }

        public ScalarExpression OffsetValue {
            get {
                return this._offsetValue;
            }
            set {
                base.UpdateTokenInfo(value);
                this._offsetValue = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.OffsetValue?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
