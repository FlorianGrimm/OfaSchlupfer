namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class BackupStatement : TSqlStatement {
        private IdentifierOrValueExpression _databaseName;

        public IdentifierOrValueExpression DatabaseName {
            get {
                return this._databaseName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._databaseName = value;
            }
        }

        public List<BackupOption> Options { get; } = new List<BackupOption>();

        public List<MirrorToClause> MirrorToClauses { get; } = new List<MirrorToClause>();

        public List<DeviceInfo> Devices { get; } = new List<DeviceInfo>();

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.DatabaseName?.Accept(visitor);
            this.Options.Accept(visitor);
            this.MirrorToClauses.Accept(visitor);
            this.Devices.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
