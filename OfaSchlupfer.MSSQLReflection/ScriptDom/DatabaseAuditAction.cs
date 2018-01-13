namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DatabaseAuditAction : TSqlFragment {
        public DatabaseAuditActionKind ActionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
