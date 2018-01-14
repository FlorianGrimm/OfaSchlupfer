namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class CreateApplicationRoleStatement : ApplicationRoleStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
