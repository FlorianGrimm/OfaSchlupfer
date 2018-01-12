using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class EndpointAffinity : TSqlFragment {
        private AffinityKind _kind;

        private Literal _value;

        public AffinityKind Kind {
            get {
                return this._kind;
            }

            set {
                this._kind = value;
            }
        }

        public Literal Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Value?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
