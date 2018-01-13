using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class InlineDerivedTable : TableReferenceWithAliasAndColumns {
        private List<RowValue> _rowValues = new List<RowValue>();

        public List<RowValue> RowValues {
            get {
                return this._rowValues;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            for (int i = 0, count = this.RowValues.Count; i < count; i++) {
                this.RowValues[i].Accept(visitor);
            }
        }
    }
}
