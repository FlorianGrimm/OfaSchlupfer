using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SetTextSizeStatement : TSqlStatement {
        private ScalarExpression _textSize;

        public ScalarExpression TextSize {
            get {
                return this._textSize;
            }

            set {
                this.UpdateTokenInfo(value);
                this._textSize = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.TextSize?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
