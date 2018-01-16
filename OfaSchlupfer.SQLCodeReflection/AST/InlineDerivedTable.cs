namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class InlineDerivedTable : TableReferenceWithAliasAndColumns {
        public List<RowValue> RowValues { get; } = new List<RowValue>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.RowValues.Accept(visitor);
        }
    }
}
