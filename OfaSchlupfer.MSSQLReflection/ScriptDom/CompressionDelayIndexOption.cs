using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CompressionDelayIndexOption : IndexOption {
        private ScalarExpression _expression;

        private CompressionDelayTimeUnit _timeUnit;

        public ScalarExpression Expression {
            get {
                return this._expression;
            }
            set {
                base.UpdateTokenInfo(value);
                this._expression = value;
            }
        }

        public CompressionDelayTimeUnit TimeUnit {
            get {
                return this._timeUnit;
            }
            set {
                this._timeUnit = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Expression?.Accept(visitor);
        }
    }
}
