using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class LowPriorityLockWaitAbortAfterWaitOption : LowPriorityLockWaitOption {
        private AbortAfterWaitType _abortAfterWait;

        public AbortAfterWaitType AbortAfterWait {
            get {
                return this._abortAfterWait;
            }
            set {
                this._abortAfterWait = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
