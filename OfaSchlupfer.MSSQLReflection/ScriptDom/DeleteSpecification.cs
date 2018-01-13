namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DeleteSpecification : UpdateDeleteSpecificationBase {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
