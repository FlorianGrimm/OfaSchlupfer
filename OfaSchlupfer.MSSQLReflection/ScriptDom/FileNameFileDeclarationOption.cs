using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class FileNameFileDeclarationOption : FileDeclarationOption {
        private Literal _oSFileName;

        public Literal OSFileName {
            get {
                return this._oSFileName;
            }
            set {
                base.UpdateTokenInfo(value);
                this._oSFileName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.OSFileName?.Accept(visitor);
        }
    }
}
