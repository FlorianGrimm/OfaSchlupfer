namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropRoleStatement : DropUnownedObjectStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
