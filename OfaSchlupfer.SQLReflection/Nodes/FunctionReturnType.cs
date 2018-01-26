namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public abstract class FunctionReturnType : SqlNode {
        public FunctionReturnType() : base() { }
        public FunctionReturnType(ScriptDom.FunctionReturnType src) : base(src) {
        }
    }
}
