namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterViewStatement : ViewStatementBody {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
