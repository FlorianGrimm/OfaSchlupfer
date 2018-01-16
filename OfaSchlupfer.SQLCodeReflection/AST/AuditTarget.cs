namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AuditTarget : TSqlFragment {
        private AuditTargetKind _targetKind;

        public AuditTargetKind TargetKind {
            get {
                return this._targetKind;
            }

            set {
                this._targetKind = value;
            }
        }

        public List<AuditTargetOption> TargetOptions { get; } = new List<AuditTargetOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.TargetOptions.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
