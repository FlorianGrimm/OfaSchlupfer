using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class UserDefinedTypePropertyAccess : PrimaryExpression {
        private CallTarget _callTarget;

        private Identifier _propertyName;

        public CallTarget CallTarget {
            get {
                return this._callTarget;
            }

            set {
                this.UpdateTokenInfo(value);
                this._callTarget = value;
            }
        }

        public Identifier PropertyName {
            get {
                return this._propertyName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._propertyName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.CallTarget?.Accept(visitor);
            this.PropertyName?.Accept(visitor);
        }
    }
}
