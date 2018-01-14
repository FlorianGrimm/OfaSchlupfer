using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class TablePartitionOptionSpecifications : PartitionSpecifications {
        private PartitionTableOptionRange _range;

        private List<ScalarExpression> _boundaryValues = new List<ScalarExpression>();

        public PartitionTableOptionRange Range {
            get {
                return this._range;
            }

            set {
                this._range = value;
            }
        }

        public List<ScalarExpression> BoundaryValues {
            get {
                return this._boundaryValues;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i = 0, count = this.BoundaryValues.Count; i < count; i++) {
                this.BoundaryValues[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
