namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropServerRoleStatement : DropUnownedObjectStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
