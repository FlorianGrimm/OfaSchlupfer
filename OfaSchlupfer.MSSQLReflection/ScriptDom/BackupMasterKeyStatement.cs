namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class BackupMasterKeyStatement : BackupRestoreMasterKeyStatementBase {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
