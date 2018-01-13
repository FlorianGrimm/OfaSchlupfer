namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SaveTransactionStatement : TransactionStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
