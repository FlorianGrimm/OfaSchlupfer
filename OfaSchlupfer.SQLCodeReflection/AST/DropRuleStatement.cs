namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class DropRuleStatement : DropObjectsStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
