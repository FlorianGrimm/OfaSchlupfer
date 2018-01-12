namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public /**/ class IndexStateOption : IndexOption {

        public OptionState OptionState { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
