namespace OfaSchlupfer.SQLReflection {using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class SetStatisticsStatement : SetOnOffStatement {
        public Microsoft.SqlServer.TransactSql.ScriptDom.SetStatisticsOptions Options { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
