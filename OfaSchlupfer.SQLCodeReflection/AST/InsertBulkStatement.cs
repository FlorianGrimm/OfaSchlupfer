namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class InsertBulkStatement : BulkInsertBase {
        public List<InsertBulkColumnDefinition> ColumnDefinitions { get; } = new List<InsertBulkColumnDefinition>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.ColumnDefinitions.Accept(visitor);
        }
    }
}
