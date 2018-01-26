namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public abstract class ScalarExpression : SqlNode {
        public ScalarExpression() : base() {
        }
        public ScalarExpression(ScriptDom.ScalarExpression src) : base(src) {
        }
    }

    [System.Serializable]
    public abstract class PrimaryExpression : ScalarExpression, ICollationSetter {
        protected PrimaryExpression() : base() {
        }
        protected PrimaryExpression(ScriptDom.PrimaryExpression src) : base(src) {
            this.Collation = Copier.Copy<Identifier>(src.Collation);
        }
        public Identifier Collation { get; set; }

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Collation?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
    [System.Serializable]
    public abstract class ValueExpression : PrimaryExpression {
        protected ValueExpression() : base() {
        }
        protected ValueExpression(ScriptDom.ValueExpression src) : base(src) {
        }
    }

    [System.Serializable]
    public sealed class VariableReference : ValueExpression {
        public VariableReference() {
        }
        public VariableReference(ScriptDom.VariableReference src) {
            this.Name = src.Name;
        }
        public string Name { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class ColumnReferenceExpression : PrimaryExpression {
        public ColumnReferenceExpression() : base() {
        }
        public ColumnReferenceExpression(ScriptDom.ColumnReferenceExpression src) : base(src) {
            this.ColumnType = src.ColumnType;
            this.MultiPartIdentifier = Copier.Copy<MultiPartIdentifier>(src.MultiPartIdentifier);
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.ColumnType ColumnType { get; set; }

        public MultiPartIdentifier MultiPartIdentifier { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.MultiPartIdentifier?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class BinaryExpression : ScalarExpression {
        public BinaryExpression() : base() { }
        public BinaryExpression(ScriptDom.BinaryExpression src) : base(src) {
            this.BinaryExpressionType = src.BinaryExpressionType;
            this.FirstExpression = Copier.Copy<ScalarExpression>(src.FirstExpression);
            this.SecondExpression = Copier.Copy<ScalarExpression>(src.SecondExpression);
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.BinaryExpressionType BinaryExpressionType { get; set; }

        public ScalarExpression FirstExpression { get; set; }

        public ScalarExpression SecondExpression { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.FirstExpression?.Accept(visitor);
            this.SecondExpression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public sealed class ExtractFromExpression : ScalarExpression {
        public ExtractFromExpression() : base() { }
        public ExtractFromExpression(ScriptDom.ExtractFromExpression src) : base(src) {
            this.Expression = Copier.Copy<ScalarExpression>(src.Expression);
            this.ExtractedElement = Copier.Copy<Identifier>(src.ExtractedElement);
        }

        public ScalarExpression Expression { get; set; }

        public Identifier ExtractedElement { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Expression?.Accept(visitor);
            this.ExtractedElement?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public sealed class GlobalVariableExpression : ValueExpression {
        public GlobalVariableExpression() : base() { }
        public GlobalVariableExpression(ScriptDom.GlobalVariableExpression src) : base(src) {
            this.Name = src.Name;
        }

        public string Name { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}

namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class IIfCall : PrimaryExpression {
        public IIfCall() : base() { }
        public IIfCall(ScriptDom.IIfCall src) : base(src) {
            this.Predicate = Copier.Copy<BooleanExpression>(src.Predicate);
            this.ThenExpression = Copier.Copy<ScalarExpression>(src.ThenExpression);
            this.ElseExpression = Copier.Copy<ScalarExpression>(src.ElseExpression);
        }

        public BooleanExpression Predicate { get; set; }

        public ScalarExpression ThenExpression { get; set; }

        public ScalarExpression ElseExpression { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Predicate?.Accept(visitor);
            this.ThenExpression?.Accept(visitor);
            this.ElseExpression?.Accept(visitor);
        }
    }
}
