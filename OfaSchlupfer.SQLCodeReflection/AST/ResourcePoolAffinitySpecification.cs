namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class ResourcePoolAffinitySpecification : TSqlFragment {
        private ResourcePoolAffinityType _affinityType;

        private Literal _parameterValue;

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

        public List<LiteralRange> PoolAffinityRanges { get; } = new List<LiteralRange>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.ParameterValue?.Accept(visitor);
            this.PoolAffinityRanges.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
