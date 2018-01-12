namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class OnOffStatisticsOption : StatisticsOption {
        public OptionState OptionState { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
