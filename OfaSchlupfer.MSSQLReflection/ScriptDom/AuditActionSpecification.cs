using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AuditActionSpecification : AuditSpecificationDetail {
        private List<DatabaseAuditAction> _actions = new List<DatabaseAuditAction>();

        private List<SecurityPrincipal> _principals = new List<SecurityPrincipal>();

        private SecurityTargetObject _targetObject;

        public List<DatabaseAuditAction> Actions {
            get {
                return this._actions;
            }
        }

        public List<SecurityPrincipal> Principals {
            get {
                return this._principals;
            }
        }

        public SecurityTargetObject TargetObject {
            get {
                return this._targetObject;
            }

            set {
                this.UpdateTokenInfo(value);
                this._targetObject = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i = 0, count = this.Actions.Count; i < count; i++) {
                this.Actions[i].Accept(visitor);
            }
            int j = 0;
            for (int count2 = this.Principals.Count; j < count2; j++) {
                this.Principals[j].Accept(visitor);
            }
            this.TargetObject?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
