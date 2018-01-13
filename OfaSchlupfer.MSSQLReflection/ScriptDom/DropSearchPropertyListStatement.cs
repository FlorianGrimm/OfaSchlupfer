namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropSearchPropertyListStatement : DropUnownedObjectStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
