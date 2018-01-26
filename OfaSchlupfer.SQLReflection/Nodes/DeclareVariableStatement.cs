namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class DeclareVariableStatement : SqlStatement {
        public DeclareVariableStatement() : base() { }
        public DeclareVariableStatement(ScriptDom.DeclareVariableStatement src) : base(src) {
            Copier.CopyList(this.Declarations, src.Declarations);
        }
        public List<DeclareVariableElement> Declarations { get; } = new List<DeclareVariableElement>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Declarations.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
