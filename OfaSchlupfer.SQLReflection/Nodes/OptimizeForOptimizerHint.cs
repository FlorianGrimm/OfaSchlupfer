namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class OptimizeForOptimizerHint : OptimizerHint {
        public OptimizeForOptimizerHint() : base() { }
        public OptimizeForOptimizerHint(ScriptDom.OptimizeForOptimizerHint src) : base(src) {
            Copier.CopyList(this.Pairs, src.Pairs);
            this.IsForUnknown = src.IsForUnknown;
        }
        public List<VariableValuePair> Pairs { get; } = new List<VariableValuePair>();

        public bool IsForUnknown { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Pairs.Accept(visitor);
        }
    }
}
