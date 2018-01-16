namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterFullTextCatalogStatement : FullTextCatalogStatement {

        public AlterFullTextCatalogAction Action { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.Options.Accept(visitor);
        }
    }
}
