namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterExternalResourcePoolStatement : ExternalResourcePoolStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
