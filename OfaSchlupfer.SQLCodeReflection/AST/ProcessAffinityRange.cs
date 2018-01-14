namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class ProcessAffinityRange : LiteralRange {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
