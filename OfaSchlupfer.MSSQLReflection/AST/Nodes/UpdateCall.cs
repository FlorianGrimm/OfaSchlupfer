#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class UpdateCall : BooleanExpression {
        public UpdateCall() : base() { }
        public UpdateCall(ScriptDom.UpdateCall src) : base(src) {
            this.Identifier = Copier.Copy<Identifier>(src.Identifier);
        }

        public Identifier Identifier { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Identifier?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
