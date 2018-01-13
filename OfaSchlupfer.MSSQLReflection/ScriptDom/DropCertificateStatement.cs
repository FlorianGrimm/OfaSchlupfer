namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropCertificateStatement : DropUnownedObjectStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
