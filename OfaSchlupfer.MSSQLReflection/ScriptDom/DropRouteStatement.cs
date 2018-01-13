namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropRouteStatement : DropUnownedObjectStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
