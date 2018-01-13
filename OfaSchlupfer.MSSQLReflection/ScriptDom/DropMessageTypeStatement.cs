namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropMessageTypeStatement : DropUnownedObjectStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
