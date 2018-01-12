using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AutomaticTuningDatabaseOption : DatabaseOption {
        private AutomaticTuningState _automaticTuningState;

        private List<AutomaticTuningOption> _options = new List<AutomaticTuningOption>();

        public AutomaticTuningState AutomaticTuningState {
            get {
                return this._automaticTuningState;
            }
            set {
                this._automaticTuningState = value;
            }
        }

        public List<AutomaticTuningOption> Options {
            get {
                return this._options;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            for (int i=0, count = this.Options.Count; i < count; i++) {
                this.Options[i].Accept(visitor);
            }
        }
    }
}
