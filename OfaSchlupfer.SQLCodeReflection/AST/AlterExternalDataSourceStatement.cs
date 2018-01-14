namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterExternalDataSourceStatement : ExternalDataSourceStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
