namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class UseHintList : OptimizerHint {
        public UseHintList() : base() { }
        public UseHintList(ScriptDom.UseHintList src) : base(src) {
            Copier.CopyList(this.Hints, src.Hints);
        }

        public List<StringLiteral> Hints { get; } = new List<StringLiteral>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Hints.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
