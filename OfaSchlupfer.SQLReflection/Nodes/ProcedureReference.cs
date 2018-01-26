namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class ProcedureReference : SqlNode {
        public ProcedureReference() : base() { }
        public ProcedureReference(ScriptDom.ProcedureReference src) : base(src) {
            this.Name = Copier.Copy<SchemaObjectName>(src.Name);
            this.Number = Copier.Copy<Literal>(src.Number);
        }

        public SchemaObjectName Name { get; set; }
        public Literal Number { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.Number?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
