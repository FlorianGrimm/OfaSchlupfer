namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class CursorId : SqlNode {
        public CursorId() : base() { }
        public CursorId(ScriptDom.CursorId src) : base(src) {
            this.Name = Copier.Copy<IdentifierOrValueExpression>(src.Name);
        }

        public bool IsGlobal { get; set; }

        public IdentifierOrValueExpression Name { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
