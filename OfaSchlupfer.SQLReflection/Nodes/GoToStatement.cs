namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class GoToStatement : SqlStatement {
        public GoToStatement() : base() { }
        public GoToStatement(ScriptDom.GoToStatement src) : base(src) {
            this.LabelName = Copier.Copy<Identifier>(src.LabelName);
        }

        public Identifier LabelName { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.LabelName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}