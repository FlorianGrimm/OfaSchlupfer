namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropSecurityPolicyStatement : DropObjectsStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
