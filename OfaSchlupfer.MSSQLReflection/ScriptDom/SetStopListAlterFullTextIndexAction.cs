using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SetStopListAlterFullTextIndexAction : AlterFullTextIndexAction {
        private StopListFullTextIndexOption _stopListOption;

        private bool _withNoPopulation;

        public StopListFullTextIndexOption StopListOption {
            get {
                return this._stopListOption;
            }
            set {
                base.UpdateTokenInfo(value);
                this._stopListOption = value;
            }
        }

        public bool WithNoPopulation {
            get {
                return this._withNoPopulation;
            }
            set {
                this._withNoPopulation = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.StopListOption?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
