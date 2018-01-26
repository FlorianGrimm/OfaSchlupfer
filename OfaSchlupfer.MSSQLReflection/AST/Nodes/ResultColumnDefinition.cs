#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
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
