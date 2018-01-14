namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class BackupServiceMasterKeyStatement : BackupRestoreMasterKeyStatementBase {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
