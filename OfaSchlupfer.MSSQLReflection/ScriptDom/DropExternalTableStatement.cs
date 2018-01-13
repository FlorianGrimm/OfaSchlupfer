namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropExternalTableStatement : DropObjectsStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
