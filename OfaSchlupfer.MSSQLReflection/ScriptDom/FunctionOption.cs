namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public /**/ class FunctionOption : TSqlFragment {
        public FunctionOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
