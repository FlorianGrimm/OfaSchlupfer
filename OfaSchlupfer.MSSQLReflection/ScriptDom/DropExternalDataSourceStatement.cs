namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropExternalDataSourceStatement : DropUnownedObjectStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
