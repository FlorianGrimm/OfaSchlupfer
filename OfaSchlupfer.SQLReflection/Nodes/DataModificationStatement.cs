namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public abstract class DataModificationStatement : StatementWithCtesAndXmlNamespaces {
        public DataModificationStatement() : base() { }
        public DataModificationStatement(ScriptDom.DataModificationStatement src) : base(src) {
        }
    }
}
