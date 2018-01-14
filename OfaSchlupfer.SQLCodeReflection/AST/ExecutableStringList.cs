namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class ExecutableStringList : ExecutableEntity {
        public List<ValueExpression> Strings { get; } = new List<ValueExpression>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            int i = 0;
            for (int count = this.Strings.Count; i < count; i++) {
                this.Strings[i].Accept(visitor);
            }
        }
    }
}
