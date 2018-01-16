namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class BackupDatabaseStatement : BackupStatement {
        public List<BackupRestoreFileInfo> Files { get; } = new List<BackupRestoreFileInfo>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Files.Accept(visitor);
        }
    }
}
