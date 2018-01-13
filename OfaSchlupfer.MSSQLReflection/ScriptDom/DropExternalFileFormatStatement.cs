namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropExternalFileFormatStatement : DropUnownedObjectStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
