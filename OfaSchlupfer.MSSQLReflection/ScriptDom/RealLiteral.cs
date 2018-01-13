namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class RealLiteral : Literal {
        public override LiteralType LiteralType {
            get {
                return LiteralType.Real;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
