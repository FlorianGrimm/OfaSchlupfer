namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class OnOffPrimaryConfigurationOption : DatabaseConfigurationSetOption {
        public DatabaseConfigurationOptionState OptionState { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
