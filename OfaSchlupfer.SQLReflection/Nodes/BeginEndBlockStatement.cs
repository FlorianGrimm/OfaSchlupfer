namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public class BeginEndBlockStatement : SqlStatement {

        public BeginEndBlockStatement() : base() { }
        public BeginEndBlockStatement(ScriptDom.BeginEndBlockStatement src) : base(src) {
            this.StatementList = Copier.Copy<StatementList>(src.StatementList);
        }

        public StatementList StatementList { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.StatementList?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
