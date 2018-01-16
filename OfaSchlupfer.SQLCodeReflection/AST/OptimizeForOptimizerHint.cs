namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class OptimizeForOptimizerHint : OptimizerHint {
        public List<VariableValuePair> Pairs { get; } = new List<VariableValuePair>();

        public bool IsForUnknown { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Pairs.Accept(visitor);
        }
    }
}
