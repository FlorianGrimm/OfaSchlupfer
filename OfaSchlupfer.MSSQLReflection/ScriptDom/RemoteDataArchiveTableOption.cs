using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class RemoteDataArchiveTableOption : TableOption {
        private RdaTableOption _rdaTableOption;

        private MigrationState _migrationState;

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

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
