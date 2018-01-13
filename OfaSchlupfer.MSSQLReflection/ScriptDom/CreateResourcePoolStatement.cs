namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CreateResourcePoolStatement : ResourcePoolStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
