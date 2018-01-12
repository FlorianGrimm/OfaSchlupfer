namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class OnlineIndexOption : IndexStateOption {
        private OnlineIndexLowPriorityLockWaitOption _lowPriorityLockWaitOption;

        public OnlineIndexLowPriorityLockWaitOption LowPriorityLockWaitOption {
            get {
                return this._lowPriorityLockWaitOption;
            }
            set {
                base.UpdateTokenInfo(value);
                this._lowPriorityLockWaitOption = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.LowPriorityLockWaitOption?.Accept(visitor);
        }
    }
}
