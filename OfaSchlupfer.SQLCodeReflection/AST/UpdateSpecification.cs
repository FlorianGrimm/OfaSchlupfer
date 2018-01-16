namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class UpdateSpecification : UpdateDeleteSpecificationBase {
        public List<SetClause> SetClauses { get; } = new List<SetClause>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.SetClauses.Accept(visitor);
        }
    }
}
