namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class SetIdentityInsertStatement : SetOnOffStatement {
        public SetIdentityInsertStatement() : base() { }
        public SetIdentityInsertStatement(ScriptDom.SetIdentityInsertStatement src) : base(src) {
            this.Table = Copier.Copy<SchemaObjectName>(src.Table);
        }
        public SchemaObjectName Table { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Table?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
