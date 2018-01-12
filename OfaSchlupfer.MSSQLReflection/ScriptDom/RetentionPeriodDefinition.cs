using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class RetentionPeriodDefinition : TSqlFragment {
        private IntegerLiteral _duration;

        private TemporalRetentionPeriodUnit _units;

        private bool _isInfinity;

        public IntegerLiteral Duration {
            get {
                return this._duration;
            }
            set {
                this._duration = value;
            }
        }

        public TemporalRetentionPeriodUnit Units {
            get {
                return this._units;
            }
            set {
                this._units = value;
            }
        }

        public bool IsInfinity {
            get {
                return this._isInfinity;
            }
            set {
                this._isInfinity = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
