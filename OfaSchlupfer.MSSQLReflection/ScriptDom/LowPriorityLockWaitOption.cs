using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class LowPriorityLockWaitOption : TSqlFragment {
        private LowPriorityLockWaitOptionKind _optionKind;

        public LowPriorityLockWaitOptionKind OptionKind {
            get {
                return this._optionKind;
            }
            set {
                this._optionKind = value;
            }
        }
    }
}
