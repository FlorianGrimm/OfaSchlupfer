namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class CreateExternalResourcePoolStatement : ExternalResourcePoolStatement {
        public override void Accept(TSqlFragmentVisitor visitor) {
            visitor?.ExplicitVisit(this);
        }
    }
}
