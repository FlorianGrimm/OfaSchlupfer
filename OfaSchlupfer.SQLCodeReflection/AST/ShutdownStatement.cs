namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class ShutdownStatement : TSqlStatement {
        public bool WithNoWait { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
