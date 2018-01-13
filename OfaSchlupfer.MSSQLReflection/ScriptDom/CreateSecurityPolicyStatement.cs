namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CreateSecurityPolicyStatement : SecurityPolicyStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
