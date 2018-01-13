namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CreateOrAlterViewStatement : ViewStatementBody {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
