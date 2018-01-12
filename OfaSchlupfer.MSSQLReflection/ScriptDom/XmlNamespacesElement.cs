using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class XmlNamespacesElement : TSqlFragment {
        private StringLiteral _string;

        public StringLiteral String {
            get {
                return this._string;
            }
            set {
                base.UpdateTokenInfo(value);
                this._string = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.String?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
