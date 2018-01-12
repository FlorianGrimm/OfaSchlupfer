namespace OfaSchlupfer.ScriptDom {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class IndexTableHint : TableHint {

        public List<IdentifierOrValueExpression> IndexValues { get; } = new List<IdentifierOrValueExpression>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            var indexValues = this.IndexValues;
            for (int i = 0, count = indexValues.Count; i < count; i++) {
                indexValues[i].Accept(visitor);
            }
        }
    }
}
