#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class InsertBulkColumnDefinition : SqlNode {
        public InsertBulkColumnDefinition() : base() { }
        public InsertBulkColumnDefinition(ScriptDom.InsertBulkColumnDefinition src) : base(src) {
            this.Column = Copier.Copy<ColumnDefinitionBase>(src.Column);
            this.NullNotNull = src.NullNotNull;
        }
        public ColumnDefinitionBase Column { get; set; }

        public Microsoft.SqlServer.TransactSql.ScriptDom.NullNotNull NullNotNull { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Column?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
