namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropCredentialStatement : DropUnownedObjectStatement {
        public bool IsDatabaseScoped { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
