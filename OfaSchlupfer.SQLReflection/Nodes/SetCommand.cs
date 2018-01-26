namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public abstract class SetCommand : SqlNode {

        public SetCommand() : base() { }
        public SetCommand(ScriptDom.SetCommand src) : base(src) {
        }
    }
}
