using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AtTimeZoneCall : PrimaryExpression {
        private ScalarExpression _dateValue;

        private ScalarExpression _timeZone;

        public ScalarExpression DateValue {
            get {
                return this._dateValue;
            }

            set {
                this.UpdateTokenInfo(value);
                this._dateValue = value;
            }
        }

        public ScalarExpression TimeZone {
            get {
                return this._timeZone;
            }

            set {
                this.UpdateTokenInfo(value);
                this._timeZone = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.DateValue?.Accept(visitor);
            this.TimeZone?.Accept(visitor);
        }
    }
}
