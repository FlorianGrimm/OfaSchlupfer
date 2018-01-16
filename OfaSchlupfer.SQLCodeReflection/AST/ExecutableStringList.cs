namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class ExecutableStringList : ExecutableEntity {
        public List<ValueExpression> Strings { get; } = new List<ValueExpression>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Strings.Accept(visitor);
        }
    }
}
