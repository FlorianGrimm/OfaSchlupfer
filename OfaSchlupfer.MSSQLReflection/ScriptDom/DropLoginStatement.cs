namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropLoginStatement : DropUnownedObjectStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
