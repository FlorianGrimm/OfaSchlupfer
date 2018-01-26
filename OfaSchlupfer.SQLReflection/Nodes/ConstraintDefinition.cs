namespace OfaSchlupfer.SQLReflection {
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
