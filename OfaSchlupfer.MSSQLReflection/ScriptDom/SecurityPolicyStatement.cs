using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class SecurityPolicyStatement : TSqlStatement {
        private SchemaObjectName _name;

        private bool _notForReplication;

        private List<SecurityPolicyOption> _securityPolicyOptions = new List<SecurityPolicyOption>();

        private List<SecurityPredicateAction> _securityPredicateActions = new List<SecurityPredicateAction>();

        private SecurityPolicyActionType _actionType;

        public SchemaObjectName Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public bool NotForReplication {
            get {
                return this._notForReplication;
            }

            set {
                this._notForReplication = value;
            }
        }

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

        public SecurityPolicyActionType ActionType {
            get {
                return this._actionType;
            }

            set {
                this._actionType = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
