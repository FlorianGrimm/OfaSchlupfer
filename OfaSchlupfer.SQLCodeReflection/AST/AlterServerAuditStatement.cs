namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterServerAuditStatement : ServerAuditStatement {
        private Identifier _newName;

        public Identifier NewName {
            get {
                return this._newName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._newName = value;
            }
        }

        public bool RemoveWhere { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.NewName?.Accept(visitor);
        }
    }
}
