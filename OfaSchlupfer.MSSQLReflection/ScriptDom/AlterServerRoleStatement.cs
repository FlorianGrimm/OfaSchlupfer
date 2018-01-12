namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterServerRoleStatement : AlterRoleStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
