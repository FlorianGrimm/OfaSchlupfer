#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public abstract class SetCommand : SqlNode {
        public SetCommand() : base() { }
        public SetCommand(ScriptDom.SetCommand src) : base(src) { }
    }
}
