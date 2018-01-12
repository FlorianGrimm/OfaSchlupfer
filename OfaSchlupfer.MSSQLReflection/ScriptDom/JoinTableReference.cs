using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class JoinTableReference : TableReference {
        private TableReference _firstTableReference;

        private TableReference _secondTableReference;

        public TableReference FirstTableReference {
            get {
                return this._firstTableReference;
            }
            set {
                base.UpdateTokenInfo(value);
                this._firstTableReference = value;
            }
        }

        public TableReference SecondTableReference {
            get {
                return this._secondTableReference;
            }
            set {
                base.UpdateTokenInfo(value);
                this._secondTableReference = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.FirstTableReference?.Accept(visitor);
            this.SecondTableReference?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
