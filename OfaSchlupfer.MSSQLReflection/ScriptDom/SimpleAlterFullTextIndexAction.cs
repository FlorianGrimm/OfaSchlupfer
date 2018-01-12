using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SimpleAlterFullTextIndexAction : AlterFullTextIndexAction {
        private SimpleAlterFullTextIndexActionKind _actionKind;

        public SimpleAlterFullTextIndexActionKind ActionKind {
            get {
                return this._actionKind;
            }
            set {
                this._actionKind = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
