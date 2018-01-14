namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterRouteStatement : RouteStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
