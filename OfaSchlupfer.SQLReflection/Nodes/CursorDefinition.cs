namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class CursorDefinition : SqlNode {
        public CursorDefinition() : base() { }
        public CursorDefinition(ScriptDom.CursorDefinition src) : base(src) {
            this.Select = Copier.Copy<SelectStatement>(src.Select);
        }
        //public List<CursorOption> Options { get; } = new List<CursorOption>();

        public SelectStatement Select { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            // this.Options.Accept(visitor);
            this.Select?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
