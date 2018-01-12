namespace OfaSchlupfer.ScriptDom {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class ResultSetsExecuteOption : ExecuteOption {
        public ResultSetsOptionKind ResultSetsOptionKind { get; set; }

        public List<ResultSetDefinition> Definitions { get; } = new List<ResultSetDefinition>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            var definitions = this.Definitions;
            for (int i = 0, count = definitions.Count; i < count; i++) {
                definitions[i].Accept(visitor);
            }
        }
    }
}
