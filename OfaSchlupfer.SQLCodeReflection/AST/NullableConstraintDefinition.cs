namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class NullableConstraintDefinition : ConstraintDefinition {
        public bool Nullable { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
