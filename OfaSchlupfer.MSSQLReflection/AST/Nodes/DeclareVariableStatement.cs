#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

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
