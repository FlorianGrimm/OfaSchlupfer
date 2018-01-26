namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class MultiPartIdentifierCallTarget : CallTarget {
        public MultiPartIdentifierCallTarget() : base() { }
        public MultiPartIdentifierCallTarget(ScriptDom.MultiPartIdentifierCallTarget src) : base(src) {
            this.MultiPartIdentifier = Copier.Copy<MultiPartIdentifier>(src.MultiPartIdentifier);
        }

        public MultiPartIdentifier MultiPartIdentifier { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.MultiPartIdentifier?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
