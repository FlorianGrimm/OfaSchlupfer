using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class XmlNamespacesAliasElement : XmlNamespacesElement {
        private Identifier _identifier;

        public Identifier Identifier {
            get {
                return this._identifier;
            }
            set {
                base.UpdateTokenInfo(value);
                this._identifier = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Identifier?.Accept(visitor);
        }
    }
}
