namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterFullTextCatalogStatement : FullTextCatalogStatement {

        public AlterFullTextCatalogAction Action { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (base.Name != null) {
                base.Name.Accept(visitor);
            }

            var options = base.Options;
            for (int i = 0, count = options.Count; i < count; i++) {
                options[i].Accept(visitor);
            }
        }
    }
}
