#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class UseHintList : OptimizerHint {
        public UseHintList() : base() { }
        public UseHintList(ScriptDom.UseHintList src) : base(src) {
            Copier.CopyList(this.Hints, src.Hints);
        }
        public List<StringLiteral> Hints { get; } = new List<StringLiteral>();
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Hints.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
