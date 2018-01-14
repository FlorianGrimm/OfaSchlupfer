namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class CreateServerRoleStatement : CreateRoleStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
