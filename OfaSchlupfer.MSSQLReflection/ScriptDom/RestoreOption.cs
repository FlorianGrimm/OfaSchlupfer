namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public /**/ class RestoreOption : TSqlFragment {

        public RestoreOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
