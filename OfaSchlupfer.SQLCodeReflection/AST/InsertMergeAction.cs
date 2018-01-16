namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class InsertMergeAction : MergeAction {
        private ValuesInsertSource _source;

        public List<ColumnReferenceExpression> Columns { get; } = new List<ColumnReferenceExpression>();

        public ValuesInsertSource Source {
            get {
                return this._source;
            }

            set {
                this.UpdateTokenInfo(value);
                this._source = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Columns.Accept(visitor);
            this.Source?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
