#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class ExecutableStringList : ExecutableEntity {
        public ExecutableStringList() : base() { }
        public ExecutableStringList(ScriptDom.ExecutableStringList src) : base(src) {
            Copier.CopyList(this.Strings, src.Strings);
        }
        public List<ValueExpression> Strings { get; } = new List<ValueExpression>();
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Strings.Accept(visitor);
        }
    }
}
