using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ChangeTrackingDatabaseOption : DatabaseOption {
        private OptionState _optionState;

        private List<ChangeTrackingOptionDetail> _details = new List<ChangeTrackingOptionDetail>();

        public OptionState OptionState {
            get {
                return this._optionState;
            }
            set {
                this._optionState = value;
            }
        }

        public List<ChangeTrackingOptionDetail> Details {
            get {
                return this._details;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            for (int i=0, count = this.Details.Count; i < count; i++) {
                this.Details[i].Accept(visitor);
            }
        }
    }
}
