namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropViewStatement : DropObjectsStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
