namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterEndpointStatement : AlterCreateEndpointStatementBase {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
