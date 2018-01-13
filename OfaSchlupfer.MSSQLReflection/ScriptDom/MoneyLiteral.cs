namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class MoneyLiteral : Literal {
        public override LiteralType LiteralType {
            get {
                return LiteralType.Money;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
