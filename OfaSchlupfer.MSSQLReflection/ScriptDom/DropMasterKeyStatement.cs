namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropMasterKeyStatement : TSqlStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
