using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AuditTarget : TSqlFragment {
        private AuditTargetKind _targetKind;

        private List<AuditTargetOption> _targetOptions = new List<AuditTargetOption>();

        public AuditTargetKind TargetKind {
            get {
                return this._targetKind;
            }
            set {
                this._targetKind = value;
            }
        }

        public List<AuditTargetOption> TargetOptions {
            get {
                return this._targetOptions;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i=0, count = this.TargetOptions.Count; i < count; i++) {
                this.TargetOptions[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
