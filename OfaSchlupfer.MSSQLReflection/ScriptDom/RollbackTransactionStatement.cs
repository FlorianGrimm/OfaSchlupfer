namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class RollbackTransactionStatement : TransactionStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
