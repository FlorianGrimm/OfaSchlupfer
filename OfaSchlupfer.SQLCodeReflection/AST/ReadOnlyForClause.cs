namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class ReadOnlyForClause : ForClause {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
