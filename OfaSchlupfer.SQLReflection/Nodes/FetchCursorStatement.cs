namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class FetchCursorStatement : CursorStatement {
        public FetchCursorStatement() : base() { }
        public FetchCursorStatement(ScriptDom.FetchCursorStatement src) : base(src) {
            this.FetchType = Copier.Copy<FetchType>(src.FetchType);
            Copier.CopyList(this.IntoVariables, src.IntoVariables);
        }
        public FetchType FetchType { get; set; }

        public List<VariableReference> IntoVariables { get; } = new List<VariableReference>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.FetchType?.Accept(visitor);
            this.IntoVariables.Accept(visitor);
        }
    }
}
