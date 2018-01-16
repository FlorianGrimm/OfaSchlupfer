namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class RowValue : TSqlFragment {
        public List<ScalarExpression> ColumnValues { get; } = new List<ScalarExpression>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.ColumnValues.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
