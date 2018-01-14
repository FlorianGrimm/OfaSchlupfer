using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class RestoreStatement : TSqlStatement {
        private IdentifierOrValueExpression _databaseName;

        private List<DeviceInfo> _devices = new List<DeviceInfo>();

        private List<BackupRestoreFileInfo> _files = new List<BackupRestoreFileInfo>();

        private List<RestoreOption> _options = new List<RestoreOption>();

        private RestoreStatementKind _kind;

        public IdentifierOrValueExpression DatabaseName {
            get {
                return this._databaseName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._databaseName = value;
            }
        }

        public List<DeviceInfo> Devices {
            get {
                return this._devices;
            }
        }

        public List<BackupRestoreFileInfo> Files {
            get {
                return this._files;
            }
        }

        public List<RestoreOption> Options {
            get {
                return this._options;
            }
        }

        public RestoreStatementKind Kind {
            get {
                return this._kind;
            }

            set {
                this._kind = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.DatabaseName?.Accept(visitor);
            for (int i = 0, count = this.Devices.Count; i < count; i++) {
                this.Devices[i].Accept(visitor);
            }
            int j = 0;
            for (int count2 = this.Files.Count; j < count2; j++) {
                this.Files[j].Accept(visitor);
            }
            int k = 0;
            for (int count3 = this.Options.Count; k < count3; k++) {
                this.Options[k].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
