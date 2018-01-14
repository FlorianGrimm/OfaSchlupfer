namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterServiceStatement : AlterCreateServiceStatementBase {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
