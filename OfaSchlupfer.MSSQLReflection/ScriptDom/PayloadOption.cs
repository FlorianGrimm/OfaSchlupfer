using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class PayloadOption : TSqlFragment {
        private PayloadOptionKinds _kind;

        public PayloadOptionKinds Kind {
            get {
                return this._kind;
            }
            set {
                this._kind = value;
            }
        }
    }
}
