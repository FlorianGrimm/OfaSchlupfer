using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CertificateOption : TSqlFragment {
        private CertificateOptionKinds _kind;

        private Literal _value;

        public CertificateOptionKinds Kind {
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
                base.UpdateTokenInfo(value);
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
