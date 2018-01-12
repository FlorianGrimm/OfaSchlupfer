namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public /**/ class ProcedureOption : TSqlFragment {
        public ProcedureOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
