namespace OfaSchlupfer.SQLReflection {using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    internal interface ICollationSetter {
        Identifier Collation {
            get;
            set;
        }
    }
}
