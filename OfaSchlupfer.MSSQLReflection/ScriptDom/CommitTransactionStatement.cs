using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CommitTransactionStatement : TransactionStatement {
        private OptionState _delayedDurabilityOption;

        public OptionState DelayedDurabilityOption {
            get {
                return this._delayedDurabilityOption;
            }

            set {
                this._delayedDurabilityOption = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
