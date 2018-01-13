using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class OptimizeForOptimizerHint : OptimizerHint {
        private List<VariableValuePair> _pairs = new List<VariableValuePair>();

        private bool _isForUnknown;

        public List<VariableValuePair> Pairs {
            get {
                return this._pairs;
            }
        }

        public bool IsForUnknown {
            get {
                return this._isForUnknown;
            }

            set {
                this._isForUnknown = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            for (int i = 0, count = this.Pairs.Count; i < count; i++) {
                this.Pairs[i].Accept(visitor);
            }
        }
    }
}
