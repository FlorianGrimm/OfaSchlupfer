using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SecurityPrincipal : TSqlFragment {
        private PrincipalType _principalType;

        private Identifier _identifier;

        public PrincipalType PrincipalType {
            get {
                return this._principalType;
            }
            set {
                this._principalType = value;
            }
        }

        public Identifier Identifier {
            get {
                return this._identifier;
            }
            set {
                base.UpdateTokenInfo(value);
                this._identifier = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Identifier?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
