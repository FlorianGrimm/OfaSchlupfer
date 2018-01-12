namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class AutomaticTuningOption : TSqlFragment {
        public AutomaticTuningOptionKind OptionKind { get; set; }

        public AutomaticTuningOptionState Value { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
