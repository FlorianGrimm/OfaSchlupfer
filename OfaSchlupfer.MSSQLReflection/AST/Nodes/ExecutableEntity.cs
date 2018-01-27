#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public abstract class ExecutableEntity : SqlNode {
        public ExecutableEntity() : base() { }
        public ExecutableEntity(ScriptDom.ExecutableEntity src) : base(src) {
            Copier.CopyList(this.Parameters, src.Parameters);
        }
        public List<ExecuteParameter> Parameters { get; } = new List<ExecuteParameter>();
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Parameters.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class ExecuteParameter : SqlNode {
        public ExecuteParameter() : base() { }
        public ExecuteParameter(ScriptDom.ExecuteParameter src) : base(src) {
            this.Variable = Copier.Copy<VariableReference>(src.Variable);
            this.ParameterValue = Copier.Copy<ScalarExpression>(src.ParameterValue);
            this.IsOutput = src.IsOutput;
        }
        public VariableReference Variable;
        public ScalarExpression ParameterValue;
        public bool IsOutput;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Variable?.Accept(visitor);
            this.ParameterValue?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class ExecuteStatement : SqlStatement {
        public ExecuteStatement() : base() { }
        public ExecuteStatement(ScriptDom.ExecuteStatement src) : base(src) {
            this.ExecuteSpecification = Copier.Copy<ExecuteSpecification>(src.ExecuteSpecification);
        }
        public ExecuteSpecification ExecuteSpecification;

        /* public List<ExecuteOption> Options { get; } = new List<ExecuteOption>(); */
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.ExecuteSpecification?.Accept(visitor);
            // this.Options.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
