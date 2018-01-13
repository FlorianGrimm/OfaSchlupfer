namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterRemoteServiceBindingStatement : RemoteServiceBindingStatementBase {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
