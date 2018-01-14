namespace OfaSchlupfer.AST {
    [System.Serializable]
    public class OptimizerHint : TSqlFragment {
        public OptimizerHintKind HintKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
