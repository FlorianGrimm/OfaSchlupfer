using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class ColumnEncryptionKeyStatement : TSqlStatement {
        private Identifier _name;

        private List<ColumnEncryptionKeyValue> _columnEncryptionKeyValues = new List<ColumnEncryptionKeyValue>();

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public List<ColumnEncryptionKeyValue> ColumnEncryptionKeyValues {
            get {
                return this._columnEncryptionKeyValues;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            for (int i=0, count = this.ColumnEncryptionKeyValues.Count; i < count; i++) {
                this.ColumnEncryptionKeyValues[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
