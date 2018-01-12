using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class AlterLoginStatement : TSqlStatement {
        private Identifier _name;

        public Identifier Name {
            get {
                return this._name;
            }
            set {
                base.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
