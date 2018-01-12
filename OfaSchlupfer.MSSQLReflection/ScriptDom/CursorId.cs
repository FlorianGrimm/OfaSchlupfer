using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CursorId : TSqlFragment {
        private bool _isGlobal;

        private IdentifierOrValueExpression _name;

        public bool IsGlobal {
            get {
                return this._isGlobal;
            }

            set {
                this._isGlobal = value;
            }
        }

        public IdentifierOrValueExpression Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
