namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropAggregateStatement : DropObjectsStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
