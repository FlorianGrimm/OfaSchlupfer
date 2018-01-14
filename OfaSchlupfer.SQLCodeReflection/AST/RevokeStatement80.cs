namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class RevokeStatement80 : SecurityStatementBody80 {
        private Identifier _asClause;

        public bool GrantOptionFor { get; set; }

        public bool CascadeOption { get; set; }

        public Identifier AsClause {
            get {
                return this._asClause;
            }

            set {
                this.UpdateTokenInfo(value);
                this._asClause = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.AsClause?.Accept(visitor);
        }
    }
}
