namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class RetentionPeriodDefinition : TSqlFragment {
        public IntegerLiteral Duration { get; set; }

        public TemporalRetentionPeriodUnit Units { get; set; }

        public bool IsInfinity { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
