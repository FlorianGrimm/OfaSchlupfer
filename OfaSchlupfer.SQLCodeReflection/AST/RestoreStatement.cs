namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class RestoreStatement : TSqlStatement {
        private IdentifierOrValueExpression _databaseName;

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

        public List<DeviceInfo> Devices { get; } = new List<DeviceInfo>();

        public List<BackupRestoreFileInfo> Files { get; } = new List<BackupRestoreFileInfo>();

        public List<RestoreOption> Options { get; } = new List<RestoreOption>();

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
            this.Devices.Accept(visitor);
            this.Files.Accept(visitor);
            this.Options.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
