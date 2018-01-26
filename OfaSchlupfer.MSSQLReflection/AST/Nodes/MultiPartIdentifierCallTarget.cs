#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
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
