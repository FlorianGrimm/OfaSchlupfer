namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterResourcePoolStatement : ResourcePoolStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
