namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class CreateExternalFileFormatStatement : ExternalFileFormatStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
