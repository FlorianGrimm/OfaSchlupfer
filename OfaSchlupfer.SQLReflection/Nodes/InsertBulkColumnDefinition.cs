namespace OfaSchlupfer.SQLReflection {using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class InsertBulkColumnDefinition : SqlNode {
        public ColumnDefinitionBase Column { get; set; }

        public Microsoft.SqlServer.TransactSql.ScriptDom.NullNotNull NullNotNull { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Column?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
