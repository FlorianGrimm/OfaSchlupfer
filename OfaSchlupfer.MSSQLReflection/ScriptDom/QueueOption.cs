namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public /**/ class QueueOption : TSqlFragment {
        public QueueOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
