namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public abstract class CallTarget : SqlNode {
        public CallTarget() : base() { }
        public CallTarget(ScriptDom.CallTarget src) : base(src) { }
    }
}
