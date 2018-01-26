namespace OfaSchlupfer.SQLReflection {using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class DropTableStatement : DropObjectsStatement {
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
