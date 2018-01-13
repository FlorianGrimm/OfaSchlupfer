namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CreateExternalDataSourceStatement : ExternalDataSourceStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
