using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AuditSpecificationPart : TSqlFragment {
        private bool _isDrop;

        private AuditSpecificationDetail _details;

        public bool IsDrop {
            get {
                return this._isDrop;
            }

            set {
                this._isDrop = value;
            }
        }

        public AuditSpecificationDetail Details {
            get {
                return this._details;
            }

            set {
                this.UpdateTokenInfo(value);
                this._details = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Details?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
