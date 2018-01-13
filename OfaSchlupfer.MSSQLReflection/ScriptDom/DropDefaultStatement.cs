namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropDefaultStatement : DropObjectsStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
