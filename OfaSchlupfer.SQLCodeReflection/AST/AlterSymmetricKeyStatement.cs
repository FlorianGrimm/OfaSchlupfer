namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterSymmetricKeyStatement : SymmetricKeyStatement {
        public bool IsAdd { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.EncryptingMechanisms.Accept(visitor);
        }
    }
}
