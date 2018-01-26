namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public class OptimizerHint : SqlNode {
        public OptimizerHint() : base() { }
        public OptimizerHint(ScriptDom.OptimizerHint src) : base(src) {
            this.HintKind = src.HintKind;
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.OptimizerHintKind HintKind { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
