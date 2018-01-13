namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropUserStatement : DropUnownedObjectStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
