#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public abstract class SetOnOffStatement : SqlStatement {
        public SetOnOffStatement() : base() { }
        public SetOnOffStatement(ScriptDom.SetOnOffStatement src) : base(src) {
            this.IsOn = src.IsOn;
        }
        public bool IsOn { get; set; }
    }
}
