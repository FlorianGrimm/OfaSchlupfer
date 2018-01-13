namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CreateViewStatement : ViewStatementBody {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
