namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterSymmetricKeyStatement : SymmetricKeyStatement {
        public bool IsAdd { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (base.Name != null) {
                base.Name.Accept(visitor);
            }
            for (int i = 0, count = base.EncryptingMechanisms.Count; i < count; i++) {
                base.EncryptingMechanisms[i].Accept(visitor);
            }
        }
    }
}
