namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class SecurityStatement : TSqlStatement {
        private SecurityTargetObject _securityTargetObject;

        private Identifier _asClause;

        public List<Permission> Permissions { get; } = new List<Permission>();

        public SecurityTargetObject SecurityTargetObject {
            get {
                return this._securityTargetObject;
            }

            set {
                this.UpdateTokenInfo(value);
                this._securityTargetObject = value;
            }
        }

        public List<SecurityPrincipal> Principals { get; } = new List<SecurityPrincipal>();

        public Identifier AsClause {
            get {
                return this._asClause;
            }

            set {
                this.UpdateTokenInfo(value);
                this._asClause = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Permissions.Accept(visitor);
            this.SecurityTargetObject?.Accept(visitor);
            this.Principals.Accept(visitor);
            this.AsClause?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
