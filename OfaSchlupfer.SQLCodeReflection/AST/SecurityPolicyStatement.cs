using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public abstract class SecurityPolicyStatement : TSqlStatement {
        private SchemaObjectName _name;

        private List<SecurityPolicyOption> _securityPolicyOptions = new List<SecurityPolicyOption>();

        private List<SecurityPredicateAction> _securityPredicateActions = new List<SecurityPredicateAction>();

        public SchemaObjectName Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public bool NotForReplication { get; set; }

        public List<SecurityPolicyOption> SecurityPolicyOptions {
            get {
                return this._securityPolicyOptions;
            }
        }

        public List<SecurityPredicateAction> SecurityPredicateActions {
            get {
                return this._securityPredicateActions;
            }
        }

        public SecurityPolicyActionType ActionType { get; set; }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
