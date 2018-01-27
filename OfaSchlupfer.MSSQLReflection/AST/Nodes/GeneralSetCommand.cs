#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class GeneralSetCommand : SetCommand {
        public GeneralSetCommand() : base() { }
        public GeneralSetCommand(ScriptDom.GeneralSetCommand src) : base(src) {
            this.CommandType = src.CommandType;
            this.Parameter = Copier.Copy<ScalarExpression>(src.Parameter);
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.GeneralSetCommandType CommandType;
        public ScalarExpression Parameter;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Parameter?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
