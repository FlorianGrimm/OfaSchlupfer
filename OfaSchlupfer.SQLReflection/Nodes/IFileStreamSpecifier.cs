namespace OfaSchlupfer.SQLReflection {using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    internal interface IFileStreamSpecifier {
        IdentifierOrValueExpression FileStreamOn {
            get;
            set;
        }
    }
}
