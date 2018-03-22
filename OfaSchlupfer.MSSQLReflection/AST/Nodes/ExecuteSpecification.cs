#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class ExecuteSpecification : SqlNode {
        public ExecuteSpecification() : base() { }
        public ExecuteSpecification(ScriptDom.ExecuteSpecification src) : base(src) {
            this.Variable = Copier.Copy<VariableReference>(src.Variable);
            this.LinkedServer = Copier.Copy<Identifier>(src.LinkedServer);
            this.ExecuteContext = Copier.Copy<ExecuteContext>(src.ExecuteContext);
            this.ExecutableEntity = Copier.Copy<ExecutableEntity>(src.ExecutableEntity);
        }
        public VariableReference Variable;
        public Identifier LinkedServer;
        public ExecuteContext ExecuteContext;
        public ExecutableEntity ExecutableEntity;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Variable?.Accept(visitor);
            this.LinkedServer?.Accept(visitor);
            this.ExecuteContext?.Accept(visitor);
            this.ExecutableEntity?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class ExecuteInsertSource : InsertSource {
        public ExecuteInsertSource() : base() { }
        public ExecuteInsertSource(ScriptDom.ExecuteInsertSource src) : base(src) {
            this.Execute = Copier.Copy<ExecuteSpecification>(src.Execute);
        }
        public ExecuteSpecification Execute;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Execute?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class ExecuteContext : SqlNode {
        public ExecuteContext() : base() { }
        public ExecuteContext(ScriptDom.ExecuteContext src) : base(src) {
            this.Principal = Copier.Copy<ScalarExpression>(src.Principal);
            this.Kind = src.Kind;
        }
        public ScalarExpression Principal;
        public Microsoft.SqlServer.TransactSql.ScriptDom.ExecuteAsOption Kind;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Principal?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
