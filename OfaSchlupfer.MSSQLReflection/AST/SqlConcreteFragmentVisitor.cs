#pragma warning disable SA1516
#pragma warning disable SA1600

#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    public abstract class SqlConcreteFragmentVisitor : SqlFragmentVisitor {
        protected SqlConcreteFragmentVisitor()
            : base(false) { }
        public sealed override void Visit(ExecutableEntity node) { base.Visit(node); }
        public sealed override void ExplicitVisit(ExecutableEntity node) { base.ExplicitVisit(node); }
        public sealed override void Visit(ViewStatementBody node) { base.Visit(node); }
        public sealed override void ExplicitVisit(ViewStatementBody node) { base.ExplicitVisit(node); }
        public sealed override void Visit(ProcedureStatementBody node) { base.Visit(node); }
        public sealed override void ExplicitVisit(ProcedureStatementBody node) { base.ExplicitVisit(node); }
        public sealed override void Visit(ProcedureStatementBodyBase node) { base.Visit(node); }
        public sealed override void ExplicitVisit(ProcedureStatementBodyBase node) { base.ExplicitVisit(node); }
        public sealed override void Visit(FunctionStatementBody node) { base.Visit(node); }
        public sealed override void ExplicitVisit(FunctionStatementBody node) { base.ExplicitVisit(node); }
        public sealed override void Visit(XmlNamespacesElement node) { base.Visit(node); }
        public sealed override void ExplicitVisit(XmlNamespacesElement node) { base.ExplicitVisit(node); }
        public sealed override void Visit(FunctionReturnType node) { base.Visit(node); }
        public sealed override void ExplicitVisit(FunctionReturnType node) { base.ExplicitVisit(node); }
        public sealed override void Visit(DataTypeReference node) { base.Visit(node); }
        public sealed override void ExplicitVisit(DataTypeReference node) { base.ExplicitVisit(node); }
        public sealed override void Visit(ParameterizedDataTypeReference node) { base.Visit(node); }
        public sealed override void ExplicitVisit(ParameterizedDataTypeReference node) { base.ExplicitVisit(node); }
        public sealed override void Visit(StatementWithCtesAndXmlNamespaces node) { base.Visit(node); }
        public sealed override void ExplicitVisit(StatementWithCtesAndXmlNamespaces node) { base.ExplicitVisit(node); }
        public sealed override void Visit(ForClause node) { base.Visit(node); }
        public sealed override void ExplicitVisit(ForClause node) { base.ExplicitVisit(node); }
        public sealed override void Visit(WhenClause node) { base.Visit(node); }
        public sealed override void ExplicitVisit(WhenClause node) { base.ExplicitVisit(node); }
        public sealed override void Visit(CaseExpression node) { base.Visit(node); }
        public sealed override void ExplicitVisit(CaseExpression node) { base.ExplicitVisit(node); }
        public sealed override void Visit(CallTarget node) { base.Visit(node); }
        public sealed override void ExplicitVisit(CallTarget node) { base.ExplicitVisit(node); }
        public sealed override void Visit(TransactionStatement node) { base.Visit(node); }
        public sealed override void ExplicitVisit(TransactionStatement node) { base.ExplicitVisit(node); }
        public sealed override void Visit(UpdateDeleteSpecificationBase node) { base.Visit(node); }
        public sealed override void ExplicitVisit(UpdateDeleteSpecificationBase node) { base.ExplicitVisit(node); }
        public sealed override void Visit(TextModificationStatement node) { base.Visit(node); }
        public sealed override void ExplicitVisit(TextModificationStatement node) { base.ExplicitVisit(node); }
        public sealed override void Visit(SetClause node) { base.Visit(node); }
        public sealed override void ExplicitVisit(SetClause node) { base.ExplicitVisit(node); }
        public sealed override void Visit(InsertSource node) { base.Visit(node); }
        public sealed override void ExplicitVisit(InsertSource node) { base.ExplicitVisit(node); }
        public sealed override void Visit(PrimaryExpression node) { base.Visit(node); }
        public sealed override void ExplicitVisit(PrimaryExpression node) { base.ExplicitVisit(node); }
        public sealed override void Visit(Literal node) { base.Visit(node); }
        public sealed override void ExplicitVisit(Literal node) { base.ExplicitVisit(node); }
        public sealed override void Visit(ValueExpression node) { base.Visit(node); }
        public sealed override void ExplicitVisit(ValueExpression node) { base.ExplicitVisit(node); }
        public sealed override void Visit(OptionValue node) { base.Visit(node); }
        public sealed override void ExplicitVisit(OptionValue node) { base.ExplicitVisit(node); }
        public sealed override void Visit(CursorStatement node) { base.Visit(node); }
        public sealed override void ExplicitVisit(CursorStatement node) { base.ExplicitVisit(node); }
        public sealed override void Visit(DropIndexClauseBase node) { base.Visit(node); }
        public sealed override void ExplicitVisit(DropIndexClauseBase node) { base.ExplicitVisit(node); }
        public sealed override void Visit(SetOnOffStatement node) { base.Visit(node); }
        public sealed override void ExplicitVisit(SetOnOffStatement node) { base.ExplicitVisit(node); }
        public sealed override void Visit(SetCommand node) { base.Visit(node); }
        public sealed override void ExplicitVisit(SetCommand node) { base.ExplicitVisit(node); }
        public sealed override void Visit(ConstraintDefinition node) { base.Visit(node); }
        public sealed override void ExplicitVisit(ConstraintDefinition node) { base.ExplicitVisit(node); }
        public sealed override void Visit(TableDistributionPolicy node) { base.Visit(node); }
        public sealed override void ExplicitVisit(TableDistributionPolicy node) { base.ExplicitVisit(node); }
        public sealed override void Visit(TableIndexType node) { base.Visit(node); }
        public sealed override void ExplicitVisit(TableIndexType node) { base.ExplicitVisit(node); }
        public sealed override void Visit(ScalarExpression node) { base.Visit(node); }
        public sealed override void ExplicitVisit(ScalarExpression node) { base.ExplicitVisit(node); }
        public sealed override void Visit(BooleanExpression node) { base.Visit(node); }
        public sealed override void ExplicitVisit(BooleanExpression node) { base.ExplicitVisit(node); }
        public sealed override void Visit(GroupingSpecification node) { base.Visit(node); }
        public sealed override void ExplicitVisit(GroupingSpecification node) { base.ExplicitVisit(node); }
        public sealed override void Visit(JoinTableReference node) { base.Visit(node); }
        public sealed override void ExplicitVisit(JoinTableReference node) { base.ExplicitVisit(node); }
        public sealed override void Visit(QueryExpression node) { base.Visit(node); }
        public sealed override void ExplicitVisit(QueryExpression node) { base.ExplicitVisit(node); }
        public sealed override void Visit(SelectElement node) { base.Visit(node); }
        public sealed override void ExplicitVisit(SelectElement node) { base.ExplicitVisit(node); }
        public sealed override void Visit(TableReference node) { base.Visit(node); }
        public sealed override void ExplicitVisit(TableReference node) { base.ExplicitVisit(node); }
        public sealed override void Visit(TableReferenceWithAlias node) { base.Visit(node); }
        public sealed override void ExplicitVisit(TableReferenceWithAlias node) { base.ExplicitVisit(node); }
        public sealed override void Visit(TableReferenceWithAliasAndColumns node) { base.Visit(node); }
        public sealed override void ExplicitVisit(TableReferenceWithAliasAndColumns node) { base.ExplicitVisit(node); }
        public sealed override void Visit(WaitForSupportedStatement node) { base.Visit(node); }
        public sealed override void ExplicitVisit(WaitForSupportedStatement node) { base.ExplicitVisit(node); }
        public sealed override void Visit(SqlStatement node) { base.Visit(node); }
        public sealed override void ExplicitVisit(SqlStatement node) { base.ExplicitVisit(node); }
        public sealed override void Visit(DataModificationStatement node) { base.Visit(node); }
        public sealed override void ExplicitVisit(DataModificationStatement node) { base.ExplicitVisit(node); }
        public sealed override void Visit(DataModificationSpecification node) { base.Visit(node); }
        public sealed override void ExplicitVisit(DataModificationSpecification node) { base.ExplicitVisit(node); }
        public sealed override void Visit(MergeAction node) { base.Visit(node); }
        public sealed override void ExplicitVisit(MergeAction node) { base.ExplicitVisit(node); }
    }
}
