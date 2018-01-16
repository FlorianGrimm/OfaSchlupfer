namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class GrantStatement : SecurityStatement {
        public bool WithGrantOption { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Permissions.Accept(visitor);
            this.SecurityTargetObject?.Accept(visitor);
            this.Principals.Accept(visitor);
            this.AsClause?.Accept(visitor);
        }
    }
}
