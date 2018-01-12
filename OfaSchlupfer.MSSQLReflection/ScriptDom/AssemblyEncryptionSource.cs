using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AssemblyEncryptionSource : EncryptionSource {
        private Identifier _assembly;

        public Identifier Assembly {
            get {
                return this._assembly;
            }
            set {
                base.UpdateTokenInfo(value);
                this._assembly = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Assembly?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
