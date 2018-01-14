namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class ReconfigureStatement : TSqlStatement {
        public bool WithOverride { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
