namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public /**/ class TriggerOption : TSqlFragment {
        public TriggerOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
