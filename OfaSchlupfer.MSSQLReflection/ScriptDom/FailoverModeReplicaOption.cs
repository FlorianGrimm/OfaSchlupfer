namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class FailoverModeReplicaOption : AvailabilityReplicaOption {
        public FailoverModeOptionKind Value { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
