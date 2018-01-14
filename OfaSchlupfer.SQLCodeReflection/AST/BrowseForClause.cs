namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class BrowseForClause : ForClause {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
