namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class TableReferenceWithAliasAndColumns : TableReferenceWithAlias {
        public List<Identifier> Columns { get; } = new List<Identifier>();

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Columns.Accept(visitor);
        }
    }
}
