namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public abstract class SetOnOffStatement : SqlStatement {
        public SetOnOffStatement() : base() { }
        public SetOnOffStatement(ScriptDom.SetOnOffStatement src) : base(src) {
            this.IsOn = src.IsOn;
        }
        public bool IsOn { get; set; }
    }
}
