#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public abstract class ScalarExpression : SqlNode {
        public ScalarExpression() : base() { }
        public ScalarExpression(ScriptDom.ScalarExpression src) : base(src) { }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public abstract class PrimaryExpression : ScalarExpression {
        protected PrimaryExpression() : base() { }
        protected PrimaryExpression(ScriptDom.PrimaryExpression src) : base(src) {
            this.Collation = Copier.Copy<Identifier>(src.Collation);
        }
        public Identifier Collation;
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Collation?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public abstract class ValueExpression : PrimaryExpression {
        protected ValueExpression() : base() { }
        protected ValueExpression(ScriptDom.ValueExpression src) : base(src) { }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class VariableReference : ValueExpression {
        public VariableReference() { }
        public VariableReference(ScriptDom.VariableReference src) {
            this.Name = src.Name;
        }
        public string Name;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class ColumnReferenceExpression : PrimaryExpression {
        public ColumnReferenceExpression() : base() { }
        public ColumnReferenceExpression(ScriptDom.ColumnReferenceExpression src) : base(src) {
            this.ColumnType = src.ColumnType;
            this.MultiPartIdentifier = Copier.Copy<MultiPartIdentifier>(src.MultiPartIdentifier);
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.ColumnType ColumnType;
        public MultiPartIdentifier MultiPartIdentifier;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.MultiPartIdentifier?.Accept(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class BinaryExpression : ScalarExpression {
        public BinaryExpression() : base() { }
        public BinaryExpression(ScriptDom.BinaryExpression src) : base(src) {
            this.BinaryExpressionType = src.BinaryExpressionType;
            this.FirstExpression = Copier.Copy<ScalarExpression>(src.FirstExpression);
            this.SecondExpression = Copier.Copy<ScalarExpression>(src.SecondExpression);
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.BinaryExpressionType BinaryExpressionType;
        public ScalarExpression FirstExpression;
        public ScalarExpression SecondExpression;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.FirstExpression?.Accept(visitor);
            this.SecondExpression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class ExtractFromExpression : ScalarExpression {
        public ExtractFromExpression() : base() { }
        public ExtractFromExpression(ScriptDom.ExtractFromExpression src) : base(src) {
            this.Expression = Copier.Copy<ScalarExpression>(src.Expression);
            this.ExtractedElement = Copier.Copy<Identifier>(src.ExtractedElement);
        }
        public ScalarExpression Expression;
        public Identifier ExtractedElement;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Expression?.Accept(visitor);
            this.ExtractedElement?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class GlobalVariableExpression : ValueExpression {
        public GlobalVariableExpression() : base() { }
        public GlobalVariableExpression(ScriptDom.GlobalVariableExpression src) : base(src) {
            this.Name = src.Name;
        }
        public string Name;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class IIfCall : PrimaryExpression {
        public IIfCall() : base() { }
        public IIfCall(ScriptDom.IIfCall src) : base(src) {
            this.Predicate = Copier.Copy<BooleanExpression>(src.Predicate);
            this.ThenExpression = Copier.Copy<ScalarExpression>(src.ThenExpression);
            this.ElseExpression = Copier.Copy<ScalarExpression>(src.ElseExpression);
        }
        public BooleanExpression Predicate;
        public ScalarExpression ThenExpression;
        public ScalarExpression ElseExpression;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Predicate?.Accept(visitor);
            this.ThenExpression?.Accept(visitor);
            this.ElseExpression?.Accept(visitor);
        }
    }
}
