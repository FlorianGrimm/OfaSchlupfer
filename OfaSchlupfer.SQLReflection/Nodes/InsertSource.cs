namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public abstract class InsertSource : SqlNode {
        public InsertSource() : base() { }
        public InsertSource(ScriptDom.InsertSource src) : base(src) { }
    }
}
