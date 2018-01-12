using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AuditActionGroupReference : AuditSpecificationDetail {
        private AuditActionGroup _group;

        public AuditActionGroup Group {
            get {
                return this._group;
            }

            set {
                this._group = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
