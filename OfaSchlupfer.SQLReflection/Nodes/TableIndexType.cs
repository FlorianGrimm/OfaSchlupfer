namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public abstract class TableIndexType : SqlNode {

        public TableIndexType() : base() { }
        public TableIndexType(ScriptDom.TableIndexType src) : base(src) { }
    }
}
