namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropFullTextStopListStatement : DropUnownedObjectStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
