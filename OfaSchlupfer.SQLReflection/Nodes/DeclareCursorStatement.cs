namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class DeclareCursorStatement : SqlStatement {
        public DeclareCursorStatement() : base() { }
        public DeclareCursorStatement(ScriptDom.DeclareCursorStatement src) : base(src) {
            this.Name = Copier.Copy<Identifier>(src.Name);
            this.CursorDefinition = Copier.Copy<CursorDefinition>(src.CursorDefinition);
        }

        public Identifier Name { get; set; }

        public CursorDefinition CursorDefinition { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.CursorDefinition?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
