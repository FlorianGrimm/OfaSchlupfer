namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AutoCleanupChangeTrackingOptionDetail : ChangeTrackingOptionDetail {
        public bool IsOn { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
