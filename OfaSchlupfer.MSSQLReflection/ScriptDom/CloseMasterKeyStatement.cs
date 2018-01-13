namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CloseMasterKeyStatement : TSqlStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
