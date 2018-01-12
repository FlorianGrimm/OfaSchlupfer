using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SetIdentityInsertStatement : SetOnOffStatement {
        private SchemaObjectName _table;

        public SchemaObjectName Table {
            get {
                return this._table;
            }
            set {
                base.UpdateTokenInfo(value);
                this._table = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Table?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
