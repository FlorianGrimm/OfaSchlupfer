namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public /**/ class DatabaseOption : TSqlFragment {

        public DatabaseOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
        }
    }
}
