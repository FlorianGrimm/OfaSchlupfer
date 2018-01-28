#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public abstract class SelectElement : SqlNode {
        public SelectElement() : base() { }
        public SelectElement(ScriptDom.SelectElement src) : base(src) { }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class SelectStarExpression : SelectElement {
        public SelectStarExpression() : base() { }
        public SelectStarExpression(ScriptDom.SelectStarExpression src) : base(src) {
            this.Qualifier = Copier.Copy<MultiPartIdentifier>(src.Qualifier);
        }
        public MultiPartIdentifier Qualifier;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Qualifier?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class SelectStatementSnippet : SelectStatement {
        public SelectStatementSnippet() : base() { }
        public SelectStatementSnippet(ScriptDom.SelectStatementSnippet src) : base(src) {
            this.Script = src.Script;
        }
        public string Script;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class SelectSetVariable : SelectElement {
        public SelectSetVariable() : base() { }
        public SelectSetVariable(ScriptDom.SelectSetVariable src) : base(src) {
            this.Variable = Copier.Copy<VariableReference>(src.Variable);
            this.Expression = Copier.Copy<ScalarExpression>(src.Expression);
            this.AssignmentKind = src.AssignmentKind;
        }
        public VariableReference Variable;
        public ScalarExpression Expression;
        public Microsoft.SqlServer.TransactSql.ScriptDom.AssignmentKind AssignmentKind;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Variable?.Accept(visitor);
            this.Expression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class SelectScalarExpression : SelectElement {
        public SelectScalarExpression() : base() { }
        public SelectScalarExpression(ScriptDom.SelectScalarExpression src) : base(src) {
            this.Expression = Copier.Copy<ScalarExpression>(src.Expression);
            this.ColumnName = Copier.Copy<IdentifierOrValueExpression>(src.ColumnName);
        }
        public ScalarExpression Expression;
        public IdentifierOrValueExpression ColumnName;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Expression?.Accept(visitor);
            this.ColumnName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
