namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public class ResultSetDefinition : SqlNode {
        public ResultSetDefinition() : base() { }
        public ResultSetDefinition(ScriptDom.ResultSetDefinition src) : base(src) {
            this.ResultSetType = src.ResultSetType;
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.ResultSetType ResultSetType { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
