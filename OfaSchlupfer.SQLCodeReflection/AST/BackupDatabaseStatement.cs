using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class BackupDatabaseStatement : BackupStatement {
        private List<BackupRestoreFileInfo> _files = new List<BackupRestoreFileInfo>();

        public List<BackupRestoreFileInfo> Files {
            get {
                return this._files;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            for (int i = 0, count = this.Files.Count; i < count; i++) {
                this.Files[i].Accept(visitor);
            }
        }
    }
}
