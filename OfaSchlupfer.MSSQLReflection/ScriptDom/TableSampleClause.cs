using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class TableSampleClause : TSqlFragment {
        private bool _system;

        private ScalarExpression _sampleNumber;

        private TableSampleClauseOption _tableSampleClauseOption;

        private ScalarExpression _repeatSeed;

        public bool System {
            get {
                return this._system;
            }

            set {
                this._system = value;
            }
        }

        public ScalarExpression SampleNumber {
            get {
                return this._sampleNumber;
            }

            set {
                this.UpdateTokenInfo(value);
                this._sampleNumber = value;
            }
        }

        public TableSampleClauseOption TableSampleClauseOption {
            get {
                return this._tableSampleClauseOption;
            }

            set {
                this._tableSampleClauseOption = value;
            }
        }

        public ScalarExpression RepeatSeed {
            get {
                return this._repeatSeed;
            }

            set {
                this.UpdateTokenInfo(value);
                this._repeatSeed = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SampleNumber?.Accept(visitor);
            this.RepeatSeed?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
