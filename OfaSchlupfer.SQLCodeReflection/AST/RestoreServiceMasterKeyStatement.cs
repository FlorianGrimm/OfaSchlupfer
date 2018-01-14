namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class RestoreServiceMasterKeyStatement : BackupRestoreMasterKeyStatementBase {
        public bool IsForce { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
