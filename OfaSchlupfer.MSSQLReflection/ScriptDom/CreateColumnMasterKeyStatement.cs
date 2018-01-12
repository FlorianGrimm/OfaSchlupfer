using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CreateColumnMasterKeyStatement : TSqlStatement {
        private Identifier _name;

        private List<ColumnMasterKeyParameter> _parameters = new List<ColumnMasterKeyParameter>();

        public Identifier Name {
            get {
                return this._name;
            }
            set {
                base.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public List<ColumnMasterKeyParameter> Parameters {
            get {
                return this._parameters;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            for (int i=0, count = this.Parameters.Count; i < count; i++) {
                this.Parameters[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
