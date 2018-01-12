using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class RemoteDataArchiveAlterTableOption : TableOption {
        private RdaTableOption _rdaTableOption;

        private MigrationState _migrationState;

        private bool _isMigrationStateSpecified;

        private bool _isFilterPredicateSpecified;

        private FunctionCall _filterPredicate;

        public RdaTableOption RdaTableOption {
            get {
                return this._rdaTableOption;
            }
            set {
                this._rdaTableOption = value;
            }
        }

        public MigrationState MigrationState {
            get {
                return this._migrationState;
            }
            set {
                this._migrationState = value;
            }
        }

        public bool IsMigrationStateSpecified {
            get {
                return this._isMigrationStateSpecified;
            }
            set {
                this._isMigrationStateSpecified = value;
            }
        }

        public bool IsFilterPredicateSpecified {
            get {
                return this._isFilterPredicateSpecified;
            }
            set {
                this._isFilterPredicateSpecified = value;
            }
        }

        public FunctionCall FilterPredicate {
            get {
                return this._filterPredicate;
            }
            set {
                base.UpdateTokenInfo(value);
                this._filterPredicate = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.FilterPredicate?.Accept(visitor);
        }
    }
}
