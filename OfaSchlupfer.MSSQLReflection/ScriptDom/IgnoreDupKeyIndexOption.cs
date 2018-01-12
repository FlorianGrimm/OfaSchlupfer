namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class IgnoreDupKeyIndexOption : IndexStateOption {
        public bool? SuppressMessagesOption { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
