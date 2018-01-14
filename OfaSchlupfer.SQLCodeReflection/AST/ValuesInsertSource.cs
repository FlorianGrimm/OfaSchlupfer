namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class ValuesInsertSource : InsertSource {
        private List<RowValue> _rowValues = new List<RowValue>();

        public bool IsDefaultValues { get; set; }

        public List<RowValue> RowValues {
            get {
                return this._rowValues;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i = 0, count = this.RowValues.Count; i < count; i++) {
                this.RowValues[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
