#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public sealed class VariableMethodCallTableReference : TableReferenceWithAliasAndColumns {
        public VariableMethodCallTableReference() : base() { }
        public VariableMethodCallTableReference(ScriptDom.VariableMethodCallTableReference src) : base(src) {
            this.Variable = Copier.Copy<VariableReference>(src.Variable);
            this.MethodName = Copier.Copy<Identifier>(src.MethodName);
            Copier.CopyList(this.Parameters, src.Parameters);
        }

        public VariableReference Variable { get; set; }

        public Identifier MethodName { get; set; }

        public List<ScalarExpression> Parameters { get; } = new List<ScalarExpression>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Variable?.Accept(visitor);
            this.MethodName?.Accept(visitor);
            this.Parameters.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
