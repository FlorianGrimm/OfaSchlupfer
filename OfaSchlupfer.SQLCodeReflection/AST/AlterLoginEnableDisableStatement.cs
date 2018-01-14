namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterLoginEnableDisableStatement : AlterLoginStatement {
        public bool IsEnable { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
