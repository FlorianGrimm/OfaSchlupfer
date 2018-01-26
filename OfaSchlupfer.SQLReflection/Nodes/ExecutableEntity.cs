namespace OfaSchlupfer.SQLReflection {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
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
    public sealed class ExecuteParameter : SqlNode {
        public ExecuteParameter() : base() { }
        public ExecuteParameter(ScriptDom.ExecuteParameter src) : base(src) {
            this.Variable = Copier.Copy<VariableReference>(src.Variable);
            this.ParameterValue = Copier.Copy<ScalarExpression>(src.ParameterValue);
            this.IsOutput = src.IsOutput;
        }

        public VariableReference Variable { get; set; }

        public ScalarExpression ParameterValue { get; set; }

        public bool IsOutput { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Variable?.Accept(visitor);
            this.ParameterValue?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public sealed class ExecuteStatement : SqlStatement {
        public ExecuteStatement() : base() { }
        public ExecuteStatement(ScriptDom.ExecuteStatement src) : base(src) {
            this.ExecuteSpecification = Copier.Copy<ExecuteSpecification>(src.ExecuteSpecification);
        }
        public ExecuteSpecification ExecuteSpecification { get; set; }


        // public List<ExecuteOption> Options { get; } = new List<ExecuteOption>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.ExecuteSpecification?.Accept(visitor);
            // this.Options.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
