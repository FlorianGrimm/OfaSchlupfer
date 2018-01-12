using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class OnFailureAuditOption : AuditOption {
        private AuditFailureActionType _onFailureAction;

        public AuditFailureActionType OnFailureAction {
            get {
                return this._onFailureAction;
            }
            set {
                this._onFailureAction = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
