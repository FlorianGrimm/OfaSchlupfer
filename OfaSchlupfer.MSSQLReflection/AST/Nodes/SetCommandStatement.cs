#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class SetCommandStatement : SqlStatement {
        public SetCommandStatement() : base() { }
        public SetCommandStatement(ScriptDom.SetCommandStatement src) : base(src) {
            Copier.CopyList(this.Commands, src.Commands);
        }
        public List<SetCommand> Commands { get; } = new List<SetCommand>();
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Commands.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
