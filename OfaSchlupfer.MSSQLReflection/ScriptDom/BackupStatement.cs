using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class BackupStatement : TSqlStatement {
        private IdentifierOrValueExpression _databaseName;

        private List<BackupOption> _options = new List<BackupOption>();

        private List<MirrorToClause> _mirrorToClauses = new List<MirrorToClause>();

        private List<DeviceInfo> _devices = new List<DeviceInfo>();

        public IdentifierOrValueExpression DatabaseName {
            get {
                return this._databaseName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._databaseName = value;
            }
        }

        public List<BackupOption> Options {
            get {
                return this._options;
            }
        }

        public List<MirrorToClause> MirrorToClauses {
            get {
                return this._mirrorToClauses;
            }
        }

        public List<DeviceInfo> Devices {
            get {
                return this._devices;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.DatabaseName?.Accept(visitor);
            for (int i = 0, count = this.Options.Count; i < count; i++) {
                this.Options[i].Accept(visitor);
            }
            int j = 0;
            for (int count2 = this.MirrorToClauses.Count; j < count2; j++) {
                this.MirrorToClauses[j].Accept(visitor);
            }
            int k = 0;
            for (int count3 = this.Devices.Count; k < count3; k++) {
                this.Devices[k].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
