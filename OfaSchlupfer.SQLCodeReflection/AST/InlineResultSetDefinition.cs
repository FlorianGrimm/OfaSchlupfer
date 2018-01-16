namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class InlineResultSetDefinition : ResultSetDefinition {
        public List<ResultColumnDefinition> ResultColumnDefinitions { get; } = new List<ResultColumnDefinition>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.ResultColumnDefinitions.Accept(visitor);
        }
    }
}
