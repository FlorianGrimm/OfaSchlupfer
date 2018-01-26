namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public class LiteralRange : SqlNode {
        public LiteralRange() : base() { }
        public LiteralRange(ScriptDom.LiteralRange src) : base(src) {
            this.From = Copier.Copy<Literal>(src.From);
            this.To = Copier.Copy<Literal>(src.To);
        }

        public Literal From { get; set; }

        public Literal To { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.From?.Accept(visitor);
            this.To?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
