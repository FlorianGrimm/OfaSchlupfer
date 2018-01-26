namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public abstract class SelectElement : SqlNode {
        public SelectElement() : base() {

        }
        public SelectElement(ScriptDom.SelectElement src) : base(src) {

        }
    }
    [System.Serializable]
    public sealed class SelectStarExpression : SelectElement {
        public SelectStarExpression() : base() { }
        public SelectStarExpression(ScriptDom.SelectStarExpression src) : base(src) {
            this.Qualifier = Copier.Copy<MultiPartIdentifier>(src.Qualifier);
        }

        public MultiPartIdentifier Qualifier { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Qualifier?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

}
