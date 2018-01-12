using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ResourcePoolParameter : TSqlFragment {
        private ResourcePoolParameterType _parameterType;

        private Literal _parameterValue;

        private ResourcePoolAffinitySpecification _affinitySpecification;

        public ResourcePoolParameterType ParameterType {
            get {
                return this._parameterType;
            }

            set {
                this._parameterType = value;
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

        public ResourcePoolAffinitySpecification AffinitySpecification {
            get {
                return this._affinitySpecification;
            }

            set {
                this.UpdateTokenInfo(value);
                this._affinitySpecification = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.ParameterValue?.Accept(visitor);
            this.AffinitySpecification?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
