namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class OnOffPrincipalOption : PrincipalOption {
        public OptionState OptionState { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
