namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterApplicationRoleStatement : ApplicationRoleStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
