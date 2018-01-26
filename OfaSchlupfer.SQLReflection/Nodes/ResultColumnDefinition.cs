namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class ResultColumnDefinition : SqlNode {
        public ResultColumnDefinition() : base() { }
        public ResultColumnDefinition(ScriptDom.ResultColumnDefinition src) : base(src) {
            this.ColumnDefinition = Copier.Copy<ColumnDefinitionBase>(src.ColumnDefinition);
            this.Nullable = Copier.Copy<NullableConstraintDefinition>(src.Nullable);
        }

        public ColumnDefinitionBase ColumnDefinition { get; set; }

        public NullableConstraintDefinition Nullable { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.ColumnDefinition?.Accept(visitor);
            this.Nullable?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
