namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public /**/ class StatisticsOption : TSqlFragment {
        public StatisticsOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
