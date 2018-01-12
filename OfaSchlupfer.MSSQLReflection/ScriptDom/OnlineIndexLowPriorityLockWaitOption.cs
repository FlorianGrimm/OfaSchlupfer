using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class OnlineIndexLowPriorityLockWaitOption : TSqlFragment {
        private List<LowPriorityLockWaitOption> _options = new List<LowPriorityLockWaitOption>();

        public List<LowPriorityLockWaitOption> Options {
            get {
                return this._options;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i=0, count = this.Options.Count; i < count; i++) {
                this.Options[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
