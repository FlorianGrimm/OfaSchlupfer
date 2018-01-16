namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class SecurityPolicyStatement : TSqlStatement {
        private SchemaObjectName _name;

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

        public List<SecurityPolicyOption> SecurityPolicyOptions { get; } = new List<SecurityPolicyOption>();

        public List<SecurityPredicateAction> SecurityPredicateActions { get; } = new List<SecurityPredicateAction>();

        public SecurityPolicyActionType ActionType { get; set; }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
