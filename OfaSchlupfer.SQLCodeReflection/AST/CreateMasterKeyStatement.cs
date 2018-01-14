namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class CreateMasterKeyStatement : MasterKeyStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
