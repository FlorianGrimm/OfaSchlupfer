namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterTableFileTableNamespaceStatement : AlterTableStatement {
        public bool IsEnable { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (base.SchemaObjectName != null) {
                base.SchemaObjectName.Accept(visitor);
            }
        }
    }
}
