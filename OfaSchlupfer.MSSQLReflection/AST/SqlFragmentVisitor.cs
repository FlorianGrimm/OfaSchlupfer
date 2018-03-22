#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    /// <summary>
    /// Visitor
    /// </summary>
    public abstract class SqlFragmentVisitor {
        private readonly bool _visitBaseType;

        protected SqlFragmentVisitor()
            : this(true) { }

        internal SqlFragmentVisitor(bool visitBaseType) {
            this._visitBaseType = visitBaseType;
        }

        public virtual void Start<T>(T node)
            where T : SqlNode { }

        public virtual void Done<T>(T node)
            where T : SqlNode { }

        public virtual void Visit(SqlNode fragment) { }

        public virtual void Visit(StatementList node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(StatementList node) {
            this.Start<StatementList>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<StatementList>(node);
        }
        public virtual void Visit(ExecuteStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ExecuteStatement node) {
            this.Start<ExecuteStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ExecuteStatement>(node);
        }
        public virtual void Visit(ResultSetDefinition node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ResultSetDefinition node) {
            this.Start<ResultSetDefinition>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ResultSetDefinition>(node);
        }
        public virtual void Visit(InlineResultSetDefinition node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(InlineResultSetDefinition node) {
            this.Start<InlineResultSetDefinition>(node); if (this._visitBaseType) { this.Visit((ResultSetDefinition)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<InlineResultSetDefinition>(node);
        }
        public virtual void Visit(ResultColumnDefinition node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ResultColumnDefinition node) {
            this.Start<ResultColumnDefinition>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ResultColumnDefinition>(node);
        }
        public virtual void Visit(SchemaObjectResultSetDefinition node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SchemaObjectResultSetDefinition node) {
            this.Start<SchemaObjectResultSetDefinition>(node); if (this._visitBaseType) { this.Visit((ResultSetDefinition)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SchemaObjectResultSetDefinition>(node);
        }
        public virtual void Visit(ExecuteSpecification node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ExecuteSpecification node) {
            this.Start<ExecuteSpecification>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ExecuteSpecification>(node);
        }
        public virtual void Visit(ExecuteContext node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ExecuteContext node) {
            this.Start<ExecuteContext>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ExecuteContext>(node);
        }
        public virtual void Visit(ExecuteParameter node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ExecuteParameter node) {
            this.Start<ExecuteParameter>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ExecuteParameter>(node);
        }
        public virtual void Visit(ExecutableEntity node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ExecutableEntity node) {
            this.Start<ExecutableEntity>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ExecutableEntity>(node);
        }
        public virtual void Visit(ProcedureReferenceName node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ProcedureReferenceName node) {
            this.Start<ProcedureReferenceName>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ProcedureReferenceName>(node);
        }
        public virtual void Visit(ExecutableProcedureReference node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ExecutableProcedureReference node) {
            this.Start<ExecutableProcedureReference>(node); if (this._visitBaseType) { this.Visit((ExecutableEntity)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ExecutableProcedureReference>(node);
        }
        public virtual void Visit(ExecutableStringList node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ExecutableStringList node) {
            this.Start<ExecutableStringList>(node); if (this._visitBaseType) { this.Visit((ExecutableEntity)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ExecutableStringList>(node);
        }
        public virtual void Visit(CreateViewStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(CreateViewStatement node) {
            this.Start<CreateViewStatement>(node); if (this._visitBaseType) { this.Visit((ViewStatementBody)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<CreateViewStatement>(node);
        }
        public virtual void Visit(CreateOrAlterViewStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(CreateOrAlterViewStatement node) {
            this.Start<CreateOrAlterViewStatement>(node); if (this._visitBaseType) { this.Visit((ViewStatementBody)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<CreateOrAlterViewStatement>(node);
        }
        public virtual void Visit(ViewStatementBody node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ViewStatementBody node) {
            this.Start<ViewStatementBody>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ViewStatementBody>(node);
        }
        public virtual void Visit(Identifier node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(Identifier node) {
            this.Start<Identifier>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<Identifier>(node);
        }
        public virtual void Visit(CreateProcedureStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(CreateProcedureStatement node) {
            this.Start<CreateProcedureStatement>(node); if (this._visitBaseType) { this.Visit((ProcedureStatementBody)node); this.Visit((ProcedureStatementBodyBase)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<CreateProcedureStatement>(node);
        }
        public virtual void Visit(AlterProcedureStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(AlterProcedureStatement node) {
            this.Start<AlterProcedureStatement>(node); if (this._visitBaseType) { this.Visit((ProcedureStatementBody)node); this.Visit((ProcedureStatementBodyBase)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<AlterProcedureStatement>(node);
        }
        public virtual void Visit(CreateOrAlterProcedureStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(CreateOrAlterProcedureStatement node) {
            this.Start<CreateOrAlterProcedureStatement>(node); if (this._visitBaseType) { this.Visit((ProcedureStatementBody)node); this.Visit((ProcedureStatementBodyBase)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<CreateOrAlterProcedureStatement>(node);
        }
        public virtual void Visit(ProcedureReference node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ProcedureReference node) {
            this.Start<ProcedureReference>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ProcedureReference>(node);
        }
        public virtual void Visit(MethodSpecifier node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(MethodSpecifier node) {
            this.Start<MethodSpecifier>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<MethodSpecifier>(node);
        }
        public virtual void Visit(ProcedureStatementBody node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ProcedureStatementBody node) {
            this.Start<ProcedureStatementBody>(node); if (this._visitBaseType) { this.Visit((ProcedureStatementBodyBase)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ProcedureStatementBody>(node);
        }
        public virtual void Visit(ProcedureStatementBodyBase node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ProcedureStatementBodyBase node) {
            this.Start<ProcedureStatementBodyBase>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ProcedureStatementBodyBase>(node);
        }
        public virtual void Visit(FunctionStatementBody node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(FunctionStatementBody node) {
            this.Start<FunctionStatementBody>(node); if (this._visitBaseType) { this.Visit((ProcedureStatementBodyBase)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<FunctionStatementBody>(node);
        }
        public virtual void Visit(XmlNamespaces node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(XmlNamespaces node) {
            this.Start<XmlNamespaces>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<XmlNamespaces>(node);
        }
        public virtual void Visit(XmlNamespacesElement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(XmlNamespacesElement node) {
            this.Start<XmlNamespacesElement>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<XmlNamespacesElement>(node);
        }
        public virtual void Visit(XmlNamespacesDefaultElement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(XmlNamespacesDefaultElement node) {
            this.Start<XmlNamespacesDefaultElement>(node); if (this._visitBaseType) { this.Visit((XmlNamespacesElement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<XmlNamespacesDefaultElement>(node);
        }
        public virtual void Visit(XmlNamespacesAliasElement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(XmlNamespacesAliasElement node) {
            this.Start<XmlNamespacesAliasElement>(node); if (this._visitBaseType) { this.Visit((XmlNamespacesElement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<XmlNamespacesAliasElement>(node);
        }
        public virtual void Visit(CommonTableExpression node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(CommonTableExpression node) {
            this.Start<CommonTableExpression>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<CommonTableExpression>(node);
        }
        public virtual void Visit(WithCtesAndXmlNamespaces node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(WithCtesAndXmlNamespaces node) {
            this.Start<WithCtesAndXmlNamespaces>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<WithCtesAndXmlNamespaces>(node);
        }
        public virtual void Visit(FunctionReturnType node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(FunctionReturnType node) {
            this.Start<FunctionReturnType>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<FunctionReturnType>(node);
        }
        public virtual void Visit(TableValuedFunctionReturnType node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(TableValuedFunctionReturnType node) {
            this.Start<TableValuedFunctionReturnType>(node); if (this._visitBaseType) { this.Visit((FunctionReturnType)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<TableValuedFunctionReturnType>(node);
        }
        public virtual void Visit(DataTypeReference node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(DataTypeReference node) {
            this.Start<DataTypeReference>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<DataTypeReference>(node);
        }
        public virtual void Visit(ParameterizedDataTypeReference node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ParameterizedDataTypeReference node) {
            this.Start<ParameterizedDataTypeReference>(node); if (this._visitBaseType) { this.Visit((DataTypeReference)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ParameterizedDataTypeReference>(node);
        }
        public virtual void Visit(SqlDataTypeReference node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SqlDataTypeReference node) {
            this.Start<SqlDataTypeReference>(node); if (this._visitBaseType) { this.Visit((ParameterizedDataTypeReference)node); this.Visit((DataTypeReference)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SqlDataTypeReference>(node);
        }
        public virtual void Visit(UserDataTypeReference node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(UserDataTypeReference node) {
            this.Start<UserDataTypeReference>(node); if (this._visitBaseType) { this.Visit((ParameterizedDataTypeReference)node); this.Visit((DataTypeReference)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<UserDataTypeReference>(node);
        }
        public virtual void Visit(XmlDataTypeReference node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(XmlDataTypeReference node) {
            this.Start<XmlDataTypeReference>(node); if (this._visitBaseType) { this.Visit((DataTypeReference)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<XmlDataTypeReference>(node);
        }
        public virtual void Visit(ScalarFunctionReturnType node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ScalarFunctionReturnType node) {
            this.Start<ScalarFunctionReturnType>(node); if (this._visitBaseType) { this.Visit((FunctionReturnType)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ScalarFunctionReturnType>(node);
        }
        public virtual void Visit(SelectFunctionReturnType node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SelectFunctionReturnType node) {
            this.Start<SelectFunctionReturnType>(node); if (this._visitBaseType) { this.Visit((FunctionReturnType)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SelectFunctionReturnType>(node);
        }
        public virtual void Visit(TableDefinition node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(TableDefinition node) {
            this.Start<TableDefinition>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<TableDefinition>(node);
        }
        public virtual void Visit(DeclareTableVariableBody node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(DeclareTableVariableBody node) {
            this.Start<DeclareTableVariableBody>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<DeclareTableVariableBody>(node);
        }
        public virtual void Visit(DeclareTableVariableStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(DeclareTableVariableStatement node) {
            this.Start<DeclareTableVariableStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<DeclareTableVariableStatement>(node);
        }
        public virtual void Visit(NamedTableReference node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(NamedTableReference node) {
            this.Start<NamedTableReference>(node); if (this._visitBaseType) { this.Visit((TableReferenceWithAlias)node); this.Visit((TableReference)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<NamedTableReference>(node);
        }
        public virtual void Visit(SchemaObjectFunctionTableReference node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SchemaObjectFunctionTableReference node) {
            this.Start<SchemaObjectFunctionTableReference>(node); if (this._visitBaseType) { this.Visit((TableReferenceWithAliasAndColumns)node); this.Visit((TableReferenceWithAlias)node); this.Visit((TableReference)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SchemaObjectFunctionTableReference>(node);
        }
        public virtual void Visit(QueryDerivedTable node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(QueryDerivedTable node) {
            this.Start<QueryDerivedTable>(node); if (this._visitBaseType) { this.Visit((TableReferenceWithAliasAndColumns)node); this.Visit((TableReferenceWithAlias)node); this.Visit((TableReference)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<QueryDerivedTable>(node);
        }
        public virtual void Visit(InlineDerivedTable node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(InlineDerivedTable node) {
            this.Start<InlineDerivedTable>(node); if (this._visitBaseType) { this.Visit((TableReferenceWithAliasAndColumns)node); this.Visit((TableReferenceWithAlias)node); this.Visit((TableReference)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<InlineDerivedTable>(node);
        }
        public virtual void Visit(SubqueryComparisonPredicate node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SubqueryComparisonPredicate node) {
            this.Start<SubqueryComparisonPredicate>(node); if (this._visitBaseType) { this.Visit((BooleanExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SubqueryComparisonPredicate>(node);
        }
        public virtual void Visit(ExistsPredicate node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ExistsPredicate node) {
            this.Start<ExistsPredicate>(node); if (this._visitBaseType) { this.Visit((BooleanExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ExistsPredicate>(node);
        }
        public virtual void Visit(LikePredicate node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(LikePredicate node) {
            this.Start<LikePredicate>(node); if (this._visitBaseType) { this.Visit((BooleanExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<LikePredicate>(node);
        }
        public virtual void Visit(InPredicate node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(InPredicate node) {
            this.Start<InPredicate>(node); if (this._visitBaseType) { this.Visit((BooleanExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<InPredicate>(node);
        }
        public virtual void Visit(UserDefinedTypePropertyAccess node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(UserDefinedTypePropertyAccess node) {
            this.Start<UserDefinedTypePropertyAccess>(node); if (this._visitBaseType) { this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<UserDefinedTypePropertyAccess>(node);
        }
        public virtual void Visit(StatementWithCtesAndXmlNamespaces node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(StatementWithCtesAndXmlNamespaces node) {
            this.Start<StatementWithCtesAndXmlNamespaces>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<StatementWithCtesAndXmlNamespaces>(node);
        }
        public virtual void Visit(SelectStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SelectStatement node) {
            this.Start<SelectStatement>(node); if (this._visitBaseType) { this.Visit((StatementWithCtesAndXmlNamespaces)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SelectStatement>(node);
        }
        public virtual void Visit(ForClause node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ForClause node) {
            this.Start<ForClause>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ForClause>(node);
        }
        public virtual void Visit(BrowseForClause node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(BrowseForClause node) {
            this.Start<BrowseForClause>(node); if (this._visitBaseType) { this.Visit((ForClause)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<BrowseForClause>(node);
        }
        public virtual void Visit(ReadOnlyForClause node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ReadOnlyForClause node) {
            this.Start<ReadOnlyForClause>(node); if (this._visitBaseType) { this.Visit((ForClause)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ReadOnlyForClause>(node);
        }
        public virtual void Visit(XmlForClause node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(XmlForClause node) {
            this.Start<XmlForClause>(node); if (this._visitBaseType) { this.Visit((ForClause)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<XmlForClause>(node);
        }
        public virtual void Visit(JsonForClause node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(JsonForClause node) {
            this.Start<JsonForClause>(node); if (this._visitBaseType) { this.Visit((ForClause)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<JsonForClause>(node);
        }
        public virtual void Visit(UpdateForClause node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(UpdateForClause node) {
            this.Start<UpdateForClause>(node); if (this._visitBaseType) { this.Visit((ForClause)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<UpdateForClause>(node);
        }
        public virtual void Visit(OptimizerHint node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(OptimizerHint node) {
            this.Start<OptimizerHint>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<OptimizerHint>(node);
        }
        public virtual void Visit(LiteralOptimizerHint node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(LiteralOptimizerHint node) {
            this.Start<LiteralOptimizerHint>(node); if (this._visitBaseType) { this.Visit((OptimizerHint)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<LiteralOptimizerHint>(node);
        }
        public virtual void Visit(OptimizeForOptimizerHint node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(OptimizeForOptimizerHint node) {
            this.Start<OptimizeForOptimizerHint>(node); if (this._visitBaseType) { this.Visit((OptimizerHint)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<OptimizeForOptimizerHint>(node);
        }
        public virtual void Visit(UseHintList node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(UseHintList node) {
            this.Start<UseHintList>(node); if (this._visitBaseType) { this.Visit((OptimizerHint)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<UseHintList>(node);
        }
        public virtual void Visit(VariableValuePair node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(VariableValuePair node) {
            this.Start<VariableValuePair>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<VariableValuePair>(node);
        }
        public virtual void Visit(WhenClause node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(WhenClause node) {
            this.Start<WhenClause>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<WhenClause>(node);
        }
        public virtual void Visit(SimpleWhenClause node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SimpleWhenClause node) {
            this.Start<SimpleWhenClause>(node); if (this._visitBaseType) { this.Visit((WhenClause)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SimpleWhenClause>(node);
        }
        public virtual void Visit(CaseExpression node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(CaseExpression node) {
            this.Start<CaseExpression>(node); if (this._visitBaseType) { this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<CaseExpression>(node);
        }
        public virtual void Visit(SimpleCaseExpression node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SimpleCaseExpression node) {
            this.Start<SimpleCaseExpression>(node); if (this._visitBaseType) { this.Visit((CaseExpression)node); this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SimpleCaseExpression>(node);
        }
        public virtual void Visit(NullIfExpression node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(NullIfExpression node) {
            this.Start<NullIfExpression>(node); if (this._visitBaseType) { this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<NullIfExpression>(node);
        }
        public virtual void Visit(CoalesceExpression node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(CoalesceExpression node) {
            this.Start<CoalesceExpression>(node); if (this._visitBaseType) { this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<CoalesceExpression>(node);
        }
        public virtual void Visit(IIfCall node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(IIfCall node) {
            this.Start<IIfCall>(node); if (this._visitBaseType) { this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<IIfCall>(node);
        }
        public virtual void Visit(SemanticTableReference node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SemanticTableReference node) {
            this.Start<SemanticTableReference>(node); if (this._visitBaseType) { this.Visit((TableReferenceWithAlias)node); this.Visit((TableReference)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SemanticTableReference>(node);
        }
        public virtual void Visit(OpenXmlTableReference node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(OpenXmlTableReference node) {
            this.Start<OpenXmlTableReference>(node); if (this._visitBaseType) { this.Visit((TableReferenceWithAlias)node); this.Visit((TableReference)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<OpenXmlTableReference>(node);
        }
        public virtual void Visit(OpenJsonTableReference node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(OpenJsonTableReference node) {
            this.Start<OpenJsonTableReference>(node); if (this._visitBaseType) { this.Visit((TableReferenceWithAlias)node); this.Visit((TableReference)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<OpenJsonTableReference>(node);
        }
        public virtual void Visit(SchemaDeclarationItem node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SchemaDeclarationItem node) {
            this.Start<SchemaDeclarationItem>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SchemaDeclarationItem>(node);
        }
        public virtual void Visit(SchemaDeclarationItemOpenjson node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SchemaDeclarationItemOpenjson node) {
            this.Start<SchemaDeclarationItemOpenjson>(node); if (this._visitBaseType) { this.Visit((SchemaDeclarationItem)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SchemaDeclarationItemOpenjson>(node);
        }
        public virtual void Visit(ConvertCall node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ConvertCall node) {
            this.Start<ConvertCall>(node); if (this._visitBaseType) { this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ConvertCall>(node);
        }
        public virtual void Visit(TryConvertCall node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(TryConvertCall node) {
            this.Start<TryConvertCall>(node); if (this._visitBaseType) { this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<TryConvertCall>(node);
        }
        public virtual void Visit(ParseCall node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ParseCall node) {
            this.Start<ParseCall>(node); if (this._visitBaseType) { this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ParseCall>(node);
        }
        public virtual void Visit(TryParseCall node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(TryParseCall node) {
            this.Start<TryParseCall>(node); if (this._visitBaseType) { this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<TryParseCall>(node);
        }
        public virtual void Visit(CastCall node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(CastCall node) {
            this.Start<CastCall>(node); if (this._visitBaseType) { this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<CastCall>(node);
        }
        public virtual void Visit(TryCastCall node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(TryCastCall node) {
            this.Start<TryCastCall>(node); if (this._visitBaseType) { this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<TryCastCall>(node);
        }
        public virtual void Visit(FunctionCall node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(FunctionCall node) {
            this.Start<FunctionCall>(node); if (this._visitBaseType) { this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<FunctionCall>(node);
        }
        public virtual void Visit(CallTarget node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(CallTarget node) {
            this.Start<CallTarget>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<CallTarget>(node);
        }
        public virtual void Visit(ExpressionCallTarget node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ExpressionCallTarget node) {
            this.Start<ExpressionCallTarget>(node); if (this._visitBaseType) { this.Visit((CallTarget)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ExpressionCallTarget>(node);
        }
        public virtual void Visit(MultiPartIdentifierCallTarget node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(MultiPartIdentifierCallTarget node) {
            this.Start<MultiPartIdentifierCallTarget>(node); if (this._visitBaseType) { this.Visit((CallTarget)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<MultiPartIdentifierCallTarget>(node);
        }
        public virtual void Visit(UserDefinedTypeCallTarget node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(UserDefinedTypeCallTarget node) {
            this.Start<UserDefinedTypeCallTarget>(node); if (this._visitBaseType) { this.Visit((CallTarget)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<UserDefinedTypeCallTarget>(node);
        }
        public virtual void Visit(LeftFunctionCall node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(LeftFunctionCall node) {
            this.Start<LeftFunctionCall>(node); if (this._visitBaseType) { this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<LeftFunctionCall>(node);
        }
        public virtual void Visit(RightFunctionCall node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(RightFunctionCall node) {
            this.Start<RightFunctionCall>(node); if (this._visitBaseType) { this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<RightFunctionCall>(node);
        }
        public virtual void Visit(OverClause node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(OverClause node) {
            this.Start<OverClause>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<OverClause>(node);
        }
        public virtual void Visit(ParameterlessCall node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ParameterlessCall node) {
            this.Start<ParameterlessCall>(node); if (this._visitBaseType) { this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ParameterlessCall>(node);
        }
        public virtual void Visit(ScalarSubquery node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ScalarSubquery node) {
            this.Start<ScalarSubquery>(node); if (this._visitBaseType) { this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ScalarSubquery>(node);
        }
        public virtual void Visit(ExtractFromExpression node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ExtractFromExpression node) {
            this.Start<ExtractFromExpression>(node); if (this._visitBaseType) { this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ExtractFromExpression>(node);
        }
        public virtual void Visit(BeginEndBlockStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(BeginEndBlockStatement node) {
            this.Start<BeginEndBlockStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<BeginEndBlockStatement>(node);
        }
        public virtual void Visit(BeginTransactionStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(BeginTransactionStatement node) {
            this.Start<BeginTransactionStatement>(node); if (this._visitBaseType) { this.Visit((TransactionStatement)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<BeginTransactionStatement>(node);
        }
        public virtual void Visit(BreakStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(BreakStatement node) {
            this.Start<BreakStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<BreakStatement>(node);
        }
        public virtual void Visit(ColumnWithSortOrder node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ColumnWithSortOrder node) {
            this.Start<ColumnWithSortOrder>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ColumnWithSortOrder>(node);
        }
        public virtual void Visit(CommitTransactionStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(CommitTransactionStatement node) {
            this.Start<CommitTransactionStatement>(node); if (this._visitBaseType) { this.Visit((TransactionStatement)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<CommitTransactionStatement>(node);
        }
        public virtual void Visit(RollbackTransactionStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(RollbackTransactionStatement node) {
            this.Start<RollbackTransactionStatement>(node); if (this._visitBaseType) { this.Visit((TransactionStatement)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<RollbackTransactionStatement>(node);
        }
        public virtual void Visit(SaveTransactionStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SaveTransactionStatement node) {
            this.Start<SaveTransactionStatement>(node); if (this._visitBaseType) { this.Visit((TransactionStatement)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SaveTransactionStatement>(node);
        }
        public virtual void Visit(ContinueStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ContinueStatement node) {
            this.Start<ContinueStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ContinueStatement>(node);
        }
        public virtual void Visit(CreateFunctionStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(CreateFunctionStatement node) {
            this.Start<CreateFunctionStatement>(node); if (this._visitBaseType) { this.Visit((FunctionStatementBody)node); this.Visit((ProcedureStatementBodyBase)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<CreateFunctionStatement>(node);
        }
        public virtual void Visit(AlterFunctionStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(AlterFunctionStatement node) {
            this.Start<AlterFunctionStatement>(node); if (this._visitBaseType) { this.Visit((FunctionStatementBody)node); this.Visit((ProcedureStatementBodyBase)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<AlterFunctionStatement>(node);
        }
        public virtual void Visit(CreateOrAlterFunctionStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(CreateOrAlterFunctionStatement node) {
            this.Start<CreateOrAlterFunctionStatement>(node); if (this._visitBaseType) { this.Visit((FunctionStatementBody)node); this.Visit((ProcedureStatementBodyBase)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<CreateOrAlterFunctionStatement>(node);
        }
        public virtual void Visit(DeclareVariableElement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(DeclareVariableElement node) {
            this.Start<DeclareVariableElement>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<DeclareVariableElement>(node);
        }
        public virtual void Visit(DeclareVariableStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(DeclareVariableStatement node) {
            this.Start<DeclareVariableStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<DeclareVariableStatement>(node);
        }
        public virtual void Visit(GoToStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(GoToStatement node) {
            this.Start<GoToStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<GoToStatement>(node);
        }
        public virtual void Visit(IfStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(IfStatement node) {
            this.Start<IfStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<IfStatement>(node);
        }
        public virtual void Visit(LabelStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(LabelStatement node) {
            this.Start<LabelStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<LabelStatement>(node);
        }
        public virtual void Visit(MultiPartIdentifier node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(MultiPartIdentifier node) {
            this.Start<MultiPartIdentifier>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<MultiPartIdentifier>(node);
        }
        public virtual void Visit(SchemaObjectName node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SchemaObjectName node) {
            this.Start<SchemaObjectName>(node); if (this._visitBaseType) { this.Visit((MultiPartIdentifier)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SchemaObjectName>(node);
        }
        public virtual void Visit(ChildObjectName node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ChildObjectName node) {
            this.Start<ChildObjectName>(node); if (this._visitBaseType) { this.Visit((SchemaObjectName)node); this.Visit((MultiPartIdentifier)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ChildObjectName>(node);
        }
        public virtual void Visit(ProcedureParameter node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ProcedureParameter node) {
            this.Start<ProcedureParameter>(node); if (this._visitBaseType) { this.Visit((DeclareVariableElement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ProcedureParameter>(node);
        }
        public virtual void Visit(TransactionStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(TransactionStatement node) {
            this.Start<TransactionStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<TransactionStatement>(node);
        }
        public virtual void Visit(WhileStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(WhileStatement node) {
            this.Start<WhileStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<WhileStatement>(node);
        }
        public virtual void Visit(DeleteStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(DeleteStatement node) {
            this.Start<DeleteStatement>(node); if (this._visitBaseType) { this.Visit((DataModificationStatement)node); this.Visit((StatementWithCtesAndXmlNamespaces)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<DeleteStatement>(node);
        }
        public virtual void Visit(UpdateDeleteSpecificationBase node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(UpdateDeleteSpecificationBase node) {
            this.Start<UpdateDeleteSpecificationBase>(node); if (this._visitBaseType) { this.Visit((DataModificationSpecification)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<UpdateDeleteSpecificationBase>(node);
        }
        public virtual void Visit(DeleteSpecification node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(DeleteSpecification node) {
            this.Start<DeleteSpecification>(node); if (this._visitBaseType) { this.Visit((UpdateDeleteSpecificationBase)node); this.Visit((DataModificationSpecification)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<DeleteSpecification>(node);
        }
        public virtual void Visit(InsertStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(InsertStatement node) {
            this.Start<InsertStatement>(node); if (this._visitBaseType) { this.Visit((DataModificationStatement)node); this.Visit((StatementWithCtesAndXmlNamespaces)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<InsertStatement>(node);
        }
        public virtual void Visit(InsertSpecification node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(InsertSpecification node) {
            this.Start<InsertSpecification>(node); if (this._visitBaseType) { this.Visit((DataModificationSpecification)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<InsertSpecification>(node);
        }
        public virtual void Visit(UpdateStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(UpdateStatement node) {
            this.Start<UpdateStatement>(node); if (this._visitBaseType) { this.Visit((DataModificationStatement)node); this.Visit((StatementWithCtesAndXmlNamespaces)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<UpdateStatement>(node);
        }
        public virtual void Visit(UpdateSpecification node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(UpdateSpecification node) {
            this.Start<UpdateSpecification>(node); if (this._visitBaseType) { this.Visit((UpdateDeleteSpecificationBase)node); this.Visit((DataModificationSpecification)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<UpdateSpecification>(node);
        }
        public virtual void Visit(WaitForStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(WaitForStatement node) {
            this.Start<WaitForStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<WaitForStatement>(node);
        }
        public virtual void Visit(ReadTextStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ReadTextStatement node) {
            this.Start<ReadTextStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ReadTextStatement>(node);
        }
        public virtual void Visit(UpdateTextStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(UpdateTextStatement node) {
            this.Start<UpdateTextStatement>(node); if (this._visitBaseType) { this.Visit((TextModificationStatement)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<UpdateTextStatement>(node);
        }
        public virtual void Visit(WriteTextStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(WriteTextStatement node) {
            this.Start<WriteTextStatement>(node); if (this._visitBaseType) { this.Visit((TextModificationStatement)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<WriteTextStatement>(node);
        }
        public virtual void Visit(TextModificationStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(TextModificationStatement node) {
            this.Start<TextModificationStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<TextModificationStatement>(node);
        }
        public virtual void Visit(Permission node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(Permission node) {
            this.Start<Permission>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<Permission>(node);
        }
        public virtual void Visit(SqlCommandIdentifier node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SqlCommandIdentifier node) {
            this.Start<SqlCommandIdentifier>(node); if (this._visitBaseType) { this.Visit((Identifier)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SqlCommandIdentifier>(node);
        }
        public virtual void Visit(SetClause node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SetClause node) {
            this.Start<SetClause>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SetClause>(node);
        }
        public virtual void Visit(AssignmentSetClause node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(AssignmentSetClause node) {
            this.Start<AssignmentSetClause>(node); if (this._visitBaseType) { this.Visit((SetClause)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<AssignmentSetClause>(node);
        }
        public virtual void Visit(FunctionCallSetClause node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(FunctionCallSetClause node) {
            this.Start<FunctionCallSetClause>(node); if (this._visitBaseType) { this.Visit((SetClause)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<FunctionCallSetClause>(node);
        }
        public virtual void Visit(InsertSource node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(InsertSource node) {
            this.Start<InsertSource>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<InsertSource>(node);
        }
        public virtual void Visit(ValuesInsertSource node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ValuesInsertSource node) {
            this.Start<ValuesInsertSource>(node); if (this._visitBaseType) { this.Visit((InsertSource)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ValuesInsertSource>(node);
        }
        public virtual void Visit(SelectInsertSource node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SelectInsertSource node) {
            this.Start<SelectInsertSource>(node); if (this._visitBaseType) { this.Visit((InsertSource)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SelectInsertSource>(node);
        }
        public virtual void Visit(ExecuteInsertSource node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ExecuteInsertSource node) {
            this.Start<ExecuteInsertSource>(node); if (this._visitBaseType) { this.Visit((InsertSource)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ExecuteInsertSource>(node);
        }
        public virtual void Visit(RowValue node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(RowValue node) {
            this.Start<RowValue>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<RowValue>(node);
        }
        public virtual void Visit(PrintStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(PrintStatement node) {
            this.Start<PrintStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<PrintStatement>(node);
        }
        public virtual void Visit(UpdateCall node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(UpdateCall node) {
            this.Start<UpdateCall>(node); if (this._visitBaseType) { this.Visit((BooleanExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<UpdateCall>(node);
        }
        public virtual void Visit(TSEqualCall node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(TSEqualCall node) {
            this.Start<TSEqualCall>(node); if (this._visitBaseType) { this.Visit((BooleanExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<TSEqualCall>(node);
        }
        public virtual void Visit(PrimaryExpression node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(PrimaryExpression node) {
            this.Start<PrimaryExpression>(node); if (this._visitBaseType) { this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<PrimaryExpression>(node);
        }
        public virtual void Visit(Literal node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(Literal node) {
            this.Start<Literal>(node); if (this._visitBaseType) { this.Visit((ValueExpression)node); this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<Literal>(node);
        }
        public virtual void Visit(IntegerLiteral node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(IntegerLiteral node) {
            this.Start<IntegerLiteral>(node); if (this._visitBaseType) { this.Visit((Literal)node); this.Visit((ValueExpression)node); this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<IntegerLiteral>(node);
        }
        public virtual void Visit(NumericLiteral node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(NumericLiteral node) {
            this.Start<NumericLiteral>(node); if (this._visitBaseType) { this.Visit((Literal)node); this.Visit((ValueExpression)node); this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<NumericLiteral>(node);
        }
        public virtual void Visit(RealLiteral node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(RealLiteral node) {
            this.Start<RealLiteral>(node); if (this._visitBaseType) { this.Visit((Literal)node); this.Visit((ValueExpression)node); this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<RealLiteral>(node);
        }
        public virtual void Visit(MoneyLiteral node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(MoneyLiteral node) {
            this.Start<MoneyLiteral>(node); if (this._visitBaseType) { this.Visit((Literal)node); this.Visit((ValueExpression)node); this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<MoneyLiteral>(node);
        }
        public virtual void Visit(BinaryLiteral node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(BinaryLiteral node) {
            this.Start<BinaryLiteral>(node); if (this._visitBaseType) { this.Visit((Literal)node); this.Visit((ValueExpression)node); this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<BinaryLiteral>(node);
        }
        public virtual void Visit(StringLiteral node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(StringLiteral node) {
            this.Start<StringLiteral>(node); if (this._visitBaseType) { this.Visit((Literal)node); this.Visit((ValueExpression)node); this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<StringLiteral>(node);
        }
        public virtual void Visit(NullLiteral node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(NullLiteral node) {
            this.Start<NullLiteral>(node); if (this._visitBaseType) { this.Visit((Literal)node); this.Visit((ValueExpression)node); this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<NullLiteral>(node);
        }
        public virtual void Visit(IdentifierLiteral node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(IdentifierLiteral node) {
            this.Start<IdentifierLiteral>(node); if (this._visitBaseType) { this.Visit((Literal)node); this.Visit((ValueExpression)node); this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<IdentifierLiteral>(node);
        }
        public virtual void Visit(DefaultLiteral node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(DefaultLiteral node) {
            this.Start<DefaultLiteral>(node); if (this._visitBaseType) { this.Visit((Literal)node); this.Visit((ValueExpression)node); this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<DefaultLiteral>(node);
        }
        public virtual void Visit(MaxLiteral node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(MaxLiteral node) {
            this.Start<MaxLiteral>(node); if (this._visitBaseType) { this.Visit((Literal)node); this.Visit((ValueExpression)node); this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<MaxLiteral>(node);
        }
        public virtual void Visit(LiteralRange node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(LiteralRange node) {
            this.Start<LiteralRange>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<LiteralRange>(node);
        }
        public virtual void Visit(ValueExpression node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ValueExpression node) {
            this.Start<ValueExpression>(node); if (this._visitBaseType) { this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ValueExpression>(node);
        }
        public virtual void Visit(VariableReference node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(VariableReference node) {
            this.Start<VariableReference>(node); if (this._visitBaseType) { this.Visit((ValueExpression)node); this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<VariableReference>(node);
        }
        public virtual void Visit(OptionValue node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(OptionValue node) {
            this.Start<OptionValue>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<OptionValue>(node);
        }
        public virtual void Visit(OnOffOptionValue node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(OnOffOptionValue node) {
            this.Start<OnOffOptionValue>(node); if (this._visitBaseType) { this.Visit((OptionValue)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<OnOffOptionValue>(node);
        }
        public virtual void Visit(LiteralOptionValue node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(LiteralOptionValue node) {
            this.Start<LiteralOptionValue>(node); if (this._visitBaseType) { this.Visit((OptionValue)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<LiteralOptionValue>(node);
        }
        public virtual void Visit(GlobalVariableExpression node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(GlobalVariableExpression node) {
            this.Start<GlobalVariableExpression>(node); if (this._visitBaseType) { this.Visit((ValueExpression)node); this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<GlobalVariableExpression>(node);
        }
        public virtual void Visit(IdentifierOrValueExpression node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(IdentifierOrValueExpression node) {
            this.Start<IdentifierOrValueExpression>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<IdentifierOrValueExpression>(node);
        }
        public virtual void Visit(IdentifierOrScalarExpression node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(IdentifierOrScalarExpression node) {
            this.Start<IdentifierOrScalarExpression>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<IdentifierOrScalarExpression>(node);
        }
        public virtual void Visit(SchemaObjectNameOrValueExpression node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SchemaObjectNameOrValueExpression node) {
            this.Start<SchemaObjectNameOrValueExpression>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SchemaObjectNameOrValueExpression>(node);
        }
        public virtual void Visit(ParenthesisExpression node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ParenthesisExpression node) {
            this.Start<ParenthesisExpression>(node); if (this._visitBaseType) { this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ParenthesisExpression>(node);
        }
        public virtual void Visit(ColumnReferenceExpression node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ColumnReferenceExpression node) {
            this.Start<ColumnReferenceExpression>(node); if (this._visitBaseType) { this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ColumnReferenceExpression>(node);
        }
        public virtual void Visit(NextValueForExpression node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(NextValueForExpression node) {
            this.Start<NextValueForExpression>(node); if (this._visitBaseType) { this.Visit((PrimaryExpression)node); this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<NextValueForExpression>(node);
        }
        public virtual void Visit(TryCatchStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(TryCatchStatement node) {
            this.Start<TryCatchStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<TryCatchStatement>(node);
        }
        public virtual void Visit(ExecuteAsClause node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ExecuteAsClause node) {
            this.Start<ExecuteAsClause>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ExecuteAsClause>(node);
        }
        public virtual void Visit(FileGroupOrPartitionScheme node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(FileGroupOrPartitionScheme node) {
            this.Start<FileGroupOrPartitionScheme>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<FileGroupOrPartitionScheme>(node);
        }
        public virtual void Visit(ReturnStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ReturnStatement node) {
            this.Start<ReturnStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ReturnStatement>(node);
        }
        public virtual void Visit(DeclareCursorStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(DeclareCursorStatement node) {
            this.Start<DeclareCursorStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<DeclareCursorStatement>(node);
        }
        public virtual void Visit(CursorDefinition node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(CursorDefinition node) {
            this.Start<CursorDefinition>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<CursorDefinition>(node);
        }
        public virtual void Visit(SetVariableStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SetVariableStatement node) {
            this.Start<SetVariableStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SetVariableStatement>(node);
        }
        public virtual void Visit(CursorId node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(CursorId node) {
            this.Start<CursorId>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<CursorId>(node);
        }
        public virtual void Visit(CursorStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(CursorStatement node) {
            this.Start<CursorStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<CursorStatement>(node);
        }
        public virtual void Visit(OpenCursorStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(OpenCursorStatement node) {
            this.Start<OpenCursorStatement>(node); if (this._visitBaseType) { this.Visit((CursorStatement)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<OpenCursorStatement>(node);
        }
        public virtual void Visit(CloseCursorStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(CloseCursorStatement node) {
            this.Start<CloseCursorStatement>(node); if (this._visitBaseType) { this.Visit((CursorStatement)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<CloseCursorStatement>(node);
        }
        public virtual void Visit(FetchType node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(FetchType node) {
            this.Start<FetchType>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<FetchType>(node);
        }
        public virtual void Visit(FetchCursorStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(FetchCursorStatement node) {
            this.Start<FetchCursorStatement>(node); if (this._visitBaseType) { this.Visit((CursorStatement)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<FetchCursorStatement>(node);
        }
        public virtual void Visit(WhereClause node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(WhereClause node) {
            this.Start<WhereClause>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<WhereClause>(node);
        }
        public virtual void Visit(DropIndexStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(DropIndexStatement node) {
            this.Start<DropIndexStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<DropIndexStatement>(node);
        }
        public virtual void Visit(DropIndexClauseBase node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(DropIndexClauseBase node) {
            this.Start<DropIndexClauseBase>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<DropIndexClauseBase>(node);
        }
        public virtual void Visit(DropTableStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(DropTableStatement node) {
            this.Start<DropTableStatement>(node); if (this._visitBaseType) { this.Visit((DropObjectsStatement)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<DropTableStatement>(node);
        }
        public virtual void Visit(RaiseErrorLegacyStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(RaiseErrorLegacyStatement node) {
            this.Start<RaiseErrorLegacyStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<RaiseErrorLegacyStatement>(node);
        }
        public virtual void Visit(RaiseErrorStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(RaiseErrorStatement node) {
            this.Start<RaiseErrorStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<RaiseErrorStatement>(node);
        }
        public virtual void Visit(ThrowStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ThrowStatement node) {
            this.Start<ThrowStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ThrowStatement>(node);
        }
        public virtual void Visit(CheckpointStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(CheckpointStatement node) {
            this.Start<CheckpointStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<CheckpointStatement>(node);
        }
        public virtual void Visit(TruncateTableStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(TruncateTableStatement node) {
            this.Start<TruncateTableStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<TruncateTableStatement>(node);
        }
        public virtual void Visit(SetOnOffStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SetOnOffStatement node) {
            this.Start<SetOnOffStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SetOnOffStatement>(node);
        }
        public virtual void Visit(PredicateSetStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(PredicateSetStatement node) {
            this.Start<PredicateSetStatement>(node); if (this._visitBaseType) { this.Visit((SetOnOffStatement)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<PredicateSetStatement>(node);
        }
        public virtual void Visit(SetStatisticsStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SetStatisticsStatement node) {
            this.Start<SetStatisticsStatement>(node); if (this._visitBaseType) { this.Visit((SetOnOffStatement)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SetStatisticsStatement>(node);
        }
        public virtual void Visit(SetRowCountStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SetRowCountStatement node) {
            this.Start<SetRowCountStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SetRowCountStatement>(node);
        }
        public virtual void Visit(SetOffsetsStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SetOffsetsStatement node) {
            this.Start<SetOffsetsStatement>(node); if (this._visitBaseType) { this.Visit((SetOnOffStatement)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SetOffsetsStatement>(node);
        }
        public virtual void Visit(SetCommand node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SetCommand node) {
            this.Start<SetCommand>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SetCommand>(node);
        }
        public virtual void Visit(GeneralSetCommand node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(GeneralSetCommand node) {
            this.Start<GeneralSetCommand>(node); if (this._visitBaseType) { this.Visit((SetCommand)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<GeneralSetCommand>(node);
        }
        public virtual void Visit(SetCommandStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SetCommandStatement node) {
            this.Start<SetCommandStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SetCommandStatement>(node);
        }
        public virtual void Visit(SetTransactionIsolationLevelStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SetTransactionIsolationLevelStatement node) {
            this.Start<SetTransactionIsolationLevelStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SetTransactionIsolationLevelStatement>(node);
        }
        public virtual void Visit(SetTextSizeStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SetTextSizeStatement node) {
            this.Start<SetTextSizeStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SetTextSizeStatement>(node);
        }
        public virtual void Visit(SetIdentityInsertStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SetIdentityInsertStatement node) {
            this.Start<SetIdentityInsertStatement>(node); if (this._visitBaseType) { this.Visit((SetOnOffStatement)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SetIdentityInsertStatement>(node);
        }
        public virtual void Visit(SetErrorLevelStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SetErrorLevelStatement node) {
            this.Start<SetErrorLevelStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SetErrorLevelStatement>(node);
        }
        public virtual void Visit(ColumnDefinition node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ColumnDefinition node) {
            this.Start<ColumnDefinition>(node); if (this._visitBaseType) { this.Visit((ColumnDefinitionBase)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ColumnDefinition>(node);
        }
        public virtual void Visit(IdentityOptions node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(IdentityOptions node) {
            this.Start<IdentityOptions>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<IdentityOptions>(node);
        }
        public virtual void Visit(ConstraintDefinition node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ConstraintDefinition node) {
            this.Start<ConstraintDefinition>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ConstraintDefinition>(node);
        }
        public virtual void Visit(CreateTableStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(CreateTableStatement node) {
            this.Start<CreateTableStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<CreateTableStatement>(node);
        }
        public virtual void Visit(TableDistributionPolicy node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(TableDistributionPolicy node) {
            this.Start<TableDistributionPolicy>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<TableDistributionPolicy>(node);
        }
        public virtual void Visit(TableHashDistributionPolicy node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(TableHashDistributionPolicy node) {
            this.Start<TableHashDistributionPolicy>(node); if (this._visitBaseType) { this.Visit((TableDistributionPolicy)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<TableHashDistributionPolicy>(node);
        }
        public virtual void Visit(TableIndexType node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(TableIndexType node) {
            this.Start<TableIndexType>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<TableIndexType>(node);
        }
        public virtual void Visit(TableClusteredIndexType node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(TableClusteredIndexType node) {
            this.Start<TableClusteredIndexType>(node); if (this._visitBaseType) { this.Visit((TableIndexType)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<TableClusteredIndexType>(node);
        }
        public virtual void Visit(TableNonClusteredIndexType node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(TableNonClusteredIndexType node) {
            this.Start<TableNonClusteredIndexType>(node); if (this._visitBaseType) { this.Visit((TableIndexType)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<TableNonClusteredIndexType>(node);
        }
        public virtual void Visit(CompressionPartitionRange node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(CompressionPartitionRange node) {
            this.Start<CompressionPartitionRange>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<CompressionPartitionRange>(node);
        }
        public virtual void Visit(DefaultConstraintDefinition node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(DefaultConstraintDefinition node) {
            this.Start<DefaultConstraintDefinition>(node); if (this._visitBaseType) { this.Visit((ConstraintDefinition)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<DefaultConstraintDefinition>(node);
        }
        public virtual void Visit(NullableConstraintDefinition node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(NullableConstraintDefinition node) {
            this.Start<NullableConstraintDefinition>(node); if (this._visitBaseType) { this.Visit((ConstraintDefinition)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<NullableConstraintDefinition>(node);
        }
        public virtual void Visit(UniqueConstraintDefinition node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(UniqueConstraintDefinition node) {
            this.Start<UniqueConstraintDefinition>(node); if (this._visitBaseType) { this.Visit((ConstraintDefinition)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<UniqueConstraintDefinition>(node);
        }
        public virtual void Visit(ColumnDefinitionBase node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ColumnDefinitionBase node) {
            this.Start<ColumnDefinitionBase>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ColumnDefinitionBase>(node);
        }
        public virtual void Visit(InsertBulkColumnDefinition node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(InsertBulkColumnDefinition node) {
            this.Start<InsertBulkColumnDefinition>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<InsertBulkColumnDefinition>(node);
        }
        public virtual void Visit(BinaryExpression node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(BinaryExpression node) {
            this.Start<BinaryExpression>(node); if (this._visitBaseType) { this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<BinaryExpression>(node);
        }
        public virtual void Visit(BuiltInFunctionTableReference node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(BuiltInFunctionTableReference node) {
            this.Start<BuiltInFunctionTableReference>(node); if (this._visitBaseType) { this.Visit((TableReferenceWithAlias)node); this.Visit((TableReference)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<BuiltInFunctionTableReference>(node);
        }
        public virtual void Visit(GlobalFunctionTableReference node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(GlobalFunctionTableReference node) {
            this.Start<GlobalFunctionTableReference>(node); if (this._visitBaseType) { this.Visit((TableReferenceWithAlias)node); this.Visit((TableReference)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<GlobalFunctionTableReference>(node);
        }
        public virtual void Visit(ComputeClause node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ComputeClause node) {
            this.Start<ComputeClause>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ComputeClause>(node);
        }
        public virtual void Visit(ComputeFunction node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ComputeFunction node) {
            this.Start<ComputeFunction>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ComputeFunction>(node);
        }
        public virtual void Visit(PivotedTableReference node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(PivotedTableReference node) {
            this.Start<PivotedTableReference>(node); if (this._visitBaseType) { this.Visit((TableReferenceWithAlias)node); this.Visit((TableReference)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<PivotedTableReference>(node);
        }
        public virtual void Visit(UnpivotedTableReference node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(UnpivotedTableReference node) {
            this.Start<UnpivotedTableReference>(node); if (this._visitBaseType) { this.Visit((TableReferenceWithAlias)node); this.Visit((TableReference)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<UnpivotedTableReference>(node);
        }
        public virtual void Visit(UnqualifiedJoin node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(UnqualifiedJoin node) {
            this.Start<UnqualifiedJoin>(node); if (this._visitBaseType) { this.Visit((JoinTableReference)node); this.Visit((TableReference)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<UnqualifiedJoin>(node);
        }
        public virtual void Visit(ScalarExpression node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ScalarExpression node) {
            this.Start<ScalarExpression>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ScalarExpression>(node);
        }
        public virtual void Visit(BooleanExpression node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(BooleanExpression node) {
            this.Start<BooleanExpression>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<BooleanExpression>(node);
        }
        public virtual void Visit(BooleanNotExpression node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(BooleanNotExpression node) {
            this.Start<BooleanNotExpression>(node); if (this._visitBaseType) { this.Visit((BooleanExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<BooleanNotExpression>(node);
        }
        public virtual void Visit(BooleanParenthesisExpression node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(BooleanParenthesisExpression node) {
            this.Start<BooleanParenthesisExpression>(node); if (this._visitBaseType) { this.Visit((BooleanExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<BooleanParenthesisExpression>(node);
        }
        public virtual void Visit(BooleanComparisonExpression node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(BooleanComparisonExpression node) {
            this.Start<BooleanComparisonExpression>(node); if (this._visitBaseType) { this.Visit((BooleanExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<BooleanComparisonExpression>(node);
        }
        public virtual void Visit(BooleanBinaryExpression node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(BooleanBinaryExpression node) {
            this.Start<BooleanBinaryExpression>(node); if (this._visitBaseType) { this.Visit((BooleanExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<BooleanBinaryExpression>(node);
        }
        public virtual void Visit(BooleanIsNullExpression node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(BooleanIsNullExpression node) {
            this.Start<BooleanIsNullExpression>(node); if (this._visitBaseType) { this.Visit((BooleanExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<BooleanIsNullExpression>(node);
        }
        public virtual void Visit(ExpressionWithSortOrder node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ExpressionWithSortOrder node) {
            this.Start<ExpressionWithSortOrder>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ExpressionWithSortOrder>(node);
        }
        public virtual void Visit(GroupByClause node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(GroupByClause node) {
            this.Start<GroupByClause>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<GroupByClause>(node);
        }
        public virtual void Visit(GroupingSpecification node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(GroupingSpecification node) {
            this.Start<GroupingSpecification>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<GroupingSpecification>(node);
        }
        public virtual void Visit(ExpressionGroupingSpecification node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ExpressionGroupingSpecification node) {
            this.Start<ExpressionGroupingSpecification>(node); if (this._visitBaseType) { this.Visit((GroupingSpecification)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ExpressionGroupingSpecification>(node);
        }
        public virtual void Visit(CompositeGroupingSpecification node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(CompositeGroupingSpecification node) {
            this.Start<CompositeGroupingSpecification>(node); if (this._visitBaseType) { this.Visit((GroupingSpecification)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<CompositeGroupingSpecification>(node);
        }
        public virtual void Visit(RollupGroupingSpecification node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(RollupGroupingSpecification node) {
            this.Start<RollupGroupingSpecification>(node); if (this._visitBaseType) { this.Visit((GroupingSpecification)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<RollupGroupingSpecification>(node);
        }
        public virtual void Visit(GrandTotalGroupingSpecification node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(GrandTotalGroupingSpecification node) {
            this.Start<GrandTotalGroupingSpecification>(node); if (this._visitBaseType) { this.Visit((GroupingSpecification)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<GrandTotalGroupingSpecification>(node);
        }
        public virtual void Visit(GroupingSetsGroupingSpecification node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(GroupingSetsGroupingSpecification node) {
            this.Start<GroupingSetsGroupingSpecification>(node); if (this._visitBaseType) { this.Visit((GroupingSpecification)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<GroupingSetsGroupingSpecification>(node);
        }
        public virtual void Visit(OutputClause node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(OutputClause node) {
            this.Start<OutputClause>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<OutputClause>(node);
        }
        public virtual void Visit(OutputIntoClause node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(OutputIntoClause node) {
            this.Start<OutputIntoClause>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<OutputIntoClause>(node);
        }
        public virtual void Visit(HavingClause node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(HavingClause node) {
            this.Start<HavingClause>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<HavingClause>(node);
        }
        public virtual void Visit(IdentityFunctionCall node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(IdentityFunctionCall node) {
            this.Start<IdentityFunctionCall>(node); if (this._visitBaseType) { this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<IdentityFunctionCall>(node);
        }
        public virtual void Visit(JoinParenthesisTableReference node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(JoinParenthesisTableReference node) {
            this.Start<JoinParenthesisTableReference>(node); if (this._visitBaseType) { this.Visit((TableReference)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<JoinParenthesisTableReference>(node);
        }
        public virtual void Visit(OrderByClause node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(OrderByClause node) {
            this.Start<OrderByClause>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<OrderByClause>(node);
        }
        public virtual void Visit(JoinTableReference node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(JoinTableReference node) {
            this.Start<JoinTableReference>(node); if (this._visitBaseType) { this.Visit((TableReference)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<JoinTableReference>(node);
        }
        public virtual void Visit(QualifiedJoin node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(QualifiedJoin node) {
            this.Start<QualifiedJoin>(node); if (this._visitBaseType) { this.Visit((JoinTableReference)node); this.Visit((TableReference)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<QualifiedJoin>(node);
        }
        public virtual void Visit(QueryExpression node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(QueryExpression node) {
            this.Start<QueryExpression>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<QueryExpression>(node);
        }
        public virtual void Visit(QueryParenthesisExpression node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(QueryParenthesisExpression node) {
            this.Start<QueryParenthesisExpression>(node); if (this._visitBaseType) { this.Visit((QueryExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<QueryParenthesisExpression>(node);
        }
        public virtual void Visit(QuerySpecification node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(QuerySpecification node) {
            this.Start<QuerySpecification>(node); if (this._visitBaseType) { this.Visit((QueryExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<QuerySpecification>(node);
        }
        public virtual void Visit(FromClause node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(FromClause node) {
            this.Start<FromClause>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<FromClause>(node);
        }
        public virtual void Visit(SelectElement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SelectElement node) {
            this.Start<SelectElement>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SelectElement>(node);
        }
        public virtual void Visit(SelectScalarExpression node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SelectScalarExpression node) {
            this.Start<SelectScalarExpression>(node); if (this._visitBaseType) { this.Visit((SelectElement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SelectScalarExpression>(node);
        }
        public virtual void Visit(SelectStarExpression node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SelectStarExpression node) {
            this.Start<SelectStarExpression>(node); if (this._visitBaseType) { this.Visit((SelectElement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SelectStarExpression>(node);
        }
        public virtual void Visit(SelectSetVariable node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SelectSetVariable node) {
            this.Start<SelectSetVariable>(node); if (this._visitBaseType) { this.Visit((SelectElement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SelectSetVariable>(node);
        }
        public virtual void Visit(TableReference node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(TableReference node) {
            this.Start<TableReference>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<TableReference>(node);
        }
        public virtual void Visit(TableReferenceWithAlias node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(TableReferenceWithAlias node) {
            this.Start<TableReferenceWithAlias>(node); if (this._visitBaseType) { this.Visit((TableReference)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<TableReferenceWithAlias>(node);
        }
        public virtual void Visit(TableReferenceWithAliasAndColumns node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(TableReferenceWithAliasAndColumns node) {
            this.Start<TableReferenceWithAliasAndColumns>(node); if (this._visitBaseType) { this.Visit((TableReferenceWithAlias)node); this.Visit((TableReference)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<TableReferenceWithAliasAndColumns>(node);
        }
        public virtual void Visit(DataModificationTableReference node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(DataModificationTableReference node) {
            this.Start<DataModificationTableReference>(node); if (this._visitBaseType) { this.Visit((TableReferenceWithAliasAndColumns)node); this.Visit((TableReferenceWithAlias)node); this.Visit((TableReference)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<DataModificationTableReference>(node);
        }
        public virtual void Visit(BooleanTernaryExpression node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(BooleanTernaryExpression node) {
            this.Start<BooleanTernaryExpression>(node); if (this._visitBaseType) { this.Visit((BooleanExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<BooleanTernaryExpression>(node);
        }
        public virtual void Visit(TopRowFilter node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(TopRowFilter node) {
            this.Start<TopRowFilter>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<TopRowFilter>(node);
        }
        public virtual void Visit(OffsetClause node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(OffsetClause node) {
            this.Start<OffsetClause>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<OffsetClause>(node);
        }
        public virtual void Visit(UnaryExpression node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(UnaryExpression node) {
            this.Start<UnaryExpression>(node); if (this._visitBaseType) { this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<UnaryExpression>(node);
        }
        public virtual void Visit(BinaryQueryExpression node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(BinaryQueryExpression node) {
            this.Start<BinaryQueryExpression>(node); if (this._visitBaseType) { this.Visit((QueryExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<BinaryQueryExpression>(node);
        }
        public virtual void Visit(VariableTableReference node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(VariableTableReference node) {
            this.Start<VariableTableReference>(node); if (this._visitBaseType) { this.Visit((TableReferenceWithAlias)node); this.Visit((TableReference)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<VariableTableReference>(node);
        }
        public virtual void Visit(VariableMethodCallTableReference node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(VariableMethodCallTableReference node) {
            this.Start<VariableMethodCallTableReference>(node); if (this._visitBaseType) { this.Visit((TableReferenceWithAliasAndColumns)node); this.Visit((TableReferenceWithAlias)node); this.Visit((TableReference)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<VariableMethodCallTableReference>(node);
        }
        public virtual void Visit(DropSynonymStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(DropSynonymStatement node) {
            this.Start<DropSynonymStatement>(node); if (this._visitBaseType) { this.Visit((DropObjectsStatement)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<DropSynonymStatement>(node);
        }
        public virtual void Visit(ExecuteAsStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(ExecuteAsStatement node) {
            this.Start<ExecuteAsStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ExecuteAsStatement>(node);
        }
        public virtual void Visit(WaitForSupportedStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(WaitForSupportedStatement node) {
            this.Start<WaitForSupportedStatement>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<WaitForSupportedStatement>(node);
        }
        public virtual void ExplicitVisit(ScalarExpressionSnippet node) {
            this.Start<ScalarExpressionSnippet>(node); if (this._visitBaseType) { this.Visit((ScalarExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<ScalarExpressionSnippet>(node);
        }
        public virtual void Visit(BooleanExpressionSnippet node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(BooleanExpressionSnippet node) {
            this.Start<BooleanExpressionSnippet>(node); if (this._visitBaseType) { this.Visit((BooleanExpression)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<BooleanExpressionSnippet>(node);
        }
        public virtual void Visit(StatementListSnippet node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(StatementListSnippet node) {
            this.Start<StatementListSnippet>(node); if (this._visitBaseType) { this.Visit((StatementList)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<StatementListSnippet>(node);
        }
        public virtual void Visit(SelectStatementSnippet node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SelectStatementSnippet node) {
            this.Start<SelectStatementSnippet>(node); if (this._visitBaseType) { this.Visit((SelectStatement)node); this.Visit((StatementWithCtesAndXmlNamespaces)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SelectStatementSnippet>(node);
        }
        public virtual void Visit(SchemaObjectNameSnippet node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SchemaObjectNameSnippet node) {
            this.Start<SchemaObjectNameSnippet>(node); if (this._visitBaseType) { this.Visit((SchemaObjectName)node); this.Visit((MultiPartIdentifier)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SchemaObjectNameSnippet>(node);
        }
        public virtual void Visit(TSqlFragmentSnippet node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(TSqlFragmentSnippet node) {
            this.Start<TSqlFragmentSnippet>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<TSqlFragmentSnippet>(node);
        }
        public virtual void Visit(TSqlStatementSnippet node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(TSqlStatementSnippet node) {
            this.Start<TSqlStatementSnippet>(node); if (this._visitBaseType) { this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<TSqlStatementSnippet>(node);
        }
        public virtual void Visit(IdentifierSnippet node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(IdentifierSnippet node) {
            this.Start<IdentifierSnippet>(node); if (this._visitBaseType) { this.Visit((Identifier)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<IdentifierSnippet>(node);
        }
        public virtual void Visit(SqlScript node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SqlScript node) {
            this.Start<SqlScript>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SqlScript>(node);
        }
        public virtual void Visit(SqlBatch node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SqlBatch node) {
            this.Start<SqlBatch>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SqlBatch>(node);
        }
        public virtual void Visit(SqlStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(SqlStatement node) {
            this.Start<SqlStatement>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<SqlStatement>(node);
        }
        public virtual void Visit(DataModificationStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(DataModificationStatement node) {
            this.Start<DataModificationStatement>(node); if (this._visitBaseType) { this.Visit((StatementWithCtesAndXmlNamespaces)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<DataModificationStatement>(node);
        }
        public virtual void Visit(DataModificationSpecification node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(DataModificationSpecification node) {
            this.Start<DataModificationSpecification>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<DataModificationSpecification>(node);
        }
        public virtual void Visit(MergeStatement node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(MergeStatement node) {
            this.Start<MergeStatement>(node); if (this._visitBaseType) { this.Visit((DataModificationStatement)node); this.Visit((StatementWithCtesAndXmlNamespaces)node); this.Visit((SqlStatement)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<MergeStatement>(node);
        }
        public virtual void Visit(MergeSpecification node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(MergeSpecification node) {
            this.Start<MergeSpecification>(node); if (this._visitBaseType) { this.Visit((DataModificationSpecification)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<MergeSpecification>(node);
        }
        public virtual void Visit(MergeActionClause node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(MergeActionClause node) {
            this.Start<MergeActionClause>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<MergeActionClause>(node);
        }
        public virtual void Visit(MergeAction node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(MergeAction node) {
            this.Start<MergeAction>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<MergeAction>(node);
        }
        public virtual void Visit(UpdateMergeAction node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(UpdateMergeAction node) {
            this.Start<UpdateMergeAction>(node); if (this._visitBaseType) { this.Visit((MergeAction)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<UpdateMergeAction>(node);
        }
        public virtual void Visit(DeleteMergeAction node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(DeleteMergeAction node) {
            this.Start<DeleteMergeAction>(node); if (this._visitBaseType) { this.Visit((MergeAction)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<DeleteMergeAction>(node);
        }
        public virtual void Visit(InsertMergeAction node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(InsertMergeAction node) {
            this.Start<InsertMergeAction>(node); if (this._visitBaseType) { this.Visit((MergeAction)node); this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<InsertMergeAction>(node);
        }
        public virtual void ExplicitVisit(WindowFrameClause node) {
            this.Start<WindowFrameClause>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<WindowFrameClause>(node);
        }
        public virtual void Visit(WindowDelimiter node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(WindowDelimiter node) {
            this.Start<WindowDelimiter>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<WindowDelimiter>(node);
        }
        public virtual void Visit(WithinGroupClause node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(WithinGroupClause node) {
            this.Start<WithinGroupClause>(node); if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<WithinGroupClause>(node);
        }
        public virtual void Visit(IndexType node) { if (!this._visitBaseType) { this.Visit((SqlNode)node); } }
        public virtual void ExplicitVisit(IndexType node) {
            this.Start<IndexType>(node);
            if (this._visitBaseType) { this.Visit((SqlNode)node); }
            this.Visit(node); node.AcceptChildren(this);
            this.Done<IndexType>(node);
        }
    }
}