#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class SetIdentityInsertStatement : SetOnOffStatement {
        public SetIdentityInsertStatement() : base() { }
        public SetIdentityInsertStatement(ScriptDom.SetIdentityInsertStatement src) : base(src) {
            this.Table = Copier.Copy<SchemaObjectName>(src.Table);
        }
        public SchemaObjectName Table { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Table?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
