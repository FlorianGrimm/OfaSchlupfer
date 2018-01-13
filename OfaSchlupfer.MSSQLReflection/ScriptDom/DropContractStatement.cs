namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropContractStatement : DropUnownedObjectStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
