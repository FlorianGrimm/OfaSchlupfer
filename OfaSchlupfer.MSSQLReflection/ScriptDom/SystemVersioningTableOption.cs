using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SystemVersioningTableOption : TableOption {
        private OptionState _optionState;

        private OptionState _consistencyCheckEnabled;

        private SchemaObjectName _historyTable;

        private RetentionPeriodDefinition _retentionPeriod;

        public OptionState OptionState {
            get {
                return this._optionState;
            }
            set {
                this._optionState = value;
            }
        }

        public OptionState ConsistencyCheckEnabled {
            get {
                return this._consistencyCheckEnabled;
            }
            set {
                this._consistencyCheckEnabled = value;
            }
        }

        public SchemaObjectName HistoryTable {
            get {
                return this._historyTable;
            }
            set {
                base.UpdateTokenInfo(value);
                this._historyTable = value;
            }
        }

        public RetentionPeriodDefinition RetentionPeriod {
            get {
                return this._retentionPeriod;
            }
            set {
                base.UpdateTokenInfo(value);
                this._retentionPeriod = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.HistoryTable?.Accept(visitor);
            this.RetentionPeriod?.Accept(visitor);
        }
    }
}
