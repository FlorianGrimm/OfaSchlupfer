namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class CreateExternalTableStatement : ExternalTableStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
