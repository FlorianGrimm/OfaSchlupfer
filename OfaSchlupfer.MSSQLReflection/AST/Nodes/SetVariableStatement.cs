#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class SetVariableStatement : SqlStatement {
        public SetVariableStatement() : base() { }
        public SetVariableStatement(ScriptDom.SetVariableStatement src) : base(src) {
            this.Variable = Copier.Copy<VariableReference>(src.Variable);
            this.SeparatorType = src.SeparatorType;
            this.Identifier = Copier.Copy<Identifier>(src.Identifier);
            this.FunctionCallExists = src.FunctionCallExists;
            Copier.CopyList(this.Parameters, src.Parameters);
            this.Expression = Copier.Copy<ScalarExpression>(src.Expression);
            this.CursorDefinition = Copier.Copy<CursorDefinition>(src.CursorDefinition);
            this.AssignmentKind = src.AssignmentKind;
        }
        public VariableReference Variable;
        public Microsoft.SqlServer.TransactSql.ScriptDom.SeparatorType SeparatorType;
        public Identifier Identifier;
        public bool FunctionCallExists;
        public List<ScalarExpression> Parameters { get; } = new List<ScalarExpression>();
        public ScalarExpression Expression;
        public CursorDefinition CursorDefinition;
        public Microsoft.SqlServer.TransactSql.ScriptDom.AssignmentKind AssignmentKind;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Variable?.Accept(visitor);
            this.Identifier?.Accept(visitor);
            this.Parameters.Accept(visitor);
            this.Expression?.Accept(visitor);
            this.CursorDefinition?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
