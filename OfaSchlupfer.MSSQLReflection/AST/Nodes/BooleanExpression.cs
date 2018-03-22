#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public abstract class BooleanExpression : SqlNode {
        public BooleanExpression() : base() { }
        public BooleanExpression(ScriptDom.BooleanExpression src) : base(src) { }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class BooleanExpressionSnippet : BooleanExpression {
        public BooleanExpressionSnippet() : base() { }
        public BooleanExpressionSnippet(ScriptDom.BooleanExpressionSnippet src) : base(src) {
            this.Script = src.Script;
        }
        public string Script;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class BooleanIsNullExpression : BooleanExpression {
        public BooleanIsNullExpression() : base() { }
        public BooleanIsNullExpression(ScriptDom.BooleanIsNullExpression src) : base(src) {
            this.IsNot = src.IsNot;
            this.Expression = Copier.Copy<ScalarExpression>(src.Expression);
        }
        public bool IsNot;
        public ScalarExpression Expression;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Expression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class BooleanNotExpression : BooleanExpression {
        public BooleanNotExpression() : base() { }
        public BooleanNotExpression(ScriptDom.BooleanNotExpression src) : base(src) {
            this.Expression = Copier.Copy<BooleanExpression>(src.Expression);
        }
        public BooleanExpression Expression;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Expression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class BooleanParenthesisExpression : BooleanExpression {
        public BooleanParenthesisExpression() : base() { }
        public BooleanParenthesisExpression(ScriptDom.BooleanParenthesisExpression src) : base(src) {
            this.Expression = Copier.Copy<BooleanExpression>(src.Expression);
        }
        public BooleanExpression Expression;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Expression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class BooleanTernaryExpression : BooleanExpression {
        public BooleanTernaryExpression() : base() { }
        public BooleanTernaryExpression(ScriptDom.BooleanTernaryExpression src) : base(src) {
            this.TernaryExpressionType = src.TernaryExpressionType;
            this.FirstExpression = Copier.Copy<ScalarExpression>(src.FirstExpression);
            this.SecondExpression = Copier.Copy<ScalarExpression>(src.SecondExpression);
            this.ThirdExpression = Copier.Copy<ScalarExpression>(src.ThirdExpression);
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.BooleanTernaryExpressionType TernaryExpressionType;
        public ScalarExpression FirstExpression;
        public ScalarExpression SecondExpression;
        public ScalarExpression ThirdExpression;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.FirstExpression?.Accept(visitor);
            this.SecondExpression?.Accept(visitor);
            this.ThirdExpression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class BooleanComparisonExpression : BooleanExpression {
        public BooleanComparisonExpression() : base() { }
        public BooleanComparisonExpression(ScriptDom.BooleanComparisonExpression src) : base(src) {
            this.ComparisonType = src.ComparisonType;
            this.FirstExpression = Copier.Copy<ScalarExpression>(src.FirstExpression);
            this.SecondExpression = Copier.Copy<ScalarExpression>(src.SecondExpression);
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.BooleanComparisonType ComparisonType;
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
    public sealed class BooleanBinaryExpression : BooleanExpression {
        public BooleanBinaryExpression() : base() { }
        public BooleanBinaryExpression(ScriptDom.BooleanBinaryExpression src) : base(src) {
            this.BinaryExpressionType = src.BinaryExpressionType;
            this.FirstExpression = Copier.Copy<BooleanExpression>(src.FirstExpression);
            this.SecondExpression = Copier.Copy<BooleanExpression>(src.SecondExpression);
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.BooleanBinaryExpressionType BinaryExpressionType;
        public BooleanExpression FirstExpression;
        public BooleanExpression SecondExpression;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.FirstExpression?.Accept(visitor);
            this.SecondExpression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
