namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class DropSequenceStatement : DropObjectsStatement {
        public override void Accept(TSqlFragmentVisitor visitor) {
            if (visitor != null) {
                visitor.ExplicitVisit(this);
            }
        }
    }
}
