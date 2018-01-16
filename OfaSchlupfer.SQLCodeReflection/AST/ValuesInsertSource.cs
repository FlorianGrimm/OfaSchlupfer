namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class ValuesInsertSource : InsertSource {
        public bool IsDefaultValues { get; set; }

        public List<RowValue> RowValues { get; } = new List<RowValue>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.RowValues.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
