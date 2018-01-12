namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public /**/ class SequenceOption : TSqlFragment {
        public SequenceOptionKind OptionKind { get; set; }

        public bool NoValue { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
