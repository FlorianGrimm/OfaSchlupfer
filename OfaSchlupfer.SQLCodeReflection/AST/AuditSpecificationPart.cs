namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AuditSpecificationPart : TSqlFragment {
        private AuditSpecificationDetail _details;

        public bool IsDrop { get; set; }

        public AuditSpecificationDetail Details {
            get {
                return this._details;
            }

            set {
                this.UpdateTokenInfo(value);
                this._details = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Details?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
