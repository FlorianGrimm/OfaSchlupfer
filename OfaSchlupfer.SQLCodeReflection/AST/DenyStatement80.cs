namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class DenyStatement80 : SecurityStatementBody80 {

        public bool CascadeOption { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
