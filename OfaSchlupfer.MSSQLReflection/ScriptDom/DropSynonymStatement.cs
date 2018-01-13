namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropSynonymStatement : DropObjectsStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
