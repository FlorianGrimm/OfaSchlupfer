namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class BackupTransactionLogStatement : BackupStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
