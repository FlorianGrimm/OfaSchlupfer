#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class DeclareTableVariableStatement : SqlStatement {
        public DeclareTableVariableStatement() : base() { }
        public DeclareTableVariableStatement(ScriptDom.DeclareTableVariableStatement src) : base(src) {
            this.Body = Copier.Copy<DeclareTableVariableBody>(src.Body);
        }
        public DeclareTableVariableBody Body;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Body?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class DeclareTableVariableBody : SqlNode {
        public DeclareTableVariableBody() : base() { }
        public DeclareTableVariableBody(ScriptDom.DeclareTableVariableBody src) : base(src) {
            this.VariableName = Copier.Copy<Identifier>(src.VariableName);
            this.AsDefined = src.AsDefined;
            this.Definition = Copier.Copy<TableDefinition>(src.Definition);
        }
        public Identifier VariableName;
        public bool AsDefined;
        public TableDefinition Definition;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.VariableName?.Accept(visitor);
            this.Definition?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
