namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AuditActionSpecification : AuditSpecificationDetail {
        private SecurityTargetObject _targetObject;

        public List<DatabaseAuditAction> Actions { get; } = new List<DatabaseAuditAction>();

        public List<SecurityPrincipal> Principals { get; } = new List<SecurityPrincipal>();

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
            this.Actions.Accept(visitor);
            this.Principals.Accept(visitor);
            this.TargetObject?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
