using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterAuthorizationStatement : TSqlStatement {
        private SecurityTargetObject _securityTargetObject;

        private bool _toSchemaOwner;

        private Identifier _principalName;

        public SecurityTargetObject SecurityTargetObject {
            get {
                return this._securityTargetObject;
            }

            set {
                this.UpdateTokenInfo(value);
                this._securityTargetObject = value;
            }
        }

        public bool ToSchemaOwner {
            get {
                return this._toSchemaOwner;
            }

            set {
                this._toSchemaOwner = value;
            }
        }

        public Identifier PrincipalName {
            get {
                return this._principalName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._principalName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SecurityTargetObject?.Accept(visitor);
            this.PrincipalName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
