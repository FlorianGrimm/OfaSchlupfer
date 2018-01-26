namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class UpdateCall : BooleanExpression {
        public UpdateCall() : base() { }
        public UpdateCall(ScriptDom.UpdateCall src) : base(src) {
            this.Identifier = Copier.Copy<Identifier>(src.Identifier);
        }

        public Identifier Identifier { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Identifier?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
