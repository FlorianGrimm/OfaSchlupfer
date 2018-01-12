using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class VariableValuePair : TSqlFragment {
        private VariableReference _variable;

        private ScalarExpression _value;

        private bool _isForUnknown;

        public VariableReference Variable {
            get {
                return this._variable;
            }
            set {
                base.UpdateTokenInfo(value);
                this._variable = value;
            }
        }

        public ScalarExpression Value {
            get {
                return this._value;
            }
            set {
                base.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public bool IsForUnknown {
            get {
                return this._isForUnknown;
            }
            set {
                this._isForUnknown = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Variable?.Accept(visitor);
            this.Value?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
