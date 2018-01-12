using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class EventDeclarationSetParameter : TSqlFragment {
        private Identifier _eventField;

        private ScalarExpression _eventValue;

        public Identifier EventField {
            get {
                return this._eventField;
            }
            set {
                base.UpdateTokenInfo(value);
                this._eventField = value;
            }
        }

        public ScalarExpression EventValue {
            get {
                return this._eventValue;
            }
            set {
                base.UpdateTokenInfo(value);
                this._eventValue = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.EventField?.Accept(visitor);
            this.EventValue?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
