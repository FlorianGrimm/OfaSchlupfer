namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterAuthorizationStatement : TSqlStatement {
        private SecurityTargetObject _securityTargetObject;

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

        public bool ToSchemaOwner { get; set; }

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
