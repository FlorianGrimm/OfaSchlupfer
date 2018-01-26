namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class NullableConstraintDefinition : ConstraintDefinition {
        public NullableConstraintDefinition() : base() { }
        public NullableConstraintDefinition(ScriptDom.NullableConstraintDefinition src) : base(src) {
            this.Nullable = src.Nullable;
        }
        public bool Nullable { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
