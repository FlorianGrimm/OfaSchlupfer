using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class FileTableCollateFileNameTableOption : TableOption {
        private Identifier _value;

        public Identifier Value {
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
            base.AcceptChildren(visitor);
            this.Value?.Accept(visitor);
        }
    }
}
