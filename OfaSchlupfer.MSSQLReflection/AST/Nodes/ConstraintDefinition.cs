#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public abstract class ConstraintDefinition : SqlNode {
        public ConstraintDefinition() : base() { }
        public ConstraintDefinition(ScriptDom.ConstraintDefinition src) : base(src) {
            this.ConstraintIdentifier = Copier.Copy<Identifier>(src.ConstraintIdentifier);
        }

        public Identifier ConstraintIdentifier { get; set; }

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.ConstraintIdentifier?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
