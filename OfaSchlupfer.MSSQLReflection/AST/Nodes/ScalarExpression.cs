#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
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
    public sealed class ParenthesisExpression : PrimaryExpression {
        public ParenthesisExpression() : base() { }
        public ParenthesisExpression(ScriptDom.ParenthesisExpression src) : base(src) {
            this.Expression = Copier.Copy<ScalarExpression>(src.Expression);
        }
        public ScalarExpression Expression;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Expression?.Accept(visitor);
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

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public abstract class CaseExpression : PrimaryExpression {
        public CaseExpression() : base() { }
        public CaseExpression(ScriptDom.CaseExpression src) : base(src) {
            this.ElseExpression = Copier.Copy<ScalarExpression>(src.ElseExpression);
        }
        public ScalarExpression ElseExpression;
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.ElseExpression?.Accept(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class SimpleCaseExpression : CaseExpression {
        public SimpleCaseExpression() : base() { }
        public SimpleCaseExpression(ScriptDom.SimpleCaseExpression src) : base(src) {
            this.InputExpression = Copier.Copy<ScalarExpression>(src.InputExpression);
            Copier.CopyList(this.WhenClauses, src.WhenClauses);
        }
        public ScalarExpression InputExpression;
        public List<SimpleWhenClause> WhenClauses { get; } = new List<SimpleWhenClause>();
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.InputExpression?.Accept(visitor);
            this.WhenClauses.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class CastCall : PrimaryExpression {
        public CastCall() : base() { }
        public CastCall(ScriptDom.CastCall src) : base(src) {
            this.DataType = Copier.Copy<DataTypeReference>(src.DataType);
            this.Parameter = Copier.Copy<ScalarExpression>(src.Parameter);
        }
        public DataTypeReference DataType;
        public ScalarExpression Parameter;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.DataType?.Accept(visitor);
            this.Parameter?.Accept(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class ParseCall : PrimaryExpression {
        public ParseCall() : base() { }
        public ParseCall(ScriptDom.ParseCall src) : base(src) {
            this.StringValue = Copier.Copy<ScalarExpression>(src.StringValue);
            this.DataType = Copier.Copy<DataTypeReference>(src.DataType);
            this.Culture = Copier.Copy<ScalarExpression>(src.Culture);
        }
        public ScalarExpression StringValue;
        public DataTypeReference DataType;
        public ScalarExpression Culture;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.StringValue?.Accept(visitor);
            this.DataType?.Accept(visitor);
            this.Culture?.Accept(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class TryParseCall : PrimaryExpression {
        public TryParseCall() : base() { }
        public TryParseCall(ScriptDom.TryParseCall src) : base(src) {
            this.StringValue = Copier.Copy<ScalarExpression>(src.StringValue);
            this.DataType = Copier.Copy<DataTypeReference>(src.DataType);
            this.Culture = Copier.Copy<ScalarExpression>(src.Culture);
        }
        public ScalarExpression StringValue;
        public DataTypeReference DataType;
        public ScalarExpression Culture;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.StringValue?.Accept(visitor);
            this.DataType?.Accept(visitor);
            this.Culture?.Accept(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class TryCastCall : PrimaryExpression {
        public TryCastCall() : base() { }
        public TryCastCall(ScriptDom.TryCastCall src) : base(src) {
            this.DataType = Copier.Copy<DataTypeReference>(src.DataType);
            this.Parameter = Copier.Copy<ScalarExpression>(src.Parameter);
        }
        public DataTypeReference DataType;
        public ScalarExpression Parameter;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.DataType?.Accept(visitor);
            this.Parameter?.Accept(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class CoalesceExpression : PrimaryExpression {
        public CoalesceExpression() : base() { }
        public CoalesceExpression(ScriptDom.CoalesceExpression src) : base(src) {
            Copier.CopyList(this.Expressions, src.Expressions);
        }
        public List<ScalarExpression> Expressions { get; } = new List<ScalarExpression>();
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Expressions.Accept(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class ConvertCall : PrimaryExpression {
        public ConvertCall() : base() { }
        public ConvertCall(ScriptDom.ConvertCall src) : base(src) {
            this.DataType = Copier.Copy<DataTypeReference>(src.DataType);
            this.Parameter = Copier.Copy<ScalarExpression>(src.Parameter);
            this.Style = Copier.Copy<ScalarExpression>(src.Style);
        }
        public DataTypeReference DataType;
        public ScalarExpression Parameter;
        public ScalarExpression Style;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.DataType?.Accept(visitor);
            this.Parameter?.Accept(visitor);
            this.Style?.Accept(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class TryConvertCall : PrimaryExpression {
        public TryConvertCall() : base() { }
        public TryConvertCall(ScriptDom.TryConvertCall src) : base(src) {
            this.DataType = Copier.Copy<DataTypeReference>(src.DataType);
            this.Parameter = Copier.Copy<ScalarExpression>(src.Parameter);
            this.Style = Copier.Copy<ScalarExpression>(src.Style);
        }
        public DataTypeReference DataType;
        public ScalarExpression Parameter;
        public ScalarExpression Style;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.DataType?.Accept(visitor);
            this.Parameter?.Accept(visitor);
            this.Style?.Accept(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class ScalarSubquery : PrimaryExpression {
        public ScalarSubquery() : base() { }
        public ScalarSubquery(ScriptDom.ScalarSubquery src) : base(src) {
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
    public sealed class FunctionCall : PrimaryExpression {
        public FunctionCall() : base() { }
        public FunctionCall(ScriptDom.FunctionCall src) : base(src) {
            this.CallTarget = Copier.Copy<CallTarget>(src.CallTarget);
            this.FunctionName = Copier.Copy<Identifier>(src.FunctionName);
            Copier.CopyList(this.Parameters, src.Parameters);
            this.UniqueRowFilter = src.UniqueRowFilter;
            this.OverClause = Copier.Copy<OverClause>(src.OverClause);
            this.WithinGroupClause = Copier.Copy<WithinGroupClause>(src.WithinGroupClause);
        }
        public CallTarget CallTarget;
        public Identifier FunctionName;
        public List<ScalarExpression> Parameters { get; } = new List<ScalarExpression>();
        public Microsoft.SqlServer.TransactSql.ScriptDom.UniqueRowFilter UniqueRowFilter;
        public OverClause OverClause;
        public WithinGroupClause WithinGroupClause;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.CallTarget?.Accept(visitor);
            this.FunctionName?.Accept(visitor);
            this.Parameters.Accept(visitor);
            this.OverClause?.Accept(visitor);
            this.WithinGroupClause?.Accept(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class ParameterlessCall : PrimaryExpression {
        public ParameterlessCall() : base() { }
        public ParameterlessCall(ScriptDom.ParameterlessCall src) : base(src) {
            this.ParameterlessCallType = src.ParameterlessCallType;
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.ParameterlessCallType ParameterlessCallType;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class NullIfExpression : PrimaryExpression {
        public NullIfExpression() : base() { }
        public NullIfExpression(ScriptDom.NullIfExpression src) : base(src) {
            this.FirstExpression = Copier.Copy<ScalarExpression>(src.FirstExpression);
            this.SecondExpression = Copier.Copy<ScalarExpression>(src.SecondExpression);
        }
        public ScalarExpression FirstExpression;
        public ScalarExpression SecondExpression;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.FirstExpression?.Accept(visitor);
            this.SecondExpression?.Accept(visitor);
        }
    }
}
