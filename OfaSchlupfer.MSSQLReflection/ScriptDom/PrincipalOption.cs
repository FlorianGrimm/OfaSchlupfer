namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public /**/ class PrincipalOption : TSqlFragment {
        public PrincipalOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
