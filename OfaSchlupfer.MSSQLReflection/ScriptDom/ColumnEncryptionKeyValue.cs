using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ColumnEncryptionKeyValue : TSqlFragment {
        private List<ColumnEncryptionKeyValueParameter> _parameters = new List<ColumnEncryptionKeyValueParameter>();

        public List<ColumnEncryptionKeyValueParameter> Parameters {
            get {
                return this._parameters;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i=0, count = this.Parameters.Count; i < count; i++) {
                this.Parameters[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
