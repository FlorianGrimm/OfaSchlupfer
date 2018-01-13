namespace OfaSchlupfer.ScriptDom {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class ForceSeekTableHint : TableHint {
        private IdentifierOrValueExpression _indexValue;

        public IdentifierOrValueExpression IndexValue {
            get {
                return this._indexValue;
            }

            set {
                this.UpdateTokenInfo(value);
                this._indexValue = value;
            }
        }

        public List<ColumnReferenceExpression> ColumnValues { get; } = new List<ColumnReferenceExpression>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.IndexValue?.Accept(visitor);
            for (int i = 0, count = this.ColumnValues.Count; i < count; i++) {
                this.ColumnValues[i].Accept(visitor);
            }
        }
    }
}
