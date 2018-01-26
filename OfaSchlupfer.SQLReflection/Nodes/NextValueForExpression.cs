namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class NextValueForExpression : PrimaryExpression {
        public NextValueForExpression() : base() { }
        public NextValueForExpression(ScriptDom.NextValueForExpression src) : base(src) {
            this.SequenceName = Copier.Copy<SchemaObjectName>(src.SequenceName);
            this.OverClause = Copier.Copy<OverClause>(src.OverClause);
        }

        public SchemaObjectName SequenceName { get; set; }

        public OverClause OverClause { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.SequenceName?.Accept(visitor);
            this.OverClause?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
