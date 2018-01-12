using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class TableReferenceWithAlias : TableReference {
        private Identifier _alias;

        public Identifier Alias {
            get {
                return this._alias;
            }
            set {
                base.UpdateTokenInfo(value);
                this._alias = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Alias?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
