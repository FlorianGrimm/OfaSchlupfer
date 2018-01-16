namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class TablePartitionOptionSpecifications : PartitionSpecifications {
        private PartitionTableOptionRange _range;

        public PartitionTableOptionRange Range {
            get {
                return this._range;
            }

            set {
                this._range = value;
            }
        }

        public List<ScalarExpression> BoundaryValues { get; } = new List<ScalarExpression>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.BoundaryValues.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
