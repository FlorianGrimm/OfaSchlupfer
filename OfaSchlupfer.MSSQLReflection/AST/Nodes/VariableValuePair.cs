#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class VariableValuePair : SqlNode {
        public VariableValuePair() : base() { }
        public VariableValuePair(ScriptDom.VariableValuePair src) : base(src) {
            this.Variable = Copier.Copy<VariableReference>(src.Variable);
            this.Value = Copier.Copy<ScalarExpression>(src.Value);
            this.IsForUnknown = src.IsForUnknown;
        }
        public VariableReference Variable { get; set; }

        public ScalarExpression Value { get; set; }

        public bool IsForUnknown { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Variable?.Accept(visitor);
            this.Value?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
