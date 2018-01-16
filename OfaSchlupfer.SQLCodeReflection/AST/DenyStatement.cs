namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class DenyStatement : SecurityStatement {
        public bool CascadeOption { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Permissions.Accept(visitor);
            this.SecurityTargetObject?.Accept(visitor);
            this.Principals.Accept(visitor);
            this.AsClause?.Accept(visitor);
        }
    }
}
