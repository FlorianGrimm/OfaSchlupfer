namespace OfaSchlupfer.SQLReflection {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public abstract class TableReference : SqlNode {
        protected TableReference() : base() {
        }
        protected TableReference(ScriptDom.TableReference src) : base(src) {
        }
    }
    [System.Serializable]
    public sealed class JoinParenthesisTableReference : TableReference {
        public JoinParenthesisTableReference() : base() { }
        public JoinParenthesisTableReference(ScriptDom.JoinParenthesisTableReference src) : base(src) {
            this.Join = Copier.Copy<TableReference>(src.Join);
        }
        public TableReference Join { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Join?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public abstract class TableReferenceWithAlias : TableReference {
        public TableReferenceWithAlias() : base() { }
        public TableReferenceWithAlias(ScriptDom.TableReferenceWithAlias src) : base(src) {
            this.Alias = Copier.Copy<Identifier>(src.Alias);
        }

        public Identifier Alias { get; set; }

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Alias?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public sealed class NamedTableReference : TableReferenceWithAlias {
        public NamedTableReference() : base() { }
        public NamedTableReference(ScriptDom.NamedTableReference src) : base(src) {
            this.SchemaObject = Copier.Copy<SchemaObjectName>(src.SchemaObject);
            // Copier.CopyList(this.TableHints, src.TableHints);
            // this.TableSampleClause = Copier.Copy<TableSampleClause>(src.TableSampleClause);
            // this.TemporalClause = Copier.Copy<TemporalClause>(src.TemporalClause);
        }
        public SchemaObjectName SchemaObject { get; set; }

        // public List<TableHint> TableHints { get; } = new List<TableHint>();
        // public TableSampleClause TableSampleClause { get; set; }
        // public TemporalClause TemporalClause { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.SchemaObject?.Accept(visitor);
            base.AcceptChildren(visitor);
            //this.TableHints.Accept(visitor);
            //this.TableSampleClause?.Accept(visitor);
            //this.TemporalClause?.Accept(visitor);
        }
    }


    [System.Serializable]
    public sealed class UnpivotedTableReference : TableReferenceWithAlias {
        public UnpivotedTableReference() : base() {
        }
        public UnpivotedTableReference(ScriptDom.UnpivotedTableReference src) : base(src) {
            this.TableReference = Copier.Copy<TableReference>(src.TableReference);
            Copier.CopyList(this.InColumns, src.InColumns);
            this.PivotColumn = Copier.Copy<Identifier>(src.PivotColumn);
            this.ValueColumn = Copier.Copy<Identifier>(src.ValueColumn);
        }
        public TableReference TableReference { get; set; }

        public List<ColumnReferenceExpression> InColumns { get; } = new List<ColumnReferenceExpression>();

        public Identifier PivotColumn { get; set; }

        public Identifier ValueColumn { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.TableReference?.Accept(visitor);
            this.InColumns.Accept(visitor);
            this.PivotColumn?.Accept(visitor);
            this.ValueColumn?.Accept(visitor);
        }
    }

    [System.Serializable]
    public abstract class JoinTableReference : TableReference {
        public JoinTableReference() {
        }

        public JoinTableReference(ScriptDom.JoinTableReference src) : base(src) {
            this.FirstTableReference = Copier.Copy<TableReference>(src.FirstTableReference);
            this.SecondTableReference = Copier.Copy<TableReference>(src.SecondTableReference);
        }

        public TableReference FirstTableReference { get; set; }

        public TableReference SecondTableReference { get; set; }

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.FirstTableReference?.Accept(visitor);
            this.SecondTableReference?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
    [System.Serializable]
    public sealed class QualifiedJoin : JoinTableReference {
        public QualifiedJoin() : base() {
        }
        public QualifiedJoin(ScriptDom.QualifiedJoin src) : base(src) {
            this.SearchCondition = Copier.Copy<BooleanExpression>(src.SearchCondition);
            this.QualifiedJoinType = src.QualifiedJoinType;
            this.JoinHint = src.JoinHint;
        }
        public BooleanExpression SearchCondition { get; set; }

        public Microsoft.SqlServer.TransactSql.ScriptDom.QualifiedJoinType QualifiedJoinType { get; set; }

        public Microsoft.SqlServer.TransactSql.ScriptDom.JoinHint JoinHint { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.SearchCondition?.Accept(visitor);
        }
    }
    [System.Serializable]
    public sealed class UnqualifiedJoin : JoinTableReference {
        public UnqualifiedJoin() : base() {
        }
        public UnqualifiedJoin(ScriptDom.UnqualifiedJoin src) : base(src) {
            this.UnqualifiedJoinType = src.UnqualifiedJoinType;
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.UnqualifiedJoinType UnqualifiedJoinType { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }


    [System.Serializable]
    public sealed class VariableTableReference : TableReferenceWithAlias {
        public VariableTableReference() : base() {
        }
        public VariableTableReference(ScriptDom.VariableTableReference src) : base(src) {
            this.Variable = Copier.Copy<VariableReference>(src.Variable);
        }

        public VariableReference Variable { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Variable?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public sealed class GlobalFunctionTableReference : TableReferenceWithAlias {
        public GlobalFunctionTableReference() : base() {
        }
        public GlobalFunctionTableReference(ScriptDom.GlobalFunctionTableReference src) : base(src) {
            this.Name = Copier.Copy<Identifier>(src.Name);
            Copier.CopyList(this.Parameters, src.Parameters);
        }
        public Identifier Name { get; set; }

        public List<ScalarExpression> Parameters { get; } = new List<ScalarExpression>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Name?.Accept(visitor);
            this.Parameters.Accept(visitor);
        }
    }


    [System.Serializable]
    public sealed class OpenJsonTableReference : TableReferenceWithAlias {
        public OpenJsonTableReference() : base() {
        }
        public OpenJsonTableReference(ScriptDom.OpenJsonTableReference src) : base(src) {
            this.Variable = Copier.Copy<ScalarExpression>(src.Variable);
            this.RowPattern = Copier.Copy<StringLiteral>(src.RowPattern);
            Copier.CopyList(this.SchemaDeclarationItems, src.SchemaDeclarationItems);
        }
        public ScalarExpression Variable { get; set; }

        public StringLiteral RowPattern { get; set; }

        public List<SchemaDeclarationItemOpenjson> SchemaDeclarationItems { get; } = new List<SchemaDeclarationItemOpenjson>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Variable?.Accept(visitor);
            this.RowPattern?.Accept(visitor);
            this.SchemaDeclarationItems.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public sealed class BuiltInFunctionTableReference : TableReferenceWithAlias {
        public BuiltInFunctionTableReference() : base() {
        }

        public BuiltInFunctionTableReference(ScriptDom.BuiltInFunctionTableReference src) : base(src) {
            this.Name = Copier.Copy<Identifier>(src.Name);
            Copier.CopyList(this.Parameters, src.Parameters);
        }

        public Identifier Name { get; set; }

        public List<ScalarExpression> Parameters { get; } = new List<ScalarExpression>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Name?.Accept(visitor);
            this.Parameters.Accept(visitor);
        }
    }


    [System.Serializable]
    public sealed class SemanticTableReference : TableReferenceWithAlias {
        public SemanticTableReference() : base() {
        }
        public SemanticTableReference(ScriptDom.SemanticTableReference src) : base(src) {
            this.SemanticFunctionType = src.SemanticFunctionType;
            this.TableName = Copier.Copy<SchemaObjectName>(src.TableName);
            Copier.CopyList(this.Columns, src.Columns);
            this.SourceKey = Copier.Copy<ScalarExpression>(src.SourceKey);
            this.MatchedColumn = Copier.Copy<ColumnReferenceExpression>(src.MatchedColumn);
            this.MatchedKey = Copier.Copy<ScalarExpression>(src.MatchedKey);
        }

        public Microsoft.SqlServer.TransactSql.ScriptDom.SemanticFunctionType SemanticFunctionType { get; set; }

        public SchemaObjectName TableName { get; set; }

        public List<ColumnReferenceExpression> Columns { get; } = new List<ColumnReferenceExpression>();

        public ScalarExpression SourceKey { get; set; }

        public ColumnReferenceExpression MatchedColumn { get; set; }

        public ScalarExpression MatchedKey { get; set; }


        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.TableName?.Accept(visitor);
            this.Columns.Accept(visitor);
            this.SourceKey?.Accept(visitor);
            this.MatchedColumn?.Accept(visitor);
            this.MatchedKey?.Accept(visitor);
        }
    }

    [System.Serializable]
    public abstract class TableReferenceWithAliasAndColumns : TableReferenceWithAlias {
        public TableReferenceWithAliasAndColumns() : base() { }
        public TableReferenceWithAliasAndColumns(ScriptDom.TableReferenceWithAliasAndColumns src) : base(src) {
            Copier.CopyList(this.Columns, src.Columns);
        }
        public List<Identifier> Columns { get; } = new List<Identifier>();

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Columns.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class QueryDerivedTable : TableReferenceWithAliasAndColumns {
        public QueryDerivedTable() : base() { }
        public QueryDerivedTable(ScriptDom.QueryDerivedTable src) : base(src) {
            this.QueryExpression = Copier.Copy<QueryExpression>(src.QueryExpression);
        }

        public QueryExpression QueryExpression { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.QueryExpression?.Accept(visitor);
        }
    }

    [System.Serializable]
    public sealed class DataModificationTableReference : TableReferenceWithAliasAndColumns {
        public DataModificationTableReference() : base() { }
        public DataModificationTableReference(ScriptDom.DataModificationTableReference src) : base(src) {
            this.DataModificationSpecification = Copier.Copy<DataModificationSpecification>(src.DataModificationSpecification);
        }

        public DataModificationSpecification DataModificationSpecification { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.DataModificationSpecification?.Accept(visitor);
        }
    }
}
