namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public /**/ class OnOffDatabaseOption : DatabaseOption {
        public OptionState OptionState { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
