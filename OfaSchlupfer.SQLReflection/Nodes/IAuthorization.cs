namespace OfaSchlupfer.SQLReflection {using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    public interface IAuthorization {
        Identifier Owner {
            get;
            set;
        }
    }
}
