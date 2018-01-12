namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public /**/ class BulkInsertOption : TSqlFragment {
        public BulkInsertOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
