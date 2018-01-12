namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CreateExternalResourcePoolStatement : ExternalResourcePoolStatement {
        public override void Accept(TSqlFragmentVisitor visitor) {
            visitor?.ExplicitVisit(this);
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
        }
    }
}
