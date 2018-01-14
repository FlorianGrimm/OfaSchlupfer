namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class CreateBrokerPriorityStatement : BrokerPriorityStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
