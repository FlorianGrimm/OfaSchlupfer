namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class SelectInsertSource : InsertSource {
        public SelectInsertSource() : base() { }
        public SelectInsertSource(ScriptDom.SelectInsertSource src) : base(src) {
            this.Select = Copier.Copy<QueryExpression>(src.Select);
        }

        public QueryExpression Select { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Select?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
