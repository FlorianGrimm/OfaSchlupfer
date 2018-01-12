using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ValuesInsertSource : InsertSource {
        private bool _isDefaultValues;

        private List<RowValue> _rowValues = new List<RowValue>();

        public bool IsDefaultValues {
            get {
                return this._isDefaultValues;
            }
            set {
                this._isDefaultValues = value;
            }
        }

        public List<RowValue> RowValues {
            get {
                return this._rowValues;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i=0, count = this.RowValues.Count; i < count; i++) {
                this.RowValues[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
