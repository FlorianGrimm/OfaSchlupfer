#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class CursorDefinition : SqlNode {
        public CursorDefinition() : base() { }
        public CursorDefinition(ScriptDom.CursorDefinition src) : base(src) {
            this.Select = Copier.Copy<SelectStatement>(src.Select);
        }

        /*
        public List<CursorOption> Options { get; } = new List<CursorOption>();
         */
        public SelectStatement Select;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            // this.Options.Accept(visitor);
            this.Select?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
