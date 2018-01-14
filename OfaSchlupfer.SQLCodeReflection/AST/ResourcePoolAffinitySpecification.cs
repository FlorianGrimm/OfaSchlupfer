using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class ResourcePoolAffinitySpecification : TSqlFragment {
        private ResourcePoolAffinityType _affinityType;

        private Literal _parameterValue;

        private List<LiteralRange> _poolAffinityRanges = new List<LiteralRange>();

        public ResourcePoolAffinityType AffinityType {
            get {
                return this._affinityType;
            }

            set {
                this._affinityType = value;
            }
        }

        public Literal ParameterValue {
            get {
                return this._parameterValue;
            }

            set {
                this.UpdateTokenInfo(value);
                this._parameterValue = value;
            }
        }

        public bool IsAuto { get; set; }

        public List<LiteralRange> PoolAffinityRanges {
            get {
                return this._poolAffinityRanges;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.ParameterValue?.Accept(visitor);
            for (int i = 0, count = this.PoolAffinityRanges.Count; i < count; i++) {
                this.PoolAffinityRanges[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
