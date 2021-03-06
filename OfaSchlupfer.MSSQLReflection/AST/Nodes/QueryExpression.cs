#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public abstract class QueryExpression : SqlNode {
        public QueryExpression() : base() { }
        public QueryExpression(ScriptDom.QueryExpression src) : base(src) {
            this.OrderByClause = Copier.Copy<OrderByClause>(src.OrderByClause);
            this.OffsetClause = Copier.Copy<OffsetClause>(src.OffsetClause);
            this.ForClause = Copier.Copy<ForClause>(src.ForClause);
        }
        public OrderByClause OrderByClause;
        public OffsetClause OffsetClause;
        public ForClause ForClause;
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.OrderByClause?.Accept(visitor);
            this.OffsetClause?.Accept(visitor);
            this.ForClause?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class QuerySpecification : QueryExpression {
        public QuerySpecification() : base() { }
        public QuerySpecification(ScriptDom.QuerySpecification src) : base(src) {
            this.UniqueRowFilter = src.UniqueRowFilter;
            this.TopRowFilter = Copier.Copy<TopRowFilter>(src.TopRowFilter);
            Copier.CopyList(this.SelectElements, src.SelectElements);
            this.FromClause = Copier.Copy<FromClause>(src.FromClause);
            this.WhereClause = Copier.Copy<WhereClause>(src.WhereClause);
            this.GroupByClause = Copier.Copy<GroupByClause>(src.GroupByClause);
            this.HavingClause = Copier.Copy<HavingClause>(src.HavingClause);
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.UniqueRowFilter UniqueRowFilter;
        public TopRowFilter TopRowFilter;
        public List<SelectElement> SelectElements { get; } = new List<SelectElement>();
        public FromClause FromClause;
        public WhereClause WhereClause;
        public GroupByClause GroupByClause;
        public HavingClause HavingClause;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.TopRowFilter?.Accept(visitor);
            this.SelectElements.Accept(visitor);
            this.FromClause?.Accept(visitor);
            this.WhereClause?.Accept(visitor);
            this.GroupByClause?.Accept(visitor);
            this.HavingClause?.Accept(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class QueryParenthesisExpression : QueryExpression {
        public QueryParenthesisExpression() : base() { }
        public QueryParenthesisExpression(ScriptDom.QueryParenthesisExpression src) : base(src) {
            this.QueryExpression = Copier.Copy<QueryExpression>(src.QueryExpression);
        }
        public QueryExpression QueryExpression;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.QueryExpression?.Accept(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class BinaryQueryExpression : QueryExpression {
        public BinaryQueryExpression() : base() { }
        public BinaryQueryExpression(ScriptDom.BinaryQueryExpression src) : base(src) {
            this.BinaryQueryExpressionType = src.BinaryQueryExpressionType;
            this.All = src.All;
            this.FirstQueryExpression = Copier.Copy<QueryExpression>(src.FirstQueryExpression);
            this.SecondQueryExpression = Copier.Copy<QueryExpression>(src.SecondQueryExpression);
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.BinaryQueryExpressionType BinaryQueryExpressionType;
        public bool All;
        public QueryExpression FirstQueryExpression;
        public QueryExpression SecondQueryExpression;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.FirstQueryExpression?.Accept(visitor);
            this.SecondQueryExpression?.Accept(visitor);
        }
    }
}