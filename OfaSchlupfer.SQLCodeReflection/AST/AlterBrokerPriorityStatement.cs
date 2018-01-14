namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterBrokerPriorityStatement : BrokerPriorityStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
