using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class RevokeStatement : SecurityStatement {
        private bool _grantOptionFor;

        private bool _cascadeOption;

        public bool GrantOptionFor {
            get {
                return this._grantOptionFor;
            }

            set {
                this._grantOptionFor = value;
            }
        }

        public bool CascadeOption {
            get {
                return this._cascadeOption;
            }

            set {
                this._cascadeOption = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i=0, count = base.Permissions.Count; i < count; i++) {
                base.Permissions[i].Accept(visitor);
            }
            if (base.SecurityTargetObject != null) {
                base.SecurityTargetObject.Accept(visitor);
            }
            int j = 0;
            for (int count2 = base.Principals.Count; j < count2; j++) {
                base.Principals[j].Accept(visitor);
            }
            if (base.AsClause != null) {
                base.AsClause.Accept(visitor);
            }
        }
    }
}
