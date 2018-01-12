using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class SecurityStatement : TSqlStatement {
        private List<Permission> _permissions = new List<Permission>();

        private SecurityTargetObject _securityTargetObject;

        private List<SecurityPrincipal> _principals = new List<SecurityPrincipal>();

        private Identifier _asClause;

        public List<Permission> Permissions {
            get {
                return this._permissions;
            }
        }

        public SecurityTargetObject SecurityTargetObject {
            get {
                return this._securityTargetObject;
            }
            set {
                base.UpdateTokenInfo(value);
                this._securityTargetObject = value;
            }
        }

        public List<SecurityPrincipal> Principals {
            get {
                return this._principals;
            }
        }

        public Identifier AsClause {
            get {
                return this._asClause;
            }
            set {
                base.UpdateTokenInfo(value);
                this._asClause = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i=0, count = this.Permissions.Count; i < count; i++) {
                this.Permissions[i].Accept(visitor);
            }
            this.SecurityTargetObject?.Accept(visitor);
            int j = 0;
            for (int count2 = this.Principals.Count; j < count2; j++) {
                this.Principals[j].Accept(visitor);
            }
            this.AsClause?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
