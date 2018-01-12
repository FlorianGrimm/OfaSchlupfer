namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public /**/ class ExecuteOption : TSqlFragment {
        public ExecuteOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) {
            if (visitor != null) {
                visitor.ExplicitVisit(this);
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
        }
    }
}
