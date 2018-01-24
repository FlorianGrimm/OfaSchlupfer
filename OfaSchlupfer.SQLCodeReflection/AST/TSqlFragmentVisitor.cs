namespace OfaSchlupfer.AST {
    public abstract class TSqlFragmentVisitor {
        private readonly bool _visitBaseType;

        internal bool VisitBaseType {
            get {
                return this._visitBaseType;
            }
        }

        protected TSqlFragmentVisitor()
            : this(true) {
        }

        internal TSqlFragmentVisitor(bool visitBaseType) {
            this._visitBaseType = visitBaseType;
        }

        public virtual void Start<T>(T node) { }

        public virtual void Done<T>(T node) { }

        public virtual void Visit(TSqlFragment fragment) {
        }

        public virtual void Visit(StatementList node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(StatementList node) {
            this.Start<StatementList>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<StatementList>(node);
        }

        public virtual void Visit(ExecuteStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExecuteStatement node) {
            this.Start<ExecuteStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExecuteStatement>(node);
        }

        public virtual void Visit(ExecuteOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExecuteOption node) {
            this.Start<ExecuteOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExecuteOption>(node);
        }

        public virtual void Visit(ResultSetsExecuteOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ResultSetsExecuteOption node) {
            this.Start<ResultSetsExecuteOption>(node);
            if (this._visitBaseType) {
                this.Visit((ExecuteOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ResultSetsExecuteOption>(node);
        }

        public virtual void Visit(ResultSetDefinition node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ResultSetDefinition node) {
            this.Start<ResultSetDefinition>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ResultSetDefinition>(node);
        }

        public virtual void Visit(InlineResultSetDefinition node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(InlineResultSetDefinition node) {
            this.Start<InlineResultSetDefinition>(node);
            if (this._visitBaseType) {
                this.Visit((ResultSetDefinition)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<InlineResultSetDefinition>(node);
        }

        public virtual void Visit(ResultColumnDefinition node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ResultColumnDefinition node) {
            this.Start<ResultColumnDefinition>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ResultColumnDefinition>(node);
        }

        public virtual void Visit(SchemaObjectResultSetDefinition node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SchemaObjectResultSetDefinition node) {
            this.Start<SchemaObjectResultSetDefinition>(node);
            if (this._visitBaseType) {
                this.Visit((ResultSetDefinition)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SchemaObjectResultSetDefinition>(node);
        }

        public virtual void Visit(ExecuteSpecification node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExecuteSpecification node) {
            this.Start<ExecuteSpecification>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExecuteSpecification>(node);
        }

        public virtual void Visit(ExecuteContext node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExecuteContext node) {
            this.Start<ExecuteContext>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExecuteContext>(node);
        }

        public virtual void Visit(ExecuteParameter node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExecuteParameter node) {
            this.Start<ExecuteParameter>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExecuteParameter>(node);
        }

        public virtual void Visit(ExecutableEntity node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExecutableEntity node) {
            this.Start<ExecutableEntity>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExecutableEntity>(node);
        }

        public virtual void Visit(ProcedureReferenceName node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ProcedureReferenceName node) {
            this.Start<ProcedureReferenceName>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ProcedureReferenceName>(node);
        }

        public virtual void Visit(ExecutableProcedureReference node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExecutableProcedureReference node) {
            this.Start<ExecutableProcedureReference>(node);
            if (this._visitBaseType) {
                this.Visit((ExecutableEntity)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExecutableProcedureReference>(node);
        }

        public virtual void Visit(ExecutableStringList node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExecutableStringList node) {
            this.Start<ExecutableStringList>(node);
            if (this._visitBaseType) {
                this.Visit((ExecutableEntity)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExecutableStringList>(node);
        }

        public virtual void Visit(AdHocDataSource node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AdHocDataSource node) {
            this.Start<AdHocDataSource>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AdHocDataSource>(node);
        }

        public virtual void Visit(ViewOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ViewOption node) {
            this.Start<ViewOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ViewOption>(node);
        }

        public virtual void Visit(AlterViewStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterViewStatement node) {
            this.Start<AlterViewStatement>(node);
            if (this._visitBaseType) {
                this.Visit((ViewStatementBody)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterViewStatement>(node);
        }

        public virtual void Visit(CreateViewStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateViewStatement node) {
            this.Start<CreateViewStatement>(node);
            if (this._visitBaseType) {
                this.Visit((ViewStatementBody)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateViewStatement>(node);
        }

        public virtual void Visit(CreateOrAlterViewStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateOrAlterViewStatement node) {
            this.Start<CreateOrAlterViewStatement>(node);
            if (this._visitBaseType) {
                this.Visit((ViewStatementBody)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateOrAlterViewStatement>(node);
        }

        public virtual void Visit(ViewStatementBody node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ViewStatementBody node) {
            this.Start<ViewStatementBody>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ViewStatementBody>(node);
        }

        public virtual void Visit(TriggerObject node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TriggerObject node) {
            this.Start<TriggerObject>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TriggerObject>(node);
        }

        public virtual void Visit(TriggerOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TriggerOption node) {
            this.Start<TriggerOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TriggerOption>(node);
        }

        public virtual void Visit(ExecuteAsTriggerOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExecuteAsTriggerOption node) {
            this.Start<ExecuteAsTriggerOption>(node);
            if (this._visitBaseType) {
                this.Visit((TriggerOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExecuteAsTriggerOption>(node);
        }

        public virtual void Visit(TriggerAction node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TriggerAction node) {
            this.Start<TriggerAction>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TriggerAction>(node);
        }

        public virtual void Visit(AlterTriggerStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterTriggerStatement node) {
            this.Start<AlterTriggerStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TriggerStatementBody)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterTriggerStatement>(node);
        }

        public virtual void Visit(CreateTriggerStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateTriggerStatement node) {
            this.Start<CreateTriggerStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TriggerStatementBody)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateTriggerStatement>(node);
        }

        public virtual void Visit(CreateOrAlterTriggerStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateOrAlterTriggerStatement node) {
            this.Start<CreateOrAlterTriggerStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TriggerStatementBody)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateOrAlterTriggerStatement>(node);
        }

        public virtual void Visit(TriggerStatementBody node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TriggerStatementBody node) {
            this.Start<TriggerStatementBody>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TriggerStatementBody>(node);
        }

        public virtual void Visit(Identifier node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(Identifier node) {
            this.Start<Identifier>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<Identifier>(node);
        }

        public virtual void Visit(AlterProcedureStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterProcedureStatement node) {
            this.Start<AlterProcedureStatement>(node);
            if (this._visitBaseType) {
                this.Visit((ProcedureStatementBody)node);
                this.Visit((ProcedureStatementBodyBase)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterProcedureStatement>(node);
        }

        public virtual void Visit(CreateProcedureStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateProcedureStatement node) {
            this.Start<CreateProcedureStatement>(node);
            if (this._visitBaseType) {
                this.Visit((ProcedureStatementBody)node);
                this.Visit((ProcedureStatementBodyBase)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateProcedureStatement>(node);
        }

        public virtual void Visit(CreateOrAlterProcedureStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateOrAlterProcedureStatement node) {
            this.Start<CreateOrAlterProcedureStatement>(node);
            if (this._visitBaseType) {
                this.Visit((ProcedureStatementBody)node);
                this.Visit((ProcedureStatementBodyBase)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateOrAlterProcedureStatement>(node);
        }

        public virtual void Visit(ProcedureReference node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ProcedureReference node) {
            this.Start<ProcedureReference>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ProcedureReference>(node);
        }

        public virtual void Visit(MethodSpecifier node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(MethodSpecifier node) {
            this.Start<MethodSpecifier>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<MethodSpecifier>(node);
        }

        public virtual void Visit(ProcedureStatementBody node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ProcedureStatementBody node) {
            this.Start<ProcedureStatementBody>(node);
            if (this._visitBaseType) {
                this.Visit((ProcedureStatementBodyBase)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ProcedureStatementBody>(node);
        }

        public virtual void Visit(ProcedureStatementBodyBase node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ProcedureStatementBodyBase node) {
            this.Start<ProcedureStatementBodyBase>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ProcedureStatementBodyBase>(node);
        }

        public virtual void Visit(FunctionStatementBody node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FunctionStatementBody node) {
            this.Start<FunctionStatementBody>(node);
            if (this._visitBaseType) {
                this.Visit((ProcedureStatementBodyBase)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FunctionStatementBody>(node);
        }

        public virtual void Visit(ProcedureOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ProcedureOption node) {
            this.Start<ProcedureOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ProcedureOption>(node);
        }

        public virtual void Visit(ExecuteAsProcedureOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExecuteAsProcedureOption node) {
            this.Start<ExecuteAsProcedureOption>(node);
            if (this._visitBaseType) {
                this.Visit((ProcedureOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExecuteAsProcedureOption>(node);
        }

        public virtual void Visit(FunctionOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FunctionOption node) {
            this.Start<FunctionOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FunctionOption>(node);
        }

        public virtual void Visit(ExecuteAsFunctionOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExecuteAsFunctionOption node) {
            this.Start<ExecuteAsFunctionOption>(node);
            if (this._visitBaseType) {
                this.Visit((FunctionOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExecuteAsFunctionOption>(node);
        }

        public virtual void Visit(XmlNamespaces node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(XmlNamespaces node) {
            this.Start<XmlNamespaces>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<XmlNamespaces>(node);
        }

        public virtual void Visit(XmlNamespacesElement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(XmlNamespacesElement node) {
            this.Start<XmlNamespacesElement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<XmlNamespacesElement>(node);
        }

        public virtual void Visit(XmlNamespacesDefaultElement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(XmlNamespacesDefaultElement node) {
            this.Start<XmlNamespacesDefaultElement>(node);
            if (this._visitBaseType) {
                this.Visit((XmlNamespacesElement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<XmlNamespacesDefaultElement>(node);
        }

        public virtual void Visit(XmlNamespacesAliasElement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(XmlNamespacesAliasElement node) {
            this.Start<XmlNamespacesAliasElement>(node);
            if (this._visitBaseType) {
                this.Visit((XmlNamespacesElement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<XmlNamespacesAliasElement>(node);
        }

        public virtual void Visit(CommonTableExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CommonTableExpression node) {
            this.Start<CommonTableExpression>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CommonTableExpression>(node);
        }

        public virtual void Visit(WithCtesAndXmlNamespaces node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(WithCtesAndXmlNamespaces node) {
            this.Start<WithCtesAndXmlNamespaces>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<WithCtesAndXmlNamespaces>(node);
        }

        public virtual void Visit(FunctionReturnType node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FunctionReturnType node) {
            this.Start<FunctionReturnType>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FunctionReturnType>(node);
        }

        public virtual void Visit(TableValuedFunctionReturnType node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TableValuedFunctionReturnType node) {
            this.Start<TableValuedFunctionReturnType>(node);
            if (this._visitBaseType) {
                this.Visit((FunctionReturnType)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TableValuedFunctionReturnType>(node);
        }

        public virtual void Visit(DataTypeReference node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DataTypeReference node) {
            this.Start<DataTypeReference>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DataTypeReference>(node);
        }

        public virtual void Visit(ParameterizedDataTypeReference node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ParameterizedDataTypeReference node) {
            this.Start<ParameterizedDataTypeReference>(node);
            if (this._visitBaseType) {
                this.Visit((DataTypeReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ParameterizedDataTypeReference>(node);
        }

        public virtual void Visit(SqlDataTypeReference node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SqlDataTypeReference node) {
            this.Start<SqlDataTypeReference>(node);
            if (this._visitBaseType) {
                this.Visit((ParameterizedDataTypeReference)node);
                this.Visit((DataTypeReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SqlDataTypeReference>(node);
        }

        public virtual void Visit(UserDataTypeReference node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(UserDataTypeReference node) {
            this.Start<UserDataTypeReference>(node);
            if (this._visitBaseType) {
                this.Visit((ParameterizedDataTypeReference)node);
                this.Visit((DataTypeReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<UserDataTypeReference>(node);
        }

        public virtual void Visit(XmlDataTypeReference node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(XmlDataTypeReference node) {
            this.Start<XmlDataTypeReference>(node);
            if (this._visitBaseType) {
                this.Visit((DataTypeReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<XmlDataTypeReference>(node);
        }

        public virtual void Visit(ScalarFunctionReturnType node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ScalarFunctionReturnType node) {
            this.Start<ScalarFunctionReturnType>(node);
            if (this._visitBaseType) {
                this.Visit((FunctionReturnType)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ScalarFunctionReturnType>(node);
        }

        public virtual void Visit(SelectFunctionReturnType node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SelectFunctionReturnType node) {
            this.Start<SelectFunctionReturnType>(node);
            if (this._visitBaseType) {
                this.Visit((FunctionReturnType)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SelectFunctionReturnType>(node);
        }

        public virtual void Visit(TableDefinition node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TableDefinition node) {
            this.Start<TableDefinition>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TableDefinition>(node);
        }

        public virtual void Visit(DeclareTableVariableBody node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DeclareTableVariableBody node) {
            this.Start<DeclareTableVariableBody>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DeclareTableVariableBody>(node);
        }

        public virtual void Visit(DeclareTableVariableStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DeclareTableVariableStatement node) {
            this.Start<DeclareTableVariableStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DeclareTableVariableStatement>(node);
        }

        public virtual void Visit(NamedTableReference node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(NamedTableReference node) {
            this.Start<NamedTableReference>(node);
            if (this._visitBaseType) {
                this.Visit((TableReferenceWithAlias)node);
                this.Visit((TableReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<NamedTableReference>(node);
        }

        public virtual void Visit(SchemaObjectFunctionTableReference node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SchemaObjectFunctionTableReference node) {
            this.Start<SchemaObjectFunctionTableReference>(node);
            if (this._visitBaseType) {
                this.Visit((TableReferenceWithAliasAndColumns)node);
                this.Visit((TableReferenceWithAlias)node);
                this.Visit((TableReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SchemaObjectFunctionTableReference>(node);
        }

        public virtual void Visit(TableHint node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TableHint node) {
            this.Start<TableHint>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TableHint>(node);
        }

        public virtual void Visit(IndexTableHint node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(IndexTableHint node) {
            this.Start<IndexTableHint>(node);
            if (this._visitBaseType) {
                this.Visit((TableHint)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<IndexTableHint>(node);
        }

        public virtual void Visit(LiteralTableHint node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(LiteralTableHint node) {
            this.Start<LiteralTableHint>(node);
            if (this._visitBaseType) {
                this.Visit((TableHint)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<LiteralTableHint>(node);
        }

        public virtual void Visit(QueryDerivedTable node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(QueryDerivedTable node) {
            this.Start<QueryDerivedTable>(node);
            if (this._visitBaseType) {
                this.Visit((TableReferenceWithAliasAndColumns)node);
                this.Visit((TableReferenceWithAlias)node);
                this.Visit((TableReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<QueryDerivedTable>(node);
        }

        public virtual void Visit(InlineDerivedTable node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(InlineDerivedTable node) {
            this.Start<InlineDerivedTable>(node);
            if (this._visitBaseType) {
                this.Visit((TableReferenceWithAliasAndColumns)node);
                this.Visit((TableReferenceWithAlias)node);
                this.Visit((TableReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<InlineDerivedTable>(node);
        }

        public virtual void Visit(SubqueryComparisonPredicate node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SubqueryComparisonPredicate node) {
            this.Start<SubqueryComparisonPredicate>(node);
            if (this._visitBaseType) {
                this.Visit((BooleanExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SubqueryComparisonPredicate>(node);
        }

        public virtual void Visit(ExistsPredicate node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExistsPredicate node) {
            this.Start<ExistsPredicate>(node);
            if (this._visitBaseType) {
                this.Visit((BooleanExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExistsPredicate>(node);
        }

        public virtual void Visit(LikePredicate node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(LikePredicate node) {
            this.Start<LikePredicate>(node);
            if (this._visitBaseType) {
                this.Visit((BooleanExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<LikePredicate>(node);
        }

        public virtual void Visit(InPredicate node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(InPredicate node) {
            this.Start<InPredicate>(node);
            if (this._visitBaseType) {
                this.Visit((BooleanExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<InPredicate>(node);
        }

        public virtual void Visit(FullTextPredicate node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FullTextPredicate node) {
            this.Start<FullTextPredicate>(node);
            if (this._visitBaseType) {
                this.Visit((BooleanExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FullTextPredicate>(node);
        }

        public virtual void Visit(UserDefinedTypePropertyAccess node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(UserDefinedTypePropertyAccess node) {
            this.Start<UserDefinedTypePropertyAccess>(node);
            if (this._visitBaseType) {
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<UserDefinedTypePropertyAccess>(node);
        }

        public virtual void Visit(StatementWithCtesAndXmlNamespaces node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(StatementWithCtesAndXmlNamespaces node) {
            this.Start<StatementWithCtesAndXmlNamespaces>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<StatementWithCtesAndXmlNamespaces>(node);
        }

        public virtual void Visit(SelectStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SelectStatement node) {
            this.Start<SelectStatement>(node);
            if (this._visitBaseType) {
                this.Visit((StatementWithCtesAndXmlNamespaces)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SelectStatement>(node);
        }

        public virtual void Visit(ForClause node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ForClause node) {
            this.Start<ForClause>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ForClause>(node);
        }

        public virtual void Visit(BrowseForClause node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BrowseForClause node) {
            this.Start<BrowseForClause>(node);
            if (this._visitBaseType) {
                this.Visit((ForClause)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BrowseForClause>(node);
        }

        public virtual void Visit(ReadOnlyForClause node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ReadOnlyForClause node) {
            this.Start<ReadOnlyForClause>(node);
            if (this._visitBaseType) {
                this.Visit((ForClause)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ReadOnlyForClause>(node);
        }

        public virtual void Visit(XmlForClause node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(XmlForClause node) {
            this.Start<XmlForClause>(node);
            if (this._visitBaseType) {
                this.Visit((ForClause)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<XmlForClause>(node);
        }

        public virtual void Visit(XmlForClauseOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(XmlForClauseOption node) {
            this.Start<XmlForClauseOption>(node);
            if (this._visitBaseType) {
                this.Visit((ForClause)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<XmlForClauseOption>(node);
        }

        public virtual void Visit(JsonForClause node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(JsonForClause node) {
            this.Start<JsonForClause>(node);
            if (this._visitBaseType) {
                this.Visit((ForClause)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<JsonForClause>(node);
        }

        public virtual void Visit(JsonForClauseOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(JsonForClauseOption node) {
            this.Start<JsonForClauseOption>(node);
            if (this._visitBaseType) {
                this.Visit((ForClause)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<JsonForClauseOption>(node);
        }

        public virtual void Visit(UpdateForClause node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(UpdateForClause node) {
            this.Start<UpdateForClause>(node);
            if (this._visitBaseType) {
                this.Visit((ForClause)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<UpdateForClause>(node);
        }

        public virtual void Visit(OptimizerHint node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OptimizerHint node) {
            this.Start<OptimizerHint>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OptimizerHint>(node);
        }

        public virtual void Visit(LiteralOptimizerHint node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(LiteralOptimizerHint node) {
            this.Start<LiteralOptimizerHint>(node);
            if (this._visitBaseType) {
                this.Visit((OptimizerHint)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<LiteralOptimizerHint>(node);
        }

        public virtual void Visit(TableHintsOptimizerHint node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TableHintsOptimizerHint node) {
            this.Start<TableHintsOptimizerHint>(node);
            if (this._visitBaseType) {
                this.Visit((OptimizerHint)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TableHintsOptimizerHint>(node);
        }

        public virtual void Visit(ForceSeekTableHint node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ForceSeekTableHint node) {
            this.Start<ForceSeekTableHint>(node);
            if (this._visitBaseType) {
                this.Visit((TableHint)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ForceSeekTableHint>(node);
        }

        public virtual void Visit(OptimizeForOptimizerHint node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OptimizeForOptimizerHint node) {
            this.Start<OptimizeForOptimizerHint>(node);
            if (this._visitBaseType) {
                this.Visit((OptimizerHint)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OptimizeForOptimizerHint>(node);
        }

        public virtual void Visit(UseHintList node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(UseHintList node) {
            this.Start<UseHintList>(node);
            if (this._visitBaseType) {
                this.Visit((OptimizerHint)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<UseHintList>(node);
        }

        public virtual void Visit(VariableValuePair node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(VariableValuePair node) {
            this.Start<VariableValuePair>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<VariableValuePair>(node);
        }

        public virtual void Visit(WhenClause node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(WhenClause node) {
            this.Start<WhenClause>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<WhenClause>(node);
        }

        public virtual void Visit(SimpleWhenClause node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SimpleWhenClause node) {
            this.Start<SimpleWhenClause>(node);
            if (this._visitBaseType) {
                this.Visit((WhenClause)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SimpleWhenClause>(node);
        }

        public virtual void Visit(SearchedWhenClause node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SearchedWhenClause node) {
            this.Start<SearchedWhenClause>(node);
            if (this._visitBaseType) {
                this.Visit((WhenClause)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SearchedWhenClause>(node);
        }

        public virtual void Visit(CaseExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CaseExpression node) {
            this.Start<CaseExpression>(node);
            if (this._visitBaseType) {
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CaseExpression>(node);
        }

        public virtual void Visit(SimpleCaseExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SimpleCaseExpression node) {
            this.Start<SimpleCaseExpression>(node);
            if (this._visitBaseType) {
                this.Visit((CaseExpression)node);
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SimpleCaseExpression>(node);
        }

        public virtual void Visit(SearchedCaseExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SearchedCaseExpression node) {
            this.Start<SearchedCaseExpression>(node);
            if (this._visitBaseType) {
                this.Visit((CaseExpression)node);
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SearchedCaseExpression>(node);
        }

        public virtual void Visit(NullIfExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(NullIfExpression node) {
            this.Start<NullIfExpression>(node);
            if (this._visitBaseType) {
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<NullIfExpression>(node);
        }

        public virtual void Visit(CoalesceExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CoalesceExpression node) {
            this.Start<CoalesceExpression>(node);
            if (this._visitBaseType) {
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CoalesceExpression>(node);
        }

        public virtual void Visit(IIfCall node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(IIfCall node) {
            this.Start<IIfCall>(node);
            if (this._visitBaseType) {
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<IIfCall>(node);
        }

        public virtual void Visit(FullTextTableReference node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FullTextTableReference node) {
            this.Start<FullTextTableReference>(node);
            if (this._visitBaseType) {
                this.Visit((TableReferenceWithAlias)node);
                this.Visit((TableReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FullTextTableReference>(node);
        }

        public virtual void Visit(SemanticTableReference node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SemanticTableReference node) {
            this.Start<SemanticTableReference>(node);
            if (this._visitBaseType) {
                this.Visit((TableReferenceWithAlias)node);
                this.Visit((TableReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SemanticTableReference>(node);
        }

        public virtual void Visit(OpenXmlTableReference node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OpenXmlTableReference node) {
            this.Start<OpenXmlTableReference>(node);
            if (this._visitBaseType) {
                this.Visit((TableReferenceWithAlias)node);
                this.Visit((TableReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OpenXmlTableReference>(node);
        }

        public virtual void Visit(OpenJsonTableReference node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OpenJsonTableReference node) {
            this.Start<OpenJsonTableReference>(node);
            if (this._visitBaseType) {
                this.Visit((TableReferenceWithAlias)node);
                this.Visit((TableReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OpenJsonTableReference>(node);
        }

        public virtual void Visit(OpenRowsetTableReference node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OpenRowsetTableReference node) {
            this.Start<OpenRowsetTableReference>(node);
            if (this._visitBaseType) {
                this.Visit((TableReferenceWithAlias)node);
                this.Visit((TableReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OpenRowsetTableReference>(node);
        }

        public virtual void Visit(InternalOpenRowset node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(InternalOpenRowset node) {
            this.Start<InternalOpenRowset>(node);
            if (this._visitBaseType) {
                this.Visit((TableReferenceWithAlias)node);
                this.Visit((TableReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<InternalOpenRowset>(node);
        }

        public virtual void Visit(BulkOpenRowset node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BulkOpenRowset node) {
            this.Start<BulkOpenRowset>(node);
            if (this._visitBaseType) {
                this.Visit((TableReferenceWithAliasAndColumns)node);
                this.Visit((TableReferenceWithAlias)node);
                this.Visit((TableReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BulkOpenRowset>(node);
        }

        public virtual void Visit(OpenQueryTableReference node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OpenQueryTableReference node) {
            this.Start<OpenQueryTableReference>(node);
            if (this._visitBaseType) {
                this.Visit((TableReferenceWithAlias)node);
                this.Visit((TableReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OpenQueryTableReference>(node);
        }

        public virtual void Visit(AdHocTableReference node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AdHocTableReference node) {
            this.Start<AdHocTableReference>(node);
            if (this._visitBaseType) {
                this.Visit((TableReferenceWithAlias)node);
                this.Visit((TableReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AdHocTableReference>(node);
        }

        public virtual void Visit(SchemaDeclarationItem node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SchemaDeclarationItem node) {
            this.Start<SchemaDeclarationItem>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SchemaDeclarationItem>(node);
        }

        public virtual void Visit(SchemaDeclarationItemOpenjson node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SchemaDeclarationItemOpenjson node) {
            this.Start<SchemaDeclarationItemOpenjson>(node);
            if (this._visitBaseType) {
                this.Visit((SchemaDeclarationItem)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SchemaDeclarationItemOpenjson>(node);
        }

        public virtual void Visit(ConvertCall node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ConvertCall node) {
            this.Start<ConvertCall>(node);
            if (this._visitBaseType) {
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ConvertCall>(node);
        }

        public virtual void Visit(TryConvertCall node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TryConvertCall node) {
            this.Start<TryConvertCall>(node);
            if (this._visitBaseType) {
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TryConvertCall>(node);
        }

        public virtual void Visit(ParseCall node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ParseCall node) {
            this.Start<ParseCall>(node);
            if (this._visitBaseType) {
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ParseCall>(node);
        }

        public virtual void Visit(TryParseCall node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TryParseCall node) {
            this.Start<TryParseCall>(node);
            if (this._visitBaseType) {
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TryParseCall>(node);
        }

        public virtual void Visit(CastCall node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CastCall node) {
            this.Start<CastCall>(node);
            if (this._visitBaseType) {
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CastCall>(node);
        }

        public virtual void Visit(TryCastCall node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TryCastCall node) {
            this.Start<TryCastCall>(node);
            if (this._visitBaseType) {
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TryCastCall>(node);
        }

        public virtual void Visit(AtTimeZoneCall node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AtTimeZoneCall node) {
            this.Start<AtTimeZoneCall>(node);
            if (this._visitBaseType) {
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AtTimeZoneCall>(node);
        }

        public virtual void Visit(FunctionCall node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FunctionCall node) {
            this.Start<FunctionCall>(node);
            if (this._visitBaseType) {
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FunctionCall>(node);
        }

        public virtual void Visit(CallTarget node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CallTarget node) {
            this.Start<CallTarget>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CallTarget>(node);
        }

        public virtual void Visit(ExpressionCallTarget node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExpressionCallTarget node) {
            this.Start<ExpressionCallTarget>(node);
            if (this._visitBaseType) {
                this.Visit((CallTarget)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExpressionCallTarget>(node);
        }

        public virtual void Visit(MultiPartIdentifierCallTarget node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(MultiPartIdentifierCallTarget node) {
            this.Start<MultiPartIdentifierCallTarget>(node);
            if (this._visitBaseType) {
                this.Visit((CallTarget)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<MultiPartIdentifierCallTarget>(node);
        }

        public virtual void Visit(UserDefinedTypeCallTarget node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(UserDefinedTypeCallTarget node) {
            this.Start<UserDefinedTypeCallTarget>(node);
            if (this._visitBaseType) {
                this.Visit((CallTarget)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<UserDefinedTypeCallTarget>(node);
        }

        public virtual void Visit(LeftFunctionCall node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(LeftFunctionCall node) {
            this.Start<LeftFunctionCall>(node);
            if (this._visitBaseType) {
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<LeftFunctionCall>(node);
        }

        public virtual void Visit(RightFunctionCall node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(RightFunctionCall node) {
            this.Start<RightFunctionCall>(node);
            if (this._visitBaseType) {
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<RightFunctionCall>(node);
        }

        public virtual void Visit(PartitionFunctionCall node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(PartitionFunctionCall node) {
            this.Start<PartitionFunctionCall>(node);
            if (this._visitBaseType) {
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<PartitionFunctionCall>(node);
        }

        public virtual void Visit(OverClause node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OverClause node) {
            this.Start<OverClause>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OverClause>(node);
        }

        public virtual void Visit(ParameterlessCall node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ParameterlessCall node) {
            this.Start<ParameterlessCall>(node);
            if (this._visitBaseType) {
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ParameterlessCall>(node);
        }

        public virtual void Visit(ScalarSubquery node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ScalarSubquery node) {
            this.Start<ScalarSubquery>(node);
            if (this._visitBaseType) {
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ScalarSubquery>(node);
        }

        public virtual void Visit(OdbcFunctionCall node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OdbcFunctionCall node) {
            this.Start<OdbcFunctionCall>(node);
            if (this._visitBaseType) {
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OdbcFunctionCall>(node);
        }

        public virtual void Visit(ExtractFromExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExtractFromExpression node) {
            this.Start<ExtractFromExpression>(node);
            if (this._visitBaseType) {
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExtractFromExpression>(node);
        }

        public virtual void Visit(OdbcConvertSpecification node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OdbcConvertSpecification node) {
            this.Start<OdbcConvertSpecification>(node);
            if (this._visitBaseType) {
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OdbcConvertSpecification>(node);
        }

        public virtual void Visit(AlterFunctionStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterFunctionStatement node) {
            this.Start<AlterFunctionStatement>(node);
            if (this._visitBaseType) {
                this.Visit((FunctionStatementBody)node);
                this.Visit((ProcedureStatementBodyBase)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterFunctionStatement>(node);
        }

        public virtual void Visit(BeginEndBlockStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BeginEndBlockStatement node) {
            this.Start<BeginEndBlockStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BeginEndBlockStatement>(node);
        }

        public virtual void Visit(BeginEndAtomicBlockStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BeginEndAtomicBlockStatement node) {
            this.Start<BeginEndAtomicBlockStatement>(node);
            if (this._visitBaseType) {
                this.Visit((BeginEndBlockStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BeginEndAtomicBlockStatement>(node);
        }

        public virtual void Visit(AtomicBlockOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AtomicBlockOption node) {
            this.Start<AtomicBlockOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AtomicBlockOption>(node);
        }

        public virtual void Visit(LiteralAtomicBlockOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(LiteralAtomicBlockOption node) {
            this.Start<LiteralAtomicBlockOption>(node);
            if (this._visitBaseType) {
                this.Visit((AtomicBlockOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<LiteralAtomicBlockOption>(node);
        }

        public virtual void Visit(IdentifierAtomicBlockOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(IdentifierAtomicBlockOption node) {
            this.Start<IdentifierAtomicBlockOption>(node);
            if (this._visitBaseType) {
                this.Visit((AtomicBlockOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<IdentifierAtomicBlockOption>(node);
        }

        public virtual void Visit(OnOffAtomicBlockOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OnOffAtomicBlockOption node) {
            this.Start<OnOffAtomicBlockOption>(node);
            if (this._visitBaseType) {
                this.Visit((AtomicBlockOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OnOffAtomicBlockOption>(node);
        }

        public virtual void Visit(BeginTransactionStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BeginTransactionStatement node) {
            this.Start<BeginTransactionStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TransactionStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BeginTransactionStatement>(node);
        }

        public virtual void Visit(BreakStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BreakStatement node) {
            this.Start<BreakStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BreakStatement>(node);
        }

        public virtual void Visit(ColumnWithSortOrder node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ColumnWithSortOrder node) {
            this.Start<ColumnWithSortOrder>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ColumnWithSortOrder>(node);
        }

        public virtual void Visit(CommitTransactionStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CommitTransactionStatement node) {
            this.Start<CommitTransactionStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TransactionStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CommitTransactionStatement>(node);
        }

        public virtual void Visit(RollbackTransactionStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(RollbackTransactionStatement node) {
            this.Start<RollbackTransactionStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TransactionStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<RollbackTransactionStatement>(node);
        }

        public virtual void Visit(SaveTransactionStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SaveTransactionStatement node) {
            this.Start<SaveTransactionStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TransactionStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SaveTransactionStatement>(node);
        }

        public virtual void Visit(ContinueStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ContinueStatement node) {
            this.Start<ContinueStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ContinueStatement>(node);
        }

        public virtual void Visit(CreateDefaultStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateDefaultStatement node) {
            this.Start<CreateDefaultStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateDefaultStatement>(node);
        }

        public virtual void Visit(CreateFunctionStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateFunctionStatement node) {
            this.Start<CreateFunctionStatement>(node);
            if (this._visitBaseType) {
                this.Visit((FunctionStatementBody)node);
                this.Visit((ProcedureStatementBodyBase)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateFunctionStatement>(node);
        }

        public virtual void Visit(CreateOrAlterFunctionStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateOrAlterFunctionStatement node) {
            this.Start<CreateOrAlterFunctionStatement>(node);
            if (this._visitBaseType) {
                this.Visit((FunctionStatementBody)node);
                this.Visit((ProcedureStatementBodyBase)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateOrAlterFunctionStatement>(node);
        }

        public virtual void Visit(CreateRuleStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateRuleStatement node) {
            this.Start<CreateRuleStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateRuleStatement>(node);
        }

        public virtual void Visit(DeclareVariableElement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DeclareVariableElement node) {
            this.Start<DeclareVariableElement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DeclareVariableElement>(node);
        }

        public virtual void Visit(DeclareVariableStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DeclareVariableStatement node) {
            this.Start<DeclareVariableStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DeclareVariableStatement>(node);
        }

        public virtual void Visit(GoToStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(GoToStatement node) {
            this.Start<GoToStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<GoToStatement>(node);
        }

        public virtual void Visit(IfStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(IfStatement node) {
            this.Start<IfStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<IfStatement>(node);
        }

        public virtual void Visit(LabelStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(LabelStatement node) {
            this.Start<LabelStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<LabelStatement>(node);
        }

        public virtual void Visit(MultiPartIdentifier node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(MultiPartIdentifier node) {
            this.Start<MultiPartIdentifier>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<MultiPartIdentifier>(node);
        }

        public virtual void Visit(SchemaObjectName node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SchemaObjectName node) {
            this.Start<SchemaObjectName>(node);
            if (this._visitBaseType) {
                this.Visit((MultiPartIdentifier)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SchemaObjectName>(node);
        }

        public virtual void Visit(ChildObjectName node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ChildObjectName node) {
            this.Start<ChildObjectName>(node);
            if (this._visitBaseType) {
                this.Visit((SchemaObjectName)node);
                this.Visit((MultiPartIdentifier)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ChildObjectName>(node);
        }

        public virtual void Visit(ProcedureParameter node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ProcedureParameter node) {
            this.Start<ProcedureParameter>(node);
            if (this._visitBaseType) {
                this.Visit((DeclareVariableElement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ProcedureParameter>(node);
        }

        public virtual void Visit(TransactionStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TransactionStatement node) {
            this.Start<TransactionStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TransactionStatement>(node);
        }

        public virtual void Visit(WhileStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(WhileStatement node) {
            this.Start<WhileStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<WhileStatement>(node);
        }

        public virtual void Visit(DeleteStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DeleteStatement node) {
            this.Start<DeleteStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DataModificationStatement)node);
                this.Visit((StatementWithCtesAndXmlNamespaces)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DeleteStatement>(node);
        }

        public virtual void Visit(UpdateDeleteSpecificationBase node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(UpdateDeleteSpecificationBase node) {
            this.Start<UpdateDeleteSpecificationBase>(node);
            if (this._visitBaseType) {
                this.Visit((DataModificationSpecification)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<UpdateDeleteSpecificationBase>(node);
        }

        public virtual void Visit(DeleteSpecification node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DeleteSpecification node) {
            this.Start<DeleteSpecification>(node);
            if (this._visitBaseType) {
                this.Visit((UpdateDeleteSpecificationBase)node);
                this.Visit((DataModificationSpecification)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DeleteSpecification>(node);
        }

        public virtual void Visit(InsertStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(InsertStatement node) {
            this.Start<InsertStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DataModificationStatement)node);
                this.Visit((StatementWithCtesAndXmlNamespaces)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<InsertStatement>(node);
        }

        public virtual void Visit(InsertSpecification node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(InsertSpecification node) {
            this.Start<InsertSpecification>(node);
            if (this._visitBaseType) {
                this.Visit((DataModificationSpecification)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<InsertSpecification>(node);
        }

        public virtual void Visit(UpdateStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(UpdateStatement node) {
            this.Start<UpdateStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DataModificationStatement)node);
                this.Visit((StatementWithCtesAndXmlNamespaces)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<UpdateStatement>(node);
        }

        public virtual void Visit(UpdateSpecification node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(UpdateSpecification node) {
            this.Start<UpdateSpecification>(node);
            if (this._visitBaseType) {
                this.Visit((UpdateDeleteSpecificationBase)node);
                this.Visit((DataModificationSpecification)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<UpdateSpecification>(node);
        }

        public virtual void Visit(CreateSchemaStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateSchemaStatement node) {
            this.Start<CreateSchemaStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateSchemaStatement>(node);
        }

        public virtual void Visit(WaitForStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(WaitForStatement node) {
            this.Start<WaitForStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<WaitForStatement>(node);
        }

        public virtual void Visit(ReadTextStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ReadTextStatement node) {
            this.Start<ReadTextStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ReadTextStatement>(node);
        }

        public virtual void Visit(UpdateTextStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(UpdateTextStatement node) {
            this.Start<UpdateTextStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TextModificationStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<UpdateTextStatement>(node);
        }

        public virtual void Visit(WriteTextStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(WriteTextStatement node) {
            this.Start<WriteTextStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TextModificationStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<WriteTextStatement>(node);
        }

        public virtual void Visit(TextModificationStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TextModificationStatement node) {
            this.Start<TextModificationStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TextModificationStatement>(node);
        }

        public virtual void Visit(LineNoStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(LineNoStatement node) {
            this.Start<LineNoStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<LineNoStatement>(node);
        }

        public virtual void Visit(SecurityStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SecurityStatement node) {
            this.Start<SecurityStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SecurityStatement>(node);
        }

        public virtual void Visit(GrantStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(GrantStatement node) {
            this.Start<GrantStatement>(node);
            if (this._visitBaseType) {
                this.Visit((SecurityStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<GrantStatement>(node);
        }

        public virtual void Visit(DenyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DenyStatement node) {
            this.Start<DenyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((SecurityStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DenyStatement>(node);
        }

        public virtual void Visit(RevokeStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(RevokeStatement node) {
            this.Start<RevokeStatement>(node);
            if (this._visitBaseType) {
                this.Visit((SecurityStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<RevokeStatement>(node);
        }

        public virtual void Visit(AlterAuthorizationStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterAuthorizationStatement node) {
            this.Start<AlterAuthorizationStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterAuthorizationStatement>(node);
        }

        public virtual void Visit(Permission node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(Permission node) {
            this.Start<Permission>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<Permission>(node);
        }

        public virtual void Visit(SecurityTargetObject node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SecurityTargetObject node) {
            this.Start<SecurityTargetObject>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SecurityTargetObject>(node);
        }

        public virtual void Visit(SecurityTargetObjectName node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SecurityTargetObjectName node) {
            this.Start<SecurityTargetObjectName>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SecurityTargetObjectName>(node);
        }

        public virtual void Visit(SecurityPrincipal node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SecurityPrincipal node) {
            this.Start<SecurityPrincipal>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SecurityPrincipal>(node);
        }

        public virtual void Visit(SecurityStatementBody80 node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SecurityStatementBody80 node) {
            this.Start<SecurityStatementBody80>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SecurityStatementBody80>(node);
        }

        public virtual void Visit(GrantStatement80 node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(GrantStatement80 node) {
            if (this._visitBaseType) {
                this.Visit((SecurityStatementBody80)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
        }

        public virtual void Visit(DenyStatement80 node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DenyStatement80 node) {
            if (this._visitBaseType) {
                this.Visit((SecurityStatementBody80)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
        }

        public virtual void Visit(RevokeStatement80 node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(RevokeStatement80 node) {
            if (this._visitBaseType) {
                this.Visit((SecurityStatementBody80)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
        }

        public virtual void Visit(SecurityElement80 node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SecurityElement80 node) {
            this.Start<SecurityElement80>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SecurityElement80>(node);
        }

        public virtual void Visit(CommandSecurityElement80 node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CommandSecurityElement80 node) {
            if (this._visitBaseType) {
                this.Visit((SecurityElement80)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
        }

        public virtual void Visit(PrivilegeSecurityElement80 node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(PrivilegeSecurityElement80 node) {
            if (this._visitBaseType) {
                this.Visit((SecurityElement80)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
        }

        public virtual void Visit(Privilege80 node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(Privilege80 node) {
            this.Start<Privilege80>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<Privilege80>(node);
        }

        public virtual void Visit(SecurityUserClause80 node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SecurityUserClause80 node) {
            this.Start<SecurityUserClause80>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SecurityUserClause80>(node);
        }

        public virtual void Visit(SqlCommandIdentifier node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SqlCommandIdentifier node) {
            this.Start<SqlCommandIdentifier>(node);
            if (this._visitBaseType) {
                this.Visit((Identifier)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SqlCommandIdentifier>(node);
        }

        public virtual void Visit(SetClause node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SetClause node) {
            this.Start<SetClause>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SetClause>(node);
        }

        public virtual void Visit(AssignmentSetClause node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AssignmentSetClause node) {
            this.Start<AssignmentSetClause>(node);
            if (this._visitBaseType) {
                this.Visit((SetClause)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AssignmentSetClause>(node);
        }

        public virtual void Visit(FunctionCallSetClause node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FunctionCallSetClause node) {
            this.Start<FunctionCallSetClause>(node);
            if (this._visitBaseType) {
                this.Visit((SetClause)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FunctionCallSetClause>(node);
        }

        public virtual void Visit(InsertSource node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(InsertSource node) {
            this.Start<InsertSource>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<InsertSource>(node);
        }

        public virtual void Visit(ValuesInsertSource node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ValuesInsertSource node) {
            this.Start<ValuesInsertSource>(node);
            if (this._visitBaseType) {
                this.Visit((InsertSource)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ValuesInsertSource>(node);
        }

        public virtual void Visit(SelectInsertSource node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SelectInsertSource node) {
            this.Start<SelectInsertSource>(node);
            if (this._visitBaseType) {
                this.Visit((InsertSource)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SelectInsertSource>(node);
        }

        public virtual void Visit(ExecuteInsertSource node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExecuteInsertSource node) {
            this.Start<ExecuteInsertSource>(node);
            if (this._visitBaseType) {
                this.Visit((InsertSource)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExecuteInsertSource>(node);
        }

        public virtual void Visit(RowValue node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(RowValue node) {
            this.Start<RowValue>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<RowValue>(node);
        }

        public virtual void Visit(PrintStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(PrintStatement node) {
            this.Start<PrintStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<PrintStatement>(node);
        }

        public virtual void Visit(UpdateCall node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(UpdateCall node) {
            this.Start<UpdateCall>(node);
            if (this._visitBaseType) {
                this.Visit((BooleanExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<UpdateCall>(node);
        }

        public virtual void Visit(TSEqualCall node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TSEqualCall node) {
            this.Start<TSEqualCall>(node);
            if (this._visitBaseType) {
                this.Visit((BooleanExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TSEqualCall>(node);
        }

        public virtual void Visit(PrimaryExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(PrimaryExpression node) {
            this.Start<PrimaryExpression>(node);
            if (this._visitBaseType) {
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<PrimaryExpression>(node);
        }

        public virtual void Visit(Literal node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(Literal node) {
            this.Start<Literal>(node);
            if (this._visitBaseType) {
                this.Visit((ValueExpression)node);
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<Literal>(node);
        }

        public virtual void Visit(IntegerLiteral node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(IntegerLiteral node) {
            this.Start<IntegerLiteral>(node);
            if (this._visitBaseType) {
                this.Visit((Literal)node);
                this.Visit((ValueExpression)node);
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<IntegerLiteral>(node);
        }

        public virtual void Visit(NumericLiteral node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(NumericLiteral node) {
            this.Start<NumericLiteral>(node);
            if (this._visitBaseType) {
                this.Visit((Literal)node);
                this.Visit((ValueExpression)node);
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<NumericLiteral>(node);
        }

        public virtual void Visit(RealLiteral node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(RealLiteral node) {
            this.Start<RealLiteral>(node);
            if (this._visitBaseType) {
                this.Visit((Literal)node);
                this.Visit((ValueExpression)node);
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<RealLiteral>(node);
        }

        public virtual void Visit(MoneyLiteral node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(MoneyLiteral node) {
            this.Start<MoneyLiteral>(node);
            if (this._visitBaseType) {
                this.Visit((Literal)node);
                this.Visit((ValueExpression)node);
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<MoneyLiteral>(node);
        }

        public virtual void Visit(BinaryLiteral node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BinaryLiteral node) {
            this.Start<BinaryLiteral>(node);
            if (this._visitBaseType) {
                this.Visit((Literal)node);
                this.Visit((ValueExpression)node);
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BinaryLiteral>(node);
        }

        public virtual void Visit(StringLiteral node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(StringLiteral node) {
            this.Start<StringLiteral>(node);
            if (this._visitBaseType) {
                this.Visit((Literal)node);
                this.Visit((ValueExpression)node);
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<StringLiteral>(node);
        }

        public virtual void Visit(NullLiteral node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(NullLiteral node) {
            this.Start<NullLiteral>(node);
            if (this._visitBaseType) {
                this.Visit((Literal)node);
                this.Visit((ValueExpression)node);
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<NullLiteral>(node);
        }

        public virtual void Visit(IdentifierLiteral node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(IdentifierLiteral node) {
            this.Start<IdentifierLiteral>(node);
            if (this._visitBaseType) {
                this.Visit((Literal)node);
                this.Visit((ValueExpression)node);
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<IdentifierLiteral>(node);
        }

        public virtual void Visit(DefaultLiteral node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DefaultLiteral node) {
            this.Start<DefaultLiteral>(node);
            if (this._visitBaseType) {
                this.Visit((Literal)node);
                this.Visit((ValueExpression)node);
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DefaultLiteral>(node);
        }

        public virtual void Visit(MaxLiteral node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(MaxLiteral node) {
            this.Start<MaxLiteral>(node);
            if (this._visitBaseType) {
                this.Visit((Literal)node);
                this.Visit((ValueExpression)node);
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<MaxLiteral>(node);
        }

        public virtual void Visit(OdbcLiteral node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OdbcLiteral node) {
            this.Start<OdbcLiteral>(node);
            if (this._visitBaseType) {
                this.Visit((Literal)node);
                this.Visit((ValueExpression)node);
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OdbcLiteral>(node);
        }

        public virtual void Visit(LiteralRange node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(LiteralRange node) {
            this.Start<LiteralRange>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<LiteralRange>(node);
        }

        public virtual void Visit(ValueExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ValueExpression node) {
            this.Start<ValueExpression>(node);
            if (this._visitBaseType) {
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ValueExpression>(node);
        }

        public virtual void Visit(VariableReference node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(VariableReference node) {
            this.Start<VariableReference>(node);
            if (this._visitBaseType) {
                this.Visit((ValueExpression)node);
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<VariableReference>(node);
        }

        public virtual void Visit(OptionValue node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OptionValue node) {
            this.Start<OptionValue>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OptionValue>(node);
        }

        public virtual void Visit(OnOffOptionValue node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OnOffOptionValue node) {
            this.Start<OnOffOptionValue>(node);
            if (this._visitBaseType) {
                this.Visit((OptionValue)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OnOffOptionValue>(node);
        }

        public virtual void Visit(LiteralOptionValue node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(LiteralOptionValue node) {
            this.Start<LiteralOptionValue>(node);
            if (this._visitBaseType) {
                this.Visit((OptionValue)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<LiteralOptionValue>(node);
        }

        public virtual void Visit(GlobalVariableExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(GlobalVariableExpression node) {
            this.Start<GlobalVariableExpression>(node);
            if (this._visitBaseType) {
                this.Visit((ValueExpression)node);
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<GlobalVariableExpression>(node);
        }

        public virtual void Visit(IdentifierOrValueExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(IdentifierOrValueExpression node) {
            this.Start<IdentifierOrValueExpression>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<IdentifierOrValueExpression>(node);
        }

        public virtual void Visit(IdentifierOrScalarExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(IdentifierOrScalarExpression node) {
            this.Start<IdentifierOrScalarExpression>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<IdentifierOrScalarExpression>(node);
        }

        public virtual void Visit(SchemaObjectNameOrValueExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SchemaObjectNameOrValueExpression node) {
            this.Start<SchemaObjectNameOrValueExpression>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SchemaObjectNameOrValueExpression>(node);
        }

        public virtual void Visit(ParenthesisExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ParenthesisExpression node) {
            this.Start<ParenthesisExpression>(node);
            if (this._visitBaseType) {
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ParenthesisExpression>(node);
        }

        public virtual void Visit(ColumnReferenceExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ColumnReferenceExpression node) {
            this.Start<ColumnReferenceExpression>(node);
            if (this._visitBaseType) {
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ColumnReferenceExpression>(node);
        }

        public virtual void Visit(NextValueForExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(NextValueForExpression node) {
            this.Start<NextValueForExpression>(node);
            if (this._visitBaseType) {
                this.Visit((PrimaryExpression)node);
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<NextValueForExpression>(node);
        }

        public virtual void Visit(SequenceStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SequenceStatement node) {
            this.Start<SequenceStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SequenceStatement>(node);
        }

        public virtual void Visit(SequenceOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SequenceOption node) {
            this.Start<SequenceOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SequenceOption>(node);
        }

        public virtual void Visit(DataTypeSequenceOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DataTypeSequenceOption node) {
            this.Start<DataTypeSequenceOption>(node);
            if (this._visitBaseType) {
                this.Visit((SequenceOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DataTypeSequenceOption>(node);
        }

        public virtual void Visit(ScalarExpressionSequenceOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ScalarExpressionSequenceOption node) {
            this.Start<ScalarExpressionSequenceOption>(node);
            if (this._visitBaseType) {
                this.Visit((SequenceOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ScalarExpressionSequenceOption>(node);
        }

        public virtual void Visit(CreateSequenceStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateSequenceStatement node) {
            this.Start<CreateSequenceStatement>(node);
            if (this._visitBaseType) {
                this.Visit((SequenceStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateSequenceStatement>(node);
        }

        public virtual void Visit(AlterSequenceStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterSequenceStatement node) {
            this.Start<AlterSequenceStatement>(node);
            if (this._visitBaseType) {
                this.Visit((SequenceStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterSequenceStatement>(node);
        }

        public virtual void Visit(DropSequenceStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropSequenceStatement node) {
            this.Start<DropSequenceStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropObjectsStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropSequenceStatement>(node);
        }

        public virtual void Visit(SecurityPolicyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SecurityPolicyStatement node) {
            this.Start<SecurityPolicyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SecurityPolicyStatement>(node);
        }

        public virtual void Visit(SecurityPredicateAction node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SecurityPredicateAction node) {
            this.Start<SecurityPredicateAction>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SecurityPredicateAction>(node);
        }

        public virtual void Visit(SecurityPolicyOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SecurityPolicyOption node) {
            this.Start<SecurityPolicyOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SecurityPolicyOption>(node);
        }

        public virtual void Visit(CreateSecurityPolicyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateSecurityPolicyStatement node) {
            this.Start<CreateSecurityPolicyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((SecurityPolicyStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateSecurityPolicyStatement>(node);
        }

        public virtual void Visit(AlterSecurityPolicyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterSecurityPolicyStatement node) {
            this.Start<AlterSecurityPolicyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((SecurityPolicyStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterSecurityPolicyStatement>(node);
        }

        public virtual void Visit(DropSecurityPolicyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropSecurityPolicyStatement node) {
            this.Start<DropSecurityPolicyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropObjectsStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropSecurityPolicyStatement>(node);
        }

        public virtual void Visit(CreateColumnMasterKeyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateColumnMasterKeyStatement node) {
            this.Start<CreateColumnMasterKeyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateColumnMasterKeyStatement>(node);
        }

        public virtual void Visit(ColumnMasterKeyParameter node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ColumnMasterKeyParameter node) {
            this.Start<ColumnMasterKeyParameter>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ColumnMasterKeyParameter>(node);
        }

        public virtual void Visit(ColumnMasterKeyStoreProviderNameParameter node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ColumnMasterKeyStoreProviderNameParameter node) {
            this.Start<ColumnMasterKeyStoreProviderNameParameter>(node);
            if (this._visitBaseType) {
                this.Visit((ColumnMasterKeyParameter)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ColumnMasterKeyStoreProviderNameParameter>(node);
        }

        public virtual void Visit(ColumnMasterKeyPathParameter node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ColumnMasterKeyPathParameter node) {
            this.Start<ColumnMasterKeyPathParameter>(node);
            if (this._visitBaseType) {
                this.Visit((ColumnMasterKeyParameter)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ColumnMasterKeyPathParameter>(node);
        }

        public virtual void Visit(DropColumnMasterKeyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropColumnMasterKeyStatement node) {
            this.Start<DropColumnMasterKeyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropColumnMasterKeyStatement>(node);
        }

        public virtual void Visit(ColumnEncryptionKeyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ColumnEncryptionKeyStatement node) {
            this.Start<ColumnEncryptionKeyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ColumnEncryptionKeyStatement>(node);
        }

        public virtual void Visit(CreateColumnEncryptionKeyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateColumnEncryptionKeyStatement node) {
            this.Start<CreateColumnEncryptionKeyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((ColumnEncryptionKeyStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateColumnEncryptionKeyStatement>(node);
        }

        public virtual void Visit(AlterColumnEncryptionKeyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterColumnEncryptionKeyStatement node) {
            this.Start<AlterColumnEncryptionKeyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((ColumnEncryptionKeyStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterColumnEncryptionKeyStatement>(node);
        }

        public virtual void Visit(DropColumnEncryptionKeyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropColumnEncryptionKeyStatement node) {
            this.Start<DropColumnEncryptionKeyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropColumnEncryptionKeyStatement>(node);
        }

        public virtual void Visit(ColumnEncryptionKeyValue node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ColumnEncryptionKeyValue node) {
            this.Start<ColumnEncryptionKeyValue>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ColumnEncryptionKeyValue>(node);
        }

        public virtual void Visit(ColumnEncryptionKeyValueParameter node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ColumnEncryptionKeyValueParameter node) {
            this.Start<ColumnEncryptionKeyValueParameter>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ColumnEncryptionKeyValueParameter>(node);
        }

        public virtual void Visit(ColumnMasterKeyNameParameter node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ColumnMasterKeyNameParameter node) {
            this.Start<ColumnMasterKeyNameParameter>(node);
            if (this._visitBaseType) {
                this.Visit((ColumnEncryptionKeyValueParameter)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ColumnMasterKeyNameParameter>(node);
        }

        public virtual void Visit(ColumnEncryptionAlgorithmNameParameter node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ColumnEncryptionAlgorithmNameParameter node) {
            this.Start<ColumnEncryptionAlgorithmNameParameter>(node);
            if (this._visitBaseType) {
                this.Visit((ColumnEncryptionKeyValueParameter)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ColumnEncryptionAlgorithmNameParameter>(node);
        }

        public virtual void Visit(EncryptedValueParameter node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(EncryptedValueParameter node) {
            this.Start<EncryptedValueParameter>(node);
            if (this._visitBaseType) {
                this.Visit((ColumnEncryptionKeyValueParameter)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<EncryptedValueParameter>(node);
        }

        public virtual void Visit(ExternalTableStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExternalTableStatement node) {
            this.Start<ExternalTableStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExternalTableStatement>(node);
        }

        public virtual void Visit(ExternalTableOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExternalTableOption node) {
            this.Start<ExternalTableOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExternalTableOption>(node);
        }

        public virtual void Visit(ExternalTableLiteralOrIdentifierOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExternalTableLiteralOrIdentifierOption node) {
            this.Start<ExternalTableLiteralOrIdentifierOption>(node);
            if (this._visitBaseType) {
                this.Visit((ExternalTableOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExternalTableLiteralOrIdentifierOption>(node);
        }

        public virtual void Visit(ExternalTableDistributionOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExternalTableDistributionOption node) {
            this.Start<ExternalTableDistributionOption>(node);
            if (this._visitBaseType) {
                this.Visit((ExternalTableOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExternalTableDistributionOption>(node);
        }

        public virtual void Visit(ExternalTableRejectTypeOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExternalTableRejectTypeOption node) {
            this.Start<ExternalTableRejectTypeOption>(node);
            if (this._visitBaseType) {
                this.Visit((ExternalTableOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExternalTableRejectTypeOption>(node);
        }

        public virtual void Visit(ExternalTableDistributionPolicy node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExternalTableDistributionPolicy node) {
            this.Start<ExternalTableDistributionPolicy>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExternalTableDistributionPolicy>(node);
        }

        public virtual void Visit(ExternalTableReplicatedDistributionPolicy node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExternalTableReplicatedDistributionPolicy node) {
            this.Start<ExternalTableReplicatedDistributionPolicy>(node);
            if (this._visitBaseType) {
                this.Visit((ExternalTableDistributionPolicy)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExternalTableReplicatedDistributionPolicy>(node);
        }

        public virtual void Visit(ExternalTableRoundRobinDistributionPolicy node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExternalTableRoundRobinDistributionPolicy node) {
            this.Start<ExternalTableRoundRobinDistributionPolicy>(node);
            if (this._visitBaseType) {
                this.Visit((ExternalTableDistributionPolicy)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExternalTableRoundRobinDistributionPolicy>(node);
        }

        public virtual void Visit(ExternalTableShardedDistributionPolicy node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExternalTableShardedDistributionPolicy node) {
            this.Start<ExternalTableShardedDistributionPolicy>(node);
            if (this._visitBaseType) {
                this.Visit((ExternalTableDistributionPolicy)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExternalTableShardedDistributionPolicy>(node);
        }

        public virtual void Visit(CreateExternalTableStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateExternalTableStatement node) {
            this.Start<CreateExternalTableStatement>(node);
            if (this._visitBaseType) {
                this.Visit((ExternalTableStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateExternalTableStatement>(node);
        }

        public virtual void Visit(DropExternalTableStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropExternalTableStatement node) {
            this.Start<DropExternalTableStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropObjectsStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropExternalTableStatement>(node);
        }

        public virtual void Visit(ExternalDataSourceStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExternalDataSourceStatement node) {
            this.Start<ExternalDataSourceStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExternalDataSourceStatement>(node);
        }

        public virtual void Visit(ExternalDataSourceOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExternalDataSourceOption node) {
            this.Start<ExternalDataSourceOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExternalDataSourceOption>(node);
        }

        public virtual void Visit(ExternalDataSourceLiteralOrIdentifierOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExternalDataSourceLiteralOrIdentifierOption node) {
            this.Start<ExternalDataSourceLiteralOrIdentifierOption>(node);
            if (this._visitBaseType) {
                this.Visit((ExternalDataSourceOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExternalDataSourceLiteralOrIdentifierOption>(node);
        }

        public virtual void Visit(CreateExternalDataSourceStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateExternalDataSourceStatement node) {
            this.Start<CreateExternalDataSourceStatement>(node);
            if (this._visitBaseType) {
                this.Visit((ExternalDataSourceStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateExternalDataSourceStatement>(node);
        }

        public virtual void Visit(AlterExternalDataSourceStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterExternalDataSourceStatement node) {
            this.Start<AlterExternalDataSourceStatement>(node);
            if (this._visitBaseType) {
                this.Visit((ExternalDataSourceStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterExternalDataSourceStatement>(node);
        }

        public virtual void Visit(DropExternalDataSourceStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropExternalDataSourceStatement node) {
            this.Start<DropExternalDataSourceStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropExternalDataSourceStatement>(node);
        }

        public virtual void Visit(ExternalFileFormatStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExternalFileFormatStatement node) {
            this.Start<ExternalFileFormatStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExternalFileFormatStatement>(node);
        }

        public virtual void Visit(ExternalFileFormatOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExternalFileFormatOption node) {
            this.Start<ExternalFileFormatOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExternalFileFormatOption>(node);
        }

        public virtual void Visit(ExternalFileFormatLiteralOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExternalFileFormatLiteralOption node) {
            this.Start<ExternalFileFormatLiteralOption>(node);
            if (this._visitBaseType) {
                this.Visit((ExternalFileFormatOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExternalFileFormatLiteralOption>(node);
        }

        public virtual void Visit(ExternalFileFormatUseDefaultTypeOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExternalFileFormatUseDefaultTypeOption node) {
            this.Start<ExternalFileFormatUseDefaultTypeOption>(node);
            if (this._visitBaseType) {
                this.Visit((ExternalFileFormatOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExternalFileFormatUseDefaultTypeOption>(node);
        }

        public virtual void Visit(ExternalFileFormatContainerOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExternalFileFormatContainerOption node) {
            this.Start<ExternalFileFormatContainerOption>(node);
            if (this._visitBaseType) {
                this.Visit((ExternalFileFormatOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExternalFileFormatContainerOption>(node);
        }

        public virtual void Visit(CreateExternalFileFormatStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateExternalFileFormatStatement node) {
            this.Start<CreateExternalFileFormatStatement>(node);
            if (this._visitBaseType) {
                this.Visit((ExternalFileFormatStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateExternalFileFormatStatement>(node);
        }

        public virtual void Visit(DropExternalFileFormatStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropExternalFileFormatStatement node) {
            this.Start<DropExternalFileFormatStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropExternalFileFormatStatement>(node);
        }

        public virtual void Visit(AssemblyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AssemblyStatement node) {
            this.Start<AssemblyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AssemblyStatement>(node);
        }

        public virtual void Visit(CreateAssemblyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateAssemblyStatement node) {
            this.Start<CreateAssemblyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AssemblyStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateAssemblyStatement>(node);
        }

        public virtual void Visit(AlterAssemblyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterAssemblyStatement node) {
            this.Start<AlterAssemblyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AssemblyStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterAssemblyStatement>(node);
        }

        public virtual void Visit(AssemblyOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AssemblyOption node) {
            this.Start<AssemblyOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AssemblyOption>(node);
        }

        public virtual void Visit(OnOffAssemblyOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OnOffAssemblyOption node) {
            this.Start<OnOffAssemblyOption>(node);
            if (this._visitBaseType) {
                this.Visit((AssemblyOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OnOffAssemblyOption>(node);
        }

        public virtual void Visit(PermissionSetAssemblyOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(PermissionSetAssemblyOption node) {
            this.Start<PermissionSetAssemblyOption>(node);
            if (this._visitBaseType) {
                this.Visit((AssemblyOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<PermissionSetAssemblyOption>(node);
        }

        public virtual void Visit(AddFileSpec node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AddFileSpec node) {
            this.Start<AddFileSpec>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AddFileSpec>(node);
        }

        public virtual void Visit(CreateXmlSchemaCollectionStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateXmlSchemaCollectionStatement node) {
            this.Start<CreateXmlSchemaCollectionStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateXmlSchemaCollectionStatement>(node);
        }

        public virtual void Visit(AlterXmlSchemaCollectionStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterXmlSchemaCollectionStatement node) {
            this.Start<AlterXmlSchemaCollectionStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterXmlSchemaCollectionStatement>(node);
        }

        public virtual void Visit(DropXmlSchemaCollectionStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropXmlSchemaCollectionStatement node) {
            this.Start<DropXmlSchemaCollectionStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropXmlSchemaCollectionStatement>(node);
        }

        public virtual void Visit(AssemblyName node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AssemblyName node) {
            this.Start<AssemblyName>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AssemblyName>(node);
        }

        public virtual void Visit(AlterTableStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterTableStatement node) {
            this.Start<AlterTableStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterTableStatement>(node);
        }

        public virtual void Visit(AlterTableAlterPartitionStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterTableAlterPartitionStatement node) {
            this.Start<AlterTableAlterPartitionStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterTableStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterTableAlterPartitionStatement>(node);
        }

        public virtual void Visit(AlterTableRebuildStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterTableRebuildStatement node) {
            this.Start<AlterTableRebuildStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterTableStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterTableRebuildStatement>(node);
        }

        public virtual void Visit(AlterTableChangeTrackingModificationStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterTableChangeTrackingModificationStatement node) {
            this.Start<AlterTableChangeTrackingModificationStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterTableStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterTableChangeTrackingModificationStatement>(node);
        }

        public virtual void Visit(AlterTableFileTableNamespaceStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterTableFileTableNamespaceStatement node) {
            this.Start<AlterTableFileTableNamespaceStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterTableStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterTableFileTableNamespaceStatement>(node);
        }

        public virtual void Visit(AlterTableSetStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterTableSetStatement node) {
            this.Start<AlterTableSetStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterTableStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterTableSetStatement>(node);
        }

        public virtual void Visit(TableOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TableOption node) {
            this.Start<TableOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TableOption>(node);
        }

        public virtual void Visit(LockEscalationTableOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(LockEscalationTableOption node) {
            this.Start<LockEscalationTableOption>(node);
            if (this._visitBaseType) {
                this.Visit((TableOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<LockEscalationTableOption>(node);
        }

        public virtual void Visit(FileStreamOnTableOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FileStreamOnTableOption node) {
            this.Start<FileStreamOnTableOption>(node);
            if (this._visitBaseType) {
                this.Visit((TableOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FileStreamOnTableOption>(node);
        }

        public virtual void Visit(FileTableDirectoryTableOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FileTableDirectoryTableOption node) {
            this.Start<FileTableDirectoryTableOption>(node);
            if (this._visitBaseType) {
                this.Visit((TableOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FileTableDirectoryTableOption>(node);
        }

        public virtual void Visit(FileTableCollateFileNameTableOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FileTableCollateFileNameTableOption node) {
            this.Start<FileTableCollateFileNameTableOption>(node);
            if (this._visitBaseType) {
                this.Visit((TableOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FileTableCollateFileNameTableOption>(node);
        }

        public virtual void Visit(FileTableConstraintNameTableOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FileTableConstraintNameTableOption node) {
            this.Start<FileTableConstraintNameTableOption>(node);
            if (this._visitBaseType) {
                this.Visit((TableOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FileTableConstraintNameTableOption>(node);
        }

        public virtual void Visit(MemoryOptimizedTableOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(MemoryOptimizedTableOption node) {
            this.Start<MemoryOptimizedTableOption>(node);
            if (this._visitBaseType) {
                this.Visit((TableOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<MemoryOptimizedTableOption>(node);
        }

        public virtual void Visit(DurabilityTableOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DurabilityTableOption node) {
            this.Start<DurabilityTableOption>(node);
            if (this._visitBaseType) {
                this.Visit((TableOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DurabilityTableOption>(node);
        }

        public virtual void Visit(RemoteDataArchiveTableOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(RemoteDataArchiveTableOption node) {
            this.Start<RemoteDataArchiveTableOption>(node);
            if (this._visitBaseType) {
                this.Visit((TableOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<RemoteDataArchiveTableOption>(node);
        }

        public virtual void Visit(RemoteDataArchiveAlterTableOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(RemoteDataArchiveAlterTableOption node) {
            this.Start<RemoteDataArchiveAlterTableOption>(node);
            if (this._visitBaseType) {
                this.Visit((TableOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<RemoteDataArchiveAlterTableOption>(node);
        }

        public virtual void Visit(RemoteDataArchiveDatabaseOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(RemoteDataArchiveDatabaseOption node) {
            this.Start<RemoteDataArchiveDatabaseOption>(node);
            if (this._visitBaseType) {
                this.Visit((DatabaseOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<RemoteDataArchiveDatabaseOption>(node);
        }

        public virtual void Visit(RemoteDataArchiveDatabaseSetting node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(RemoteDataArchiveDatabaseSetting node) {
            this.Start<RemoteDataArchiveDatabaseSetting>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<RemoteDataArchiveDatabaseSetting>(node);
        }

        public virtual void Visit(RemoteDataArchiveDbServerSetting node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(RemoteDataArchiveDbServerSetting node) {
            this.Start<RemoteDataArchiveDbServerSetting>(node);
            if (this._visitBaseType) {
                this.Visit((RemoteDataArchiveDatabaseSetting)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<RemoteDataArchiveDbServerSetting>(node);
        }

        public virtual void Visit(RemoteDataArchiveDbCredentialSetting node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(RemoteDataArchiveDbCredentialSetting node) {
            this.Start<RemoteDataArchiveDbCredentialSetting>(node);
            if (this._visitBaseType) {
                this.Visit((RemoteDataArchiveDatabaseSetting)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<RemoteDataArchiveDbCredentialSetting>(node);
        }

        public virtual void Visit(RemoteDataArchiveDbFederatedServiceAccountSetting node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(RemoteDataArchiveDbFederatedServiceAccountSetting node) {
            this.Start<RemoteDataArchiveDbFederatedServiceAccountSetting>(node);
            if (this._visitBaseType) {
                this.Visit((RemoteDataArchiveDatabaseSetting)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<RemoteDataArchiveDbFederatedServiceAccountSetting>(node);
        }

        public virtual void Visit(RetentionPeriodDefinition node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(RetentionPeriodDefinition node) {
            this.Start<RetentionPeriodDefinition>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<RetentionPeriodDefinition>(node);
        }

        public virtual void Visit(SystemVersioningTableOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SystemVersioningTableOption node) {
            this.Start<SystemVersioningTableOption>(node);
            if (this._visitBaseType) {
                this.Visit((TableOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SystemVersioningTableOption>(node);
        }

        public virtual void Visit(AlterTableAddTableElementStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterTableAddTableElementStatement node) {
            this.Start<AlterTableAddTableElementStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterTableStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterTableAddTableElementStatement>(node);
        }

        public virtual void Visit(AlterTableConstraintModificationStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterTableConstraintModificationStatement node) {
            this.Start<AlterTableConstraintModificationStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterTableStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterTableConstraintModificationStatement>(node);
        }

        public virtual void Visit(AlterTableSwitchStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterTableSwitchStatement node) {
            this.Start<AlterTableSwitchStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterTableStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterTableSwitchStatement>(node);
        }

        public virtual void Visit(TableSwitchOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TableSwitchOption node) {
            this.Start<TableSwitchOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TableSwitchOption>(node);
        }

        public virtual void Visit(LowPriorityLockWaitTableSwitchOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(LowPriorityLockWaitTableSwitchOption node) {
            this.Start<LowPriorityLockWaitTableSwitchOption>(node);
            if (this._visitBaseType) {
                this.Visit((TableSwitchOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<LowPriorityLockWaitTableSwitchOption>(node);
        }

        public virtual void Visit(DropClusteredConstraintOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropClusteredConstraintOption node) {
            this.Start<DropClusteredConstraintOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropClusteredConstraintOption>(node);
        }

        public virtual void Visit(DropClusteredConstraintStateOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropClusteredConstraintStateOption node) {
            this.Start<DropClusteredConstraintStateOption>(node);
            if (this._visitBaseType) {
                this.Visit((DropClusteredConstraintOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropClusteredConstraintStateOption>(node);
        }

        public virtual void Visit(DropClusteredConstraintValueOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropClusteredConstraintValueOption node) {
            this.Start<DropClusteredConstraintValueOption>(node);
            if (this._visitBaseType) {
                this.Visit((DropClusteredConstraintOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropClusteredConstraintValueOption>(node);
        }

        public virtual void Visit(DropClusteredConstraintMoveOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropClusteredConstraintMoveOption node) {
            this.Start<DropClusteredConstraintMoveOption>(node);
            if (this._visitBaseType) {
                this.Visit((DropClusteredConstraintOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropClusteredConstraintMoveOption>(node);
        }

        public virtual void Visit(DropClusteredConstraintWaitAtLowPriorityLockOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropClusteredConstraintWaitAtLowPriorityLockOption node) {
            this.Start<DropClusteredConstraintWaitAtLowPriorityLockOption>(node);
            if (this._visitBaseType) {
                this.Visit((DropClusteredConstraintOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropClusteredConstraintWaitAtLowPriorityLockOption>(node);
        }

        public virtual void Visit(AlterTableDropTableElement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterTableDropTableElement node) {
            this.Start<AlterTableDropTableElement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterTableDropTableElement>(node);
        }

        public virtual void Visit(AlterTableDropTableElementStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterTableDropTableElementStatement node) {
            this.Start<AlterTableDropTableElementStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterTableStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterTableDropTableElementStatement>(node);
        }

        public virtual void Visit(AlterTableTriggerModificationStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterTableTriggerModificationStatement node) {
            this.Start<AlterTableTriggerModificationStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterTableStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterTableTriggerModificationStatement>(node);
        }

        public virtual void Visit(EnableDisableTriggerStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(EnableDisableTriggerStatement node) {
            this.Start<EnableDisableTriggerStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<EnableDisableTriggerStatement>(node);
        }

        public virtual void Visit(TryCatchStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TryCatchStatement node) {
            this.Start<TryCatchStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TryCatchStatement>(node);
        }

        public virtual void Visit(CreateTypeStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateTypeStatement node) {
            this.Start<CreateTypeStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateTypeStatement>(node);
        }

        public virtual void Visit(CreateTypeUdtStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateTypeUdtStatement node) {
            this.Start<CreateTypeUdtStatement>(node);
            if (this._visitBaseType) {
                this.Visit((CreateTypeStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateTypeUdtStatement>(node);
        }

        public virtual void Visit(CreateTypeUddtStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateTypeUddtStatement node) {
            this.Start<CreateTypeUddtStatement>(node);
            if (this._visitBaseType) {
                this.Visit((CreateTypeStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateTypeUddtStatement>(node);
        }

        public virtual void Visit(CreateSynonymStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateSynonymStatement node) {
            this.Start<CreateSynonymStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateSynonymStatement>(node);
        }

        public virtual void Visit(ExecuteAsClause node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExecuteAsClause node) {
            this.Start<ExecuteAsClause>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExecuteAsClause>(node);
        }

        public virtual void Visit(QueueOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(QueueOption node) {
            this.Start<QueueOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<QueueOption>(node);
        }

        public virtual void Visit(QueueStateOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(QueueStateOption node) {
            this.Start<QueueStateOption>(node);
            if (this._visitBaseType) {
                this.Visit((QueueOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<QueueStateOption>(node);
        }

        public virtual void Visit(QueueProcedureOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(QueueProcedureOption node) {
            this.Start<QueueProcedureOption>(node);
            if (this._visitBaseType) {
                this.Visit((QueueOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<QueueProcedureOption>(node);
        }

        public virtual void Visit(QueueValueOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(QueueValueOption node) {
            this.Start<QueueValueOption>(node);
            if (this._visitBaseType) {
                this.Visit((QueueOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<QueueValueOption>(node);
        }

        public virtual void Visit(QueueExecuteAsOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(QueueExecuteAsOption node) {
            this.Start<QueueExecuteAsOption>(node);
            if (this._visitBaseType) {
                this.Visit((QueueOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<QueueExecuteAsOption>(node);
        }

        public virtual void Visit(RouteOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(RouteOption node) {
            this.Start<RouteOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<RouteOption>(node);
        }

        public virtual void Visit(RouteStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(RouteStatement node) {
            this.Start<RouteStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<RouteStatement>(node);
        }

        public virtual void Visit(AlterRouteStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterRouteStatement node) {
            this.Start<AlterRouteStatement>(node);
            if (this._visitBaseType) {
                this.Visit((RouteStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterRouteStatement>(node);
        }

        public virtual void Visit(CreateRouteStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateRouteStatement node) {
            this.Start<CreateRouteStatement>(node);
            if (this._visitBaseType) {
                this.Visit((RouteStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateRouteStatement>(node);
        }

        public virtual void Visit(QueueStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(QueueStatement node) {
            this.Start<QueueStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<QueueStatement>(node);
        }

        public virtual void Visit(AlterQueueStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterQueueStatement node) {
            this.Start<AlterQueueStatement>(node);
            if (this._visitBaseType) {
                this.Visit((QueueStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterQueueStatement>(node);
        }

        public virtual void Visit(CreateQueueStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateQueueStatement node) {
            this.Start<CreateQueueStatement>(node);
            if (this._visitBaseType) {
                this.Visit((QueueStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateQueueStatement>(node);
        }

        public virtual void Visit(IndexDefinition node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(IndexDefinition node) {
            this.Start<IndexDefinition>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<IndexDefinition>(node);
        }

        public virtual void Visit(SystemTimePeriodDefinition node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SystemTimePeriodDefinition node) {
            this.Start<SystemTimePeriodDefinition>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SystemTimePeriodDefinition>(node);
        }

        public virtual void Visit(IndexStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(IndexStatement node) {
            this.Start<IndexStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<IndexStatement>(node);
        }

        public virtual void Visit(IndexType node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(IndexType node) {
            this.Start<IndexType>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<IndexType>(node);
        }

        public virtual void Visit(PartitionSpecifier node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(PartitionSpecifier node) {
            this.Start<PartitionSpecifier>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<PartitionSpecifier>(node);
        }

        public virtual void Visit(AlterIndexStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterIndexStatement node) {
            this.Start<AlterIndexStatement>(node);
            if (this._visitBaseType) {
                this.Visit((IndexStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterIndexStatement>(node);
        }

        public virtual void Visit(CreateXmlIndexStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateXmlIndexStatement node) {
            this.Start<CreateXmlIndexStatement>(node);
            if (this._visitBaseType) {
                this.Visit((IndexStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateXmlIndexStatement>(node);
        }

        public virtual void Visit(CreateSelectiveXmlIndexStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateSelectiveXmlIndexStatement node) {
            this.Start<CreateSelectiveXmlIndexStatement>(node);
            if (this._visitBaseType) {
                this.Visit((IndexStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateSelectiveXmlIndexStatement>(node);
        }

        public virtual void Visit(FileGroupOrPartitionScheme node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FileGroupOrPartitionScheme node) {
            this.Start<FileGroupOrPartitionScheme>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FileGroupOrPartitionScheme>(node);
        }

        public virtual void Visit(CreateIndexStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateIndexStatement node) {
            this.Start<CreateIndexStatement>(node);
            if (this._visitBaseType) {
                this.Visit((IndexStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateIndexStatement>(node);
        }

        public virtual void Visit(IndexOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(IndexOption node) {
            this.Start<IndexOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<IndexOption>(node);
        }

        public virtual void Visit(IndexStateOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(IndexStateOption node) {
            this.Start<IndexStateOption>(node);
            if (this._visitBaseType) {
                this.Visit((IndexOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<IndexStateOption>(node);
        }

        public virtual void Visit(IndexExpressionOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(IndexExpressionOption node) {
            this.Start<IndexExpressionOption>(node);
            if (this._visitBaseType) {
                this.Visit((IndexOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<IndexExpressionOption>(node);
        }

        public virtual void Visit(MaxDurationOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(MaxDurationOption node) {
            this.Start<MaxDurationOption>(node);
            if (this._visitBaseType) {
                this.Visit((IndexOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<MaxDurationOption>(node);
        }

        public virtual void Visit(WaitAtLowPriorityOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(WaitAtLowPriorityOption node) {
            this.Start<WaitAtLowPriorityOption>(node);
            if (this._visitBaseType) {
                this.Visit((IndexOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<WaitAtLowPriorityOption>(node);
        }

        public virtual void Visit(OnlineIndexOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OnlineIndexOption node) {
            this.Start<OnlineIndexOption>(node);
            if (this._visitBaseType) {
                this.Visit((IndexStateOption)node);
                this.Visit((IndexOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OnlineIndexOption>(node);
        }

        public virtual void Visit(IgnoreDupKeyIndexOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(IgnoreDupKeyIndexOption node) {
            this.Start<IgnoreDupKeyIndexOption>(node);
            if (this._visitBaseType) {
                this.Visit((IndexStateOption)node);
                this.Visit((IndexOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<IgnoreDupKeyIndexOption>(node);
        }

        public virtual void Visit(OrderIndexOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OrderIndexOption node) {
            this.Start<OrderIndexOption>(node);
            if (this._visitBaseType) {
                this.Visit((IndexOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OrderIndexOption>(node);
        }

        public virtual void Visit(OnlineIndexLowPriorityLockWaitOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OnlineIndexLowPriorityLockWaitOption node) {
            this.Start<OnlineIndexLowPriorityLockWaitOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OnlineIndexLowPriorityLockWaitOption>(node);
        }

        public virtual void Visit(LowPriorityLockWaitOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(LowPriorityLockWaitOption node) {
            this.Start<LowPriorityLockWaitOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<LowPriorityLockWaitOption>(node);
        }

        public virtual void Visit(LowPriorityLockWaitMaxDurationOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(LowPriorityLockWaitMaxDurationOption node) {
            this.Start<LowPriorityLockWaitMaxDurationOption>(node);
            if (this._visitBaseType) {
                this.Visit((LowPriorityLockWaitOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<LowPriorityLockWaitMaxDurationOption>(node);
        }

        public virtual void Visit(LowPriorityLockWaitAbortAfterWaitOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(LowPriorityLockWaitAbortAfterWaitOption node) {
            this.Start<LowPriorityLockWaitAbortAfterWaitOption>(node);
            if (this._visitBaseType) {
                this.Visit((LowPriorityLockWaitOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<LowPriorityLockWaitAbortAfterWaitOption>(node);
        }

        public virtual void Visit(FullTextIndexColumn node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FullTextIndexColumn node) {
            this.Start<FullTextIndexColumn>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FullTextIndexColumn>(node);
        }

        public virtual void Visit(CreateFullTextIndexStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateFullTextIndexStatement node) {
            this.Start<CreateFullTextIndexStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateFullTextIndexStatement>(node);
        }

        public virtual void Visit(FullTextIndexOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FullTextIndexOption node) {
            this.Start<FullTextIndexOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FullTextIndexOption>(node);
        }

        public virtual void Visit(ChangeTrackingFullTextIndexOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ChangeTrackingFullTextIndexOption node) {
            this.Start<ChangeTrackingFullTextIndexOption>(node);
            if (this._visitBaseType) {
                this.Visit((FullTextIndexOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ChangeTrackingFullTextIndexOption>(node);
        }

        public virtual void Visit(StopListFullTextIndexOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(StopListFullTextIndexOption node) {
            this.Start<StopListFullTextIndexOption>(node);
            if (this._visitBaseType) {
                this.Visit((FullTextIndexOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<StopListFullTextIndexOption>(node);
        }

        public virtual void Visit(SearchPropertyListFullTextIndexOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SearchPropertyListFullTextIndexOption node) {
            this.Start<SearchPropertyListFullTextIndexOption>(node);
            if (this._visitBaseType) {
                this.Visit((FullTextIndexOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SearchPropertyListFullTextIndexOption>(node);
        }

        public virtual void Visit(FullTextCatalogAndFileGroup node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FullTextCatalogAndFileGroup node) {
            this.Start<FullTextCatalogAndFileGroup>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FullTextCatalogAndFileGroup>(node);
        }

        public virtual void Visit(EventTypeGroupContainer node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(EventTypeGroupContainer node) {
            this.Start<EventTypeGroupContainer>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<EventTypeGroupContainer>(node);
        }

        public virtual void Visit(EventTypeContainer node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(EventTypeContainer node) {
            this.Start<EventTypeContainer>(node);
            if (this._visitBaseType) {
                this.Visit((EventTypeGroupContainer)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<EventTypeContainer>(node);
        }

        public virtual void Visit(EventGroupContainer node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(EventGroupContainer node) {
            this.Start<EventGroupContainer>(node);
            if (this._visitBaseType) {
                this.Visit((EventTypeGroupContainer)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<EventGroupContainer>(node);
        }

        public virtual void Visit(CreateEventNotificationStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateEventNotificationStatement node) {
            this.Start<CreateEventNotificationStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateEventNotificationStatement>(node);
        }

        public virtual void Visit(EventNotificationObjectScope node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(EventNotificationObjectScope node) {
            this.Start<EventNotificationObjectScope>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<EventNotificationObjectScope>(node);
        }

        public virtual void Visit(MasterKeyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(MasterKeyStatement node) {
            this.Start<MasterKeyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<MasterKeyStatement>(node);
        }

        public virtual void Visit(CreateMasterKeyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateMasterKeyStatement node) {
            this.Start<CreateMasterKeyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((MasterKeyStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateMasterKeyStatement>(node);
        }

        public virtual void Visit(AlterMasterKeyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterMasterKeyStatement node) {
            this.Start<AlterMasterKeyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((MasterKeyStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterMasterKeyStatement>(node);
        }

        public virtual void Visit(ApplicationRoleOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ApplicationRoleOption node) {
            this.Start<ApplicationRoleOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ApplicationRoleOption>(node);
        }

        public virtual void Visit(ApplicationRoleStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ApplicationRoleStatement node) {
            this.Start<ApplicationRoleStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ApplicationRoleStatement>(node);
        }

        public virtual void Visit(CreateApplicationRoleStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateApplicationRoleStatement node) {
            this.Start<CreateApplicationRoleStatement>(node);
            if (this._visitBaseType) {
                this.Visit((ApplicationRoleStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateApplicationRoleStatement>(node);
        }

        public virtual void Visit(AlterApplicationRoleStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterApplicationRoleStatement node) {
            this.Start<AlterApplicationRoleStatement>(node);
            if (this._visitBaseType) {
                this.Visit((ApplicationRoleStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterApplicationRoleStatement>(node);
        }

        public virtual void Visit(RoleStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(RoleStatement node) {
            this.Start<RoleStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<RoleStatement>(node);
        }

        public virtual void Visit(CreateRoleStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateRoleStatement node) {
            this.Start<CreateRoleStatement>(node);
            if (this._visitBaseType) {
                this.Visit((RoleStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateRoleStatement>(node);
        }

        public virtual void Visit(AlterRoleStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterRoleStatement node) {
            this.Start<AlterRoleStatement>(node);
            if (this._visitBaseType) {
                this.Visit((RoleStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterRoleStatement>(node);
        }

        public virtual void Visit(AlterRoleAction node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterRoleAction node) {
            this.Start<AlterRoleAction>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterRoleAction>(node);
        }

        public virtual void Visit(RenameAlterRoleAction node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(RenameAlterRoleAction node) {
            this.Start<RenameAlterRoleAction>(node);
            if (this._visitBaseType) {
                this.Visit((AlterRoleAction)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<RenameAlterRoleAction>(node);
        }

        public virtual void Visit(AddMemberAlterRoleAction node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AddMemberAlterRoleAction node) {
            this.Start<AddMemberAlterRoleAction>(node);
            if (this._visitBaseType) {
                this.Visit((AlterRoleAction)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AddMemberAlterRoleAction>(node);
        }

        public virtual void Visit(DropMemberAlterRoleAction node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropMemberAlterRoleAction node) {
            this.Start<DropMemberAlterRoleAction>(node);
            if (this._visitBaseType) {
                this.Visit((AlterRoleAction)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropMemberAlterRoleAction>(node);
        }

        public virtual void Visit(CreateServerRoleStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateServerRoleStatement node) {
            this.Start<CreateServerRoleStatement>(node);
            if (this._visitBaseType) {
                this.Visit((CreateRoleStatement)node);
                this.Visit((RoleStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateServerRoleStatement>(node);
        }

        public virtual void Visit(AlterServerRoleStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterServerRoleStatement node) {
            this.Start<AlterServerRoleStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterRoleStatement)node);
                this.Visit((RoleStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterServerRoleStatement>(node);
        }

        public virtual void Visit(DropServerRoleStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropServerRoleStatement node) {
            this.Start<DropServerRoleStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropServerRoleStatement>(node);
        }

        public virtual void Visit(UserLoginOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(UserLoginOption node) {
            this.Start<UserLoginOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<UserLoginOption>(node);
        }

        public virtual void Visit(UserStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(UserStatement node) {
            this.Start<UserStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<UserStatement>(node);
        }

        public virtual void Visit(CreateUserStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateUserStatement node) {
            this.Start<CreateUserStatement>(node);
            if (this._visitBaseType) {
                this.Visit((UserStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateUserStatement>(node);
        }

        public virtual void Visit(AlterUserStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterUserStatement node) {
            this.Start<AlterUserStatement>(node);
            if (this._visitBaseType) {
                this.Visit((UserStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterUserStatement>(node);
        }

        public virtual void Visit(StatisticsOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(StatisticsOption node) {
            this.Start<StatisticsOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<StatisticsOption>(node);
        }

        public virtual void Visit(ResampleStatisticsOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ResampleStatisticsOption node) {
            this.Start<ResampleStatisticsOption>(node);
            if (this._visitBaseType) {
                this.Visit((StatisticsOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ResampleStatisticsOption>(node);
        }

        public virtual void Visit(StatisticsPartitionRange node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(StatisticsPartitionRange node) {
            this.Start<StatisticsPartitionRange>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<StatisticsPartitionRange>(node);
        }

        public virtual void Visit(OnOffStatisticsOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OnOffStatisticsOption node) {
            this.Start<OnOffStatisticsOption>(node);
            if (this._visitBaseType) {
                this.Visit((StatisticsOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OnOffStatisticsOption>(node);
        }

        public virtual void Visit(LiteralStatisticsOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(LiteralStatisticsOption node) {
            this.Start<LiteralStatisticsOption>(node);
            if (this._visitBaseType) {
                this.Visit((StatisticsOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<LiteralStatisticsOption>(node);
        }

        public virtual void Visit(CreateStatisticsStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateStatisticsStatement node) {
            this.Start<CreateStatisticsStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateStatisticsStatement>(node);
        }

        public virtual void Visit(UpdateStatisticsStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(UpdateStatisticsStatement node) {
            this.Start<UpdateStatisticsStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<UpdateStatisticsStatement>(node);
        }

        public virtual void Visit(ReturnStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ReturnStatement node) {
            this.Start<ReturnStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ReturnStatement>(node);
        }

        public virtual void Visit(DeclareCursorStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DeclareCursorStatement node) {
            this.Start<DeclareCursorStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DeclareCursorStatement>(node);
        }

        public virtual void Visit(CursorDefinition node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CursorDefinition node) {
            this.Start<CursorDefinition>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CursorDefinition>(node);
        }

        public virtual void Visit(CursorOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CursorOption node) {
            this.Start<CursorOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CursorOption>(node);
        }

        public virtual void Visit(SetVariableStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SetVariableStatement node) {
            this.Start<SetVariableStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SetVariableStatement>(node);
        }

        public virtual void Visit(CursorId node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CursorId node) {
            this.Start<CursorId>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CursorId>(node);
        }

        public virtual void Visit(CursorStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CursorStatement node) {
            this.Start<CursorStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CursorStatement>(node);
        }

        public virtual void Visit(OpenCursorStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OpenCursorStatement node) {
            this.Start<OpenCursorStatement>(node);
            if (this._visitBaseType) {
                this.Visit((CursorStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OpenCursorStatement>(node);
        }

        public virtual void Visit(CloseCursorStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CloseCursorStatement node) {
            this.Start<CloseCursorStatement>(node);
            if (this._visitBaseType) {
                this.Visit((CursorStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CloseCursorStatement>(node);
        }

        public virtual void Visit(CryptoMechanism node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CryptoMechanism node) {
            this.Start<CryptoMechanism>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CryptoMechanism>(node);
        }

        public virtual void Visit(OpenSymmetricKeyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OpenSymmetricKeyStatement node) {
            this.Start<OpenSymmetricKeyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OpenSymmetricKeyStatement>(node);
        }

        public virtual void Visit(CloseSymmetricKeyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CloseSymmetricKeyStatement node) {
            this.Start<CloseSymmetricKeyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CloseSymmetricKeyStatement>(node);
        }

        public virtual void Visit(OpenMasterKeyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OpenMasterKeyStatement node) {
            this.Start<OpenMasterKeyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OpenMasterKeyStatement>(node);
        }

        public virtual void Visit(CloseMasterKeyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CloseMasterKeyStatement node) {
            this.Start<CloseMasterKeyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CloseMasterKeyStatement>(node);
        }

        public virtual void Visit(DeallocateCursorStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DeallocateCursorStatement node) {
            this.Start<DeallocateCursorStatement>(node);
            if (this._visitBaseType) {
                this.Visit((CursorStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DeallocateCursorStatement>(node);
        }

        public virtual void Visit(FetchType node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FetchType node) {
            this.Start<FetchType>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FetchType>(node);
        }

        public virtual void Visit(FetchCursorStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FetchCursorStatement node) {
            this.Start<FetchCursorStatement>(node);
            if (this._visitBaseType) {
                this.Visit((CursorStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FetchCursorStatement>(node);
        }

        public virtual void Visit(WhereClause node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(WhereClause node) {
            this.Start<WhereClause>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<WhereClause>(node);
        }

        public virtual void Visit(DropUnownedObjectStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropUnownedObjectStatement node) {
            this.Start<DropUnownedObjectStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropUnownedObjectStatement>(node);
        }

        public virtual void Visit(DropObjectsStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropObjectsStatement node) {
            this.Start<DropObjectsStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropObjectsStatement>(node);
        }

        public virtual void Visit(DropDatabaseStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropDatabaseStatement node) {
            this.Start<DropDatabaseStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropDatabaseStatement>(node);
        }

        public virtual void Visit(DropChildObjectsStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropChildObjectsStatement node) {
            this.Start<DropChildObjectsStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropChildObjectsStatement>(node);
        }

        public virtual void Visit(DropIndexStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropIndexStatement node) {
            this.Start<DropIndexStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropIndexStatement>(node);
        }

        public virtual void Visit(DropIndexClauseBase node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropIndexClauseBase node) {
            this.Start<DropIndexClauseBase>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropIndexClauseBase>(node);
        }

        public virtual void Visit(BackwardsCompatibleDropIndexClause node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BackwardsCompatibleDropIndexClause node) {
            this.Start<BackwardsCompatibleDropIndexClause>(node);
            if (this._visitBaseType) {
                this.Visit((DropIndexClauseBase)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BackwardsCompatibleDropIndexClause>(node);
        }

        public virtual void Visit(DropIndexClause node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropIndexClause node) {
            this.Start<DropIndexClause>(node);
            if (this._visitBaseType) {
                this.Visit((DropIndexClauseBase)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropIndexClause>(node);
        }

        public virtual void Visit(MoveToDropIndexOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(MoveToDropIndexOption node) {
            this.Start<MoveToDropIndexOption>(node);
            if (this._visitBaseType) {
                this.Visit((IndexOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<MoveToDropIndexOption>(node);
        }

        public virtual void Visit(FileStreamOnDropIndexOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FileStreamOnDropIndexOption node) {
            this.Start<FileStreamOnDropIndexOption>(node);
            if (this._visitBaseType) {
                this.Visit((IndexOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FileStreamOnDropIndexOption>(node);
        }

        public virtual void Visit(DropStatisticsStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropStatisticsStatement node) {
            this.Start<DropStatisticsStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropChildObjectsStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropStatisticsStatement>(node);
        }

        public virtual void Visit(DropTableStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropTableStatement node) {
            this.Start<DropTableStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropObjectsStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropTableStatement>(node);
        }

        public virtual void Visit(DropProcedureStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropProcedureStatement node) {
            this.Start<DropProcedureStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropObjectsStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropProcedureStatement>(node);
        }

        public virtual void Visit(DropFunctionStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropFunctionStatement node) {
            this.Start<DropFunctionStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropObjectsStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropFunctionStatement>(node);
        }

        public virtual void Visit(DropViewStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropViewStatement node) {
            this.Start<DropViewStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropObjectsStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropViewStatement>(node);
        }

        public virtual void Visit(DropDefaultStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropDefaultStatement node) {
            this.Start<DropDefaultStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropObjectsStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropDefaultStatement>(node);
        }

        public virtual void Visit(DropRuleStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropRuleStatement node) {
            this.Start<DropRuleStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropObjectsStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropRuleStatement>(node);
        }

        public virtual void Visit(DropTriggerStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropTriggerStatement node) {
            this.Start<DropTriggerStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropObjectsStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropTriggerStatement>(node);
        }

        public virtual void Visit(DropSchemaStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropSchemaStatement node) {
            this.Start<DropSchemaStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropSchemaStatement>(node);
        }

        public virtual void Visit(RaiseErrorLegacyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(RaiseErrorLegacyStatement node) {
            this.Start<RaiseErrorLegacyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<RaiseErrorLegacyStatement>(node);
        }

        public virtual void Visit(RaiseErrorStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(RaiseErrorStatement node) {
            this.Start<RaiseErrorStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<RaiseErrorStatement>(node);
        }

        public virtual void Visit(ThrowStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ThrowStatement node) {
            this.Start<ThrowStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ThrowStatement>(node);
        }

        public virtual void Visit(UseStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(UseStatement node) {
            this.Start<UseStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<UseStatement>(node);
        }

        public virtual void Visit(KillStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(KillStatement node) {
            this.Start<KillStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<KillStatement>(node);
        }

        public virtual void Visit(KillQueryNotificationSubscriptionStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(KillQueryNotificationSubscriptionStatement node) {
            this.Start<KillQueryNotificationSubscriptionStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<KillQueryNotificationSubscriptionStatement>(node);
        }

        public virtual void Visit(KillStatsJobStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(KillStatsJobStatement node) {
            this.Start<KillStatsJobStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<KillStatsJobStatement>(node);
        }

        public virtual void Visit(CheckpointStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CheckpointStatement node) {
            this.Start<CheckpointStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CheckpointStatement>(node);
        }

        public virtual void Visit(ReconfigureStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ReconfigureStatement node) {
            this.Start<ReconfigureStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ReconfigureStatement>(node);
        }

        public virtual void Visit(ShutdownStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ShutdownStatement node) {
            this.Start<ShutdownStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ShutdownStatement>(node);
        }

        public virtual void Visit(SetUserStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SetUserStatement node) {
            this.Start<SetUserStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SetUserStatement>(node);
        }

        public virtual void Visit(TruncateTableStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TruncateTableStatement node) {
            this.Start<TruncateTableStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TruncateTableStatement>(node);
        }

        public virtual void Visit(SetOnOffStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SetOnOffStatement node) {
            this.Start<SetOnOffStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SetOnOffStatement>(node);
        }

        public virtual void Visit(PredicateSetStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(PredicateSetStatement node) {
            this.Start<PredicateSetStatement>(node);
            if (this._visitBaseType) {
                this.Visit((SetOnOffStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<PredicateSetStatement>(node);
        }

        public virtual void Visit(SetStatisticsStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SetStatisticsStatement node) {
            this.Start<SetStatisticsStatement>(node);
            if (this._visitBaseType) {
                this.Visit((SetOnOffStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SetStatisticsStatement>(node);
        }

        public virtual void Visit(SetRowCountStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SetRowCountStatement node) {
            this.Start<SetRowCountStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SetRowCountStatement>(node);
        }

        public virtual void Visit(SetOffsetsStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SetOffsetsStatement node) {
            this.Start<SetOffsetsStatement>(node);
            if (this._visitBaseType) {
                this.Visit((SetOnOffStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SetOffsetsStatement>(node);
        }

        public virtual void Visit(SetCommand node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SetCommand node) {
            this.Start<SetCommand>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SetCommand>(node);
        }

        public virtual void Visit(GeneralSetCommand node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(GeneralSetCommand node) {
            this.Start<GeneralSetCommand>(node);
            if (this._visitBaseType) {
                this.Visit((SetCommand)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<GeneralSetCommand>(node);
        }

        public virtual void Visit(SetFipsFlaggerCommand node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SetFipsFlaggerCommand node) {
            this.Start<SetFipsFlaggerCommand>(node);
            if (this._visitBaseType) {
                this.Visit((SetCommand)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SetFipsFlaggerCommand>(node);
        }

        public virtual void Visit(SetCommandStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SetCommandStatement node) {
            this.Start<SetCommandStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SetCommandStatement>(node);
        }

        public virtual void Visit(SetTransactionIsolationLevelStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SetTransactionIsolationLevelStatement node) {
            this.Start<SetTransactionIsolationLevelStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SetTransactionIsolationLevelStatement>(node);
        }

        public virtual void Visit(SetTextSizeStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SetTextSizeStatement node) {
            this.Start<SetTextSizeStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SetTextSizeStatement>(node);
        }

        public virtual void Visit(SetIdentityInsertStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SetIdentityInsertStatement node) {
            this.Start<SetIdentityInsertStatement>(node);
            if (this._visitBaseType) {
                this.Visit((SetOnOffStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SetIdentityInsertStatement>(node);
        }

        public virtual void Visit(SetErrorLevelStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SetErrorLevelStatement node) {
            this.Start<SetErrorLevelStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SetErrorLevelStatement>(node);
        }

        public virtual void Visit(CreateDatabaseStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateDatabaseStatement node) {
            this.Start<CreateDatabaseStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateDatabaseStatement>(node);
        }

        public virtual void Visit(FileDeclaration node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FileDeclaration node) {
            this.Start<FileDeclaration>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FileDeclaration>(node);
        }

        public virtual void Visit(FileDeclarationOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FileDeclarationOption node) {
            this.Start<FileDeclarationOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FileDeclarationOption>(node);
        }

        public virtual void Visit(NameFileDeclarationOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(NameFileDeclarationOption node) {
            this.Start<NameFileDeclarationOption>(node);
            if (this._visitBaseType) {
                this.Visit((FileDeclarationOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<NameFileDeclarationOption>(node);
        }

        public virtual void Visit(FileNameFileDeclarationOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FileNameFileDeclarationOption node) {
            this.Start<FileNameFileDeclarationOption>(node);
            if (this._visitBaseType) {
                this.Visit((FileDeclarationOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FileNameFileDeclarationOption>(node);
        }

        public virtual void Visit(SizeFileDeclarationOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SizeFileDeclarationOption node) {
            this.Start<SizeFileDeclarationOption>(node);
            if (this._visitBaseType) {
                this.Visit((FileDeclarationOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SizeFileDeclarationOption>(node);
        }

        public virtual void Visit(MaxSizeFileDeclarationOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(MaxSizeFileDeclarationOption node) {
            this.Start<MaxSizeFileDeclarationOption>(node);
            if (this._visitBaseType) {
                this.Visit((FileDeclarationOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<MaxSizeFileDeclarationOption>(node);
        }

        public virtual void Visit(FileGrowthFileDeclarationOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FileGrowthFileDeclarationOption node) {
            this.Start<FileGrowthFileDeclarationOption>(node);
            if (this._visitBaseType) {
                this.Visit((FileDeclarationOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FileGrowthFileDeclarationOption>(node);
        }

        public virtual void Visit(FileGroupDefinition node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FileGroupDefinition node) {
            this.Start<FileGroupDefinition>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FileGroupDefinition>(node);
        }

        public virtual void Visit(AlterDatabaseStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterDatabaseStatement node) {
            this.Start<AlterDatabaseStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterDatabaseStatement>(node);
        }

        public virtual void Visit(AlterDatabaseScopedConfigurationStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterDatabaseScopedConfigurationStatement node) {
            this.Start<AlterDatabaseScopedConfigurationStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterDatabaseScopedConfigurationStatement>(node);
        }

        public virtual void Visit(AlterDatabaseScopedConfigurationSetStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterDatabaseScopedConfigurationSetStatement node) {
            this.Start<AlterDatabaseScopedConfigurationSetStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterDatabaseScopedConfigurationStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterDatabaseScopedConfigurationSetStatement>(node);
        }

        public virtual void Visit(AlterDatabaseScopedConfigurationClearStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterDatabaseScopedConfigurationClearStatement node) {
            this.Start<AlterDatabaseScopedConfigurationClearStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterDatabaseScopedConfigurationStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterDatabaseScopedConfigurationClearStatement>(node);
        }

        public virtual void Visit(DatabaseConfigurationClearOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DatabaseConfigurationClearOption node) {
            this.Start<DatabaseConfigurationClearOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DatabaseConfigurationClearOption>(node);
        }

        public virtual void Visit(DatabaseConfigurationSetOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DatabaseConfigurationSetOption node) {
            this.Start<DatabaseConfigurationSetOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DatabaseConfigurationSetOption>(node);
        }

        public virtual void Visit(OnOffPrimaryConfigurationOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OnOffPrimaryConfigurationOption node) {
            this.Start<OnOffPrimaryConfigurationOption>(node);
            if (this._visitBaseType) {
                this.Visit((DatabaseConfigurationSetOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OnOffPrimaryConfigurationOption>(node);
        }

        public virtual void Visit(MaxDopConfigurationOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(MaxDopConfigurationOption node) {
            this.Start<MaxDopConfigurationOption>(node);
            if (this._visitBaseType) {
                this.Visit((DatabaseConfigurationSetOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<MaxDopConfigurationOption>(node);
        }

        public virtual void Visit(GenericConfigurationOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(GenericConfigurationOption node) {
            this.Start<GenericConfigurationOption>(node);
            if (this._visitBaseType) {
                this.Visit((DatabaseConfigurationSetOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<GenericConfigurationOption>(node);
        }

        public virtual void Visit(AlterDatabaseCollateStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterDatabaseCollateStatement node) {
            this.Start<AlterDatabaseCollateStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterDatabaseStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterDatabaseCollateStatement>(node);
        }

        public virtual void Visit(AlterDatabaseRebuildLogStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterDatabaseRebuildLogStatement node) {
            this.Start<AlterDatabaseRebuildLogStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterDatabaseStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterDatabaseRebuildLogStatement>(node);
        }

        public virtual void Visit(AlterDatabaseAddFileStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterDatabaseAddFileStatement node) {
            this.Start<AlterDatabaseAddFileStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterDatabaseStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterDatabaseAddFileStatement>(node);
        }

        public virtual void Visit(AlterDatabaseAddFileGroupStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterDatabaseAddFileGroupStatement node) {
            this.Start<AlterDatabaseAddFileGroupStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterDatabaseStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterDatabaseAddFileGroupStatement>(node);
        }

        public virtual void Visit(AlterDatabaseRemoveFileGroupStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterDatabaseRemoveFileGroupStatement node) {
            this.Start<AlterDatabaseRemoveFileGroupStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterDatabaseStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterDatabaseRemoveFileGroupStatement>(node);
        }

        public virtual void Visit(AlterDatabaseRemoveFileStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterDatabaseRemoveFileStatement node) {
            this.Start<AlterDatabaseRemoveFileStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterDatabaseStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterDatabaseRemoveFileStatement>(node);
        }

        public virtual void Visit(AlterDatabaseModifyNameStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterDatabaseModifyNameStatement node) {
            this.Start<AlterDatabaseModifyNameStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterDatabaseStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterDatabaseModifyNameStatement>(node);
        }

        public virtual void Visit(AlterDatabaseModifyFileStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterDatabaseModifyFileStatement node) {
            this.Start<AlterDatabaseModifyFileStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterDatabaseStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterDatabaseModifyFileStatement>(node);
        }

        public virtual void Visit(AlterDatabaseModifyFileGroupStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterDatabaseModifyFileGroupStatement node) {
            this.Start<AlterDatabaseModifyFileGroupStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterDatabaseStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterDatabaseModifyFileGroupStatement>(node);
        }

        public virtual void Visit(AlterDatabaseTermination node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterDatabaseTermination node) {
            this.Start<AlterDatabaseTermination>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterDatabaseTermination>(node);
        }

        public virtual void Visit(AlterDatabaseSetStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterDatabaseSetStatement node) {
            this.Start<AlterDatabaseSetStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterDatabaseStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterDatabaseSetStatement>(node);
        }

        public virtual void Visit(DatabaseOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DatabaseOption node) {
            this.Start<DatabaseOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DatabaseOption>(node);
        }

        public virtual void Visit(OnOffDatabaseOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OnOffDatabaseOption node) {
            this.Start<OnOffDatabaseOption>(node);
            if (this._visitBaseType) {
                this.Visit((DatabaseOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OnOffDatabaseOption>(node);
        }

        public virtual void Visit(AutoCreateStatisticsDatabaseOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AutoCreateStatisticsDatabaseOption node) {
            this.Start<AutoCreateStatisticsDatabaseOption>(node);
            if (this._visitBaseType) {
                this.Visit((OnOffDatabaseOption)node);
                this.Visit((DatabaseOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AutoCreateStatisticsDatabaseOption>(node);
        }

        public virtual void Visit(ContainmentDatabaseOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ContainmentDatabaseOption node) {
            this.Start<ContainmentDatabaseOption>(node);
            if (this._visitBaseType) {
                this.Visit((DatabaseOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ContainmentDatabaseOption>(node);
        }

        public virtual void Visit(HadrDatabaseOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(HadrDatabaseOption node) {
            this.Start<HadrDatabaseOption>(node);
            if (this._visitBaseType) {
                this.Visit((DatabaseOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<HadrDatabaseOption>(node);
        }

        public virtual void Visit(HadrAvailabilityGroupDatabaseOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(HadrAvailabilityGroupDatabaseOption node) {
            this.Start<HadrAvailabilityGroupDatabaseOption>(node);
            if (this._visitBaseType) {
                this.Visit((HadrDatabaseOption)node);
                this.Visit((DatabaseOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<HadrAvailabilityGroupDatabaseOption>(node);
        }

        public virtual void Visit(DelayedDurabilityDatabaseOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DelayedDurabilityDatabaseOption node) {
            this.Start<DelayedDurabilityDatabaseOption>(node);
            if (this._visitBaseType) {
                this.Visit((DatabaseOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DelayedDurabilityDatabaseOption>(node);
        }

        public virtual void Visit(CursorDefaultDatabaseOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CursorDefaultDatabaseOption node) {
            this.Start<CursorDefaultDatabaseOption>(node);
            if (this._visitBaseType) {
                this.Visit((DatabaseOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CursorDefaultDatabaseOption>(node);
        }

        public virtual void Visit(RecoveryDatabaseOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(RecoveryDatabaseOption node) {
            this.Start<RecoveryDatabaseOption>(node);
            if (this._visitBaseType) {
                this.Visit((DatabaseOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<RecoveryDatabaseOption>(node);
        }

        public virtual void Visit(TargetRecoveryTimeDatabaseOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TargetRecoveryTimeDatabaseOption node) {
            this.Start<TargetRecoveryTimeDatabaseOption>(node);
            if (this._visitBaseType) {
                this.Visit((DatabaseOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TargetRecoveryTimeDatabaseOption>(node);
        }

        public virtual void Visit(PageVerifyDatabaseOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(PageVerifyDatabaseOption node) {
            this.Start<PageVerifyDatabaseOption>(node);
            if (this._visitBaseType) {
                this.Visit((DatabaseOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<PageVerifyDatabaseOption>(node);
        }

        public virtual void Visit(PartnerDatabaseOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(PartnerDatabaseOption node) {
            this.Start<PartnerDatabaseOption>(node);
            if (this._visitBaseType) {
                this.Visit((DatabaseOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<PartnerDatabaseOption>(node);
        }

        public virtual void Visit(WitnessDatabaseOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(WitnessDatabaseOption node) {
            this.Start<WitnessDatabaseOption>(node);
            if (this._visitBaseType) {
                this.Visit((DatabaseOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<WitnessDatabaseOption>(node);
        }

        public virtual void Visit(ParameterizationDatabaseOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ParameterizationDatabaseOption node) {
            this.Start<ParameterizationDatabaseOption>(node);
            if (this._visitBaseType) {
                this.Visit((DatabaseOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ParameterizationDatabaseOption>(node);
        }

        public virtual void Visit(LiteralDatabaseOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(LiteralDatabaseOption node) {
            this.Start<LiteralDatabaseOption>(node);
            if (this._visitBaseType) {
                this.Visit((DatabaseOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<LiteralDatabaseOption>(node);
        }

        public virtual void Visit(IdentifierDatabaseOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(IdentifierDatabaseOption node) {
            this.Start<IdentifierDatabaseOption>(node);
            if (this._visitBaseType) {
                this.Visit((DatabaseOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<IdentifierDatabaseOption>(node);
        }

        public virtual void Visit(ChangeTrackingDatabaseOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ChangeTrackingDatabaseOption node) {
            this.Start<ChangeTrackingDatabaseOption>(node);
            if (this._visitBaseType) {
                this.Visit((DatabaseOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ChangeTrackingDatabaseOption>(node);
        }

        public virtual void Visit(ChangeTrackingOptionDetail node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ChangeTrackingOptionDetail node) {
            this.Start<ChangeTrackingOptionDetail>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ChangeTrackingOptionDetail>(node);
        }

        public virtual void Visit(AutoCleanupChangeTrackingOptionDetail node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AutoCleanupChangeTrackingOptionDetail node) {
            this.Start<AutoCleanupChangeTrackingOptionDetail>(node);
            if (this._visitBaseType) {
                this.Visit((ChangeTrackingOptionDetail)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AutoCleanupChangeTrackingOptionDetail>(node);
        }

        public virtual void Visit(ChangeRetentionChangeTrackingOptionDetail node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ChangeRetentionChangeTrackingOptionDetail node) {
            this.Start<ChangeRetentionChangeTrackingOptionDetail>(node);
            if (this._visitBaseType) {
                this.Visit((ChangeTrackingOptionDetail)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ChangeRetentionChangeTrackingOptionDetail>(node);
        }

        public virtual void Visit(QueryStoreDatabaseOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(QueryStoreDatabaseOption node) {
            this.Start<QueryStoreDatabaseOption>(node);
            if (this._visitBaseType) {
                this.Visit((DatabaseOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<QueryStoreDatabaseOption>(node);
        }

        public virtual void Visit(QueryStoreOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(QueryStoreOption node) {
            this.Start<QueryStoreOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<QueryStoreOption>(node);
        }

        public virtual void Visit(QueryStoreDesiredStateOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(QueryStoreDesiredStateOption node) {
            this.Start<QueryStoreDesiredStateOption>(node);
            if (this._visitBaseType) {
                this.Visit((QueryStoreOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<QueryStoreDesiredStateOption>(node);
        }

        public virtual void Visit(QueryStoreCapturePolicyOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(QueryStoreCapturePolicyOption node) {
            this.Start<QueryStoreCapturePolicyOption>(node);
            if (this._visitBaseType) {
                this.Visit((QueryStoreOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<QueryStoreCapturePolicyOption>(node);
        }

        public virtual void Visit(QueryStoreSizeCleanupPolicyOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(QueryStoreSizeCleanupPolicyOption node) {
            this.Start<QueryStoreSizeCleanupPolicyOption>(node);
            if (this._visitBaseType) {
                this.Visit((QueryStoreOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<QueryStoreSizeCleanupPolicyOption>(node);
        }

        public virtual void Visit(QueryStoreDataFlushIntervalOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(QueryStoreDataFlushIntervalOption node) {
            this.Start<QueryStoreDataFlushIntervalOption>(node);
            if (this._visitBaseType) {
                this.Visit((QueryStoreOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<QueryStoreDataFlushIntervalOption>(node);
        }

        public virtual void Visit(QueryStoreIntervalLengthOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(QueryStoreIntervalLengthOption node) {
            this.Start<QueryStoreIntervalLengthOption>(node);
            if (this._visitBaseType) {
                this.Visit((QueryStoreOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<QueryStoreIntervalLengthOption>(node);
        }

        public virtual void Visit(QueryStoreMaxStorageSizeOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(QueryStoreMaxStorageSizeOption node) {
            this.Start<QueryStoreMaxStorageSizeOption>(node);
            if (this._visitBaseType) {
                this.Visit((QueryStoreOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<QueryStoreMaxStorageSizeOption>(node);
        }

        public virtual void Visit(QueryStoreMaxPlansPerQueryOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(QueryStoreMaxPlansPerQueryOption node) {
            this.Start<QueryStoreMaxPlansPerQueryOption>(node);
            if (this._visitBaseType) {
                this.Visit((QueryStoreOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<QueryStoreMaxPlansPerQueryOption>(node);
        }

        public virtual void Visit(QueryStoreTimeCleanupPolicyOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(QueryStoreTimeCleanupPolicyOption node) {
            this.Start<QueryStoreTimeCleanupPolicyOption>(node);
            if (this._visitBaseType) {
                this.Visit((QueryStoreOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<QueryStoreTimeCleanupPolicyOption>(node);
        }

        public virtual void Visit(AutomaticTuningDatabaseOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AutomaticTuningDatabaseOption node) {
            this.Start<AutomaticTuningDatabaseOption>(node);
            if (this._visitBaseType) {
                this.Visit((DatabaseOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AutomaticTuningDatabaseOption>(node);
        }

        public virtual void Visit(AutomaticTuningOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AutomaticTuningOption node) {
            this.Start<AutomaticTuningOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AutomaticTuningOption>(node);
        }

        public virtual void Visit(AutomaticTuningForceLastGoodPlanOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AutomaticTuningForceLastGoodPlanOption node) {
            this.Start<AutomaticTuningForceLastGoodPlanOption>(node);
            if (this._visitBaseType) {
                this.Visit((AutomaticTuningOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AutomaticTuningForceLastGoodPlanOption>(node);
        }

        public virtual void Visit(AutomaticTuningCreateIndexOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AutomaticTuningCreateIndexOption node) {
            this.Start<AutomaticTuningCreateIndexOption>(node);
            if (this._visitBaseType) {
                this.Visit((AutomaticTuningOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AutomaticTuningCreateIndexOption>(node);
        }

        public virtual void Visit(AutomaticTuningDropIndexOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AutomaticTuningDropIndexOption node) {
            this.Start<AutomaticTuningDropIndexOption>(node);
            if (this._visitBaseType) {
                this.Visit((AutomaticTuningOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AutomaticTuningDropIndexOption>(node);
        }

        public virtual void Visit(AutomaticTuningMaintainIndexOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AutomaticTuningMaintainIndexOption node) {
            this.Start<AutomaticTuningMaintainIndexOption>(node);
            if (this._visitBaseType) {
                this.Visit((AutomaticTuningOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AutomaticTuningMaintainIndexOption>(node);
        }

        public virtual void Visit(FileStreamDatabaseOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FileStreamDatabaseOption node) {
            this.Start<FileStreamDatabaseOption>(node);
            if (this._visitBaseType) {
                this.Visit((DatabaseOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FileStreamDatabaseOption>(node);
        }

        public virtual void Visit(MaxSizeDatabaseOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(MaxSizeDatabaseOption node) {
            this.Start<MaxSizeDatabaseOption>(node);
            if (this._visitBaseType) {
                this.Visit((DatabaseOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<MaxSizeDatabaseOption>(node);
        }

        public virtual void Visit(AlterTableAlterIndexStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterTableAlterIndexStatement node) {
            this.Start<AlterTableAlterIndexStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterTableStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterTableAlterIndexStatement>(node);
        }

        public virtual void Visit(AlterTableAlterColumnStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterTableAlterColumnStatement node) {
            this.Start<AlterTableAlterColumnStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterTableStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterTableAlterColumnStatement>(node);
        }

        public virtual void Visit(ColumnDefinition node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ColumnDefinition node) {
            this.Start<ColumnDefinition>(node);
            if (this._visitBaseType) {
                this.Visit((ColumnDefinitionBase)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ColumnDefinition>(node);
        }

        public virtual void Visit(ColumnEncryptionDefinition node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ColumnEncryptionDefinition node) {
            this.Start<ColumnEncryptionDefinition>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ColumnEncryptionDefinition>(node);
        }

        public virtual void Visit(ColumnEncryptionDefinitionParameter node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ColumnEncryptionDefinitionParameter node) {
            this.Start<ColumnEncryptionDefinitionParameter>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ColumnEncryptionDefinitionParameter>(node);
        }

        public virtual void Visit(ColumnEncryptionKeyNameParameter node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ColumnEncryptionKeyNameParameter node) {
            this.Start<ColumnEncryptionKeyNameParameter>(node);
            if (this._visitBaseType) {
                this.Visit((ColumnEncryptionDefinitionParameter)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ColumnEncryptionKeyNameParameter>(node);
        }

        public virtual void Visit(ColumnEncryptionTypeParameter node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ColumnEncryptionTypeParameter node) {
            this.Start<ColumnEncryptionTypeParameter>(node);
            if (this._visitBaseType) {
                this.Visit((ColumnEncryptionDefinitionParameter)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ColumnEncryptionTypeParameter>(node);
        }

        public virtual void Visit(ColumnEncryptionAlgorithmParameter node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ColumnEncryptionAlgorithmParameter node) {
            this.Start<ColumnEncryptionAlgorithmParameter>(node);
            if (this._visitBaseType) {
                this.Visit((ColumnEncryptionDefinitionParameter)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ColumnEncryptionAlgorithmParameter>(node);
        }

        public virtual void Visit(IdentityOptions node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(IdentityOptions node) {
            this.Start<IdentityOptions>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<IdentityOptions>(node);
        }

        public virtual void Visit(ColumnStorageOptions node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ColumnStorageOptions node) {
            this.Start<ColumnStorageOptions>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ColumnStorageOptions>(node);
        }

        public virtual void Visit(ConstraintDefinition node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ConstraintDefinition node) {
            this.Start<ConstraintDefinition>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ConstraintDefinition>(node);
        }

        public virtual void Visit(CreateTableStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateTableStatement node) {
            this.Start<CreateTableStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateTableStatement>(node);
        }

        public virtual void Visit(FederationScheme node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FederationScheme node) {
            this.Start<FederationScheme>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FederationScheme>(node);
        }

        public virtual void Visit(TableDataCompressionOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TableDataCompressionOption node) {
            this.Start<TableDataCompressionOption>(node);
            if (this._visitBaseType) {
                this.Visit((TableOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TableDataCompressionOption>(node);
        }

        public virtual void Visit(TableDistributionOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TableDistributionOption node) {
            this.Start<TableDistributionOption>(node);
            if (this._visitBaseType) {
                this.Visit((TableOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TableDistributionOption>(node);
        }

        public virtual void Visit(TableDistributionPolicy node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TableDistributionPolicy node) {
            this.Start<TableDistributionPolicy>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TableDistributionPolicy>(node);
        }

        public virtual void Visit(TableReplicateDistributionPolicy node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TableReplicateDistributionPolicy node) {
            this.Start<TableReplicateDistributionPolicy>(node);
            if (this._visitBaseType) {
                this.Visit((TableDistributionPolicy)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TableReplicateDistributionPolicy>(node);
        }

        public virtual void Visit(TableRoundRobinDistributionPolicy node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TableRoundRobinDistributionPolicy node) {
            this.Start<TableRoundRobinDistributionPolicy>(node);
            if (this._visitBaseType) {
                this.Visit((TableDistributionPolicy)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TableRoundRobinDistributionPolicy>(node);
        }

        public virtual void Visit(TableHashDistributionPolicy node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TableHashDistributionPolicy node) {
            this.Start<TableHashDistributionPolicy>(node);
            if (this._visitBaseType) {
                this.Visit((TableDistributionPolicy)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TableHashDistributionPolicy>(node);
        }

        public virtual void Visit(TableIndexOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TableIndexOption node) {
            this.Start<TableIndexOption>(node);
            if (this._visitBaseType) {
                this.Visit((TableOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TableIndexOption>(node);
        }

        public virtual void Visit(TableIndexType node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TableIndexType node) {
            this.Start<TableIndexType>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TableIndexType>(node);
        }

        public virtual void Visit(TableClusteredIndexType node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TableClusteredIndexType node) {
            this.Start<TableClusteredIndexType>(node);
            if (this._visitBaseType) {
                this.Visit((TableIndexType)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TableClusteredIndexType>(node);
        }

        public virtual void Visit(TableNonClusteredIndexType node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TableNonClusteredIndexType node) {
            this.Start<TableNonClusteredIndexType>(node);
            if (this._visitBaseType) {
                this.Visit((TableIndexType)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TableNonClusteredIndexType>(node);
        }

        public virtual void Visit(TablePartitionOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TablePartitionOption node) {
            this.Start<TablePartitionOption>(node);
            if (this._visitBaseType) {
                this.Visit((TableOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TablePartitionOption>(node);
        }

        public virtual void Visit(PartitionSpecifications node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(PartitionSpecifications node) {
            this.Start<PartitionSpecifications>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<PartitionSpecifications>(node);
        }

        public virtual void Visit(TablePartitionOptionSpecifications node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TablePartitionOptionSpecifications node) {
            this.Start<TablePartitionOptionSpecifications>(node);
            if (this._visitBaseType) {
                this.Visit((PartitionSpecifications)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TablePartitionOptionSpecifications>(node);
        }

        public virtual void Visit(DataCompressionOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DataCompressionOption node) {
            this.Start<DataCompressionOption>(node);
            if (this._visitBaseType) {
                this.Visit((IndexOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DataCompressionOption>(node);
        }

        public virtual void Visit(CompressionPartitionRange node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CompressionPartitionRange node) {
            this.Start<CompressionPartitionRange>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CompressionPartitionRange>(node);
        }

        public virtual void Visit(CheckConstraintDefinition node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CheckConstraintDefinition node) {
            this.Start<CheckConstraintDefinition>(node);
            if (this._visitBaseType) {
                this.Visit((ConstraintDefinition)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CheckConstraintDefinition>(node);
        }

        public virtual void Visit(DefaultConstraintDefinition node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DefaultConstraintDefinition node) {
            this.Start<DefaultConstraintDefinition>(node);
            if (this._visitBaseType) {
                this.Visit((ConstraintDefinition)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DefaultConstraintDefinition>(node);
        }

        public virtual void Visit(ForeignKeyConstraintDefinition node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ForeignKeyConstraintDefinition node) {
            this.Start<ForeignKeyConstraintDefinition>(node);
            if (this._visitBaseType) {
                this.Visit((ConstraintDefinition)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ForeignKeyConstraintDefinition>(node);
        }

        public virtual void Visit(NullableConstraintDefinition node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(NullableConstraintDefinition node) {
            this.Start<NullableConstraintDefinition>(node);
            if (this._visitBaseType) {
                this.Visit((ConstraintDefinition)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<NullableConstraintDefinition>(node);
        }

        public virtual void Visit(UniqueConstraintDefinition node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(UniqueConstraintDefinition node) {
            this.Start<UniqueConstraintDefinition>(node);
            if (this._visitBaseType) {
                this.Visit((ConstraintDefinition)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<UniqueConstraintDefinition>(node);
        }

        public virtual void Visit(BackupStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BackupStatement node) {
            this.Start<BackupStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BackupStatement>(node);
        }

        public virtual void Visit(BackupDatabaseStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BackupDatabaseStatement node) {
            this.Start<BackupDatabaseStatement>(node);
            if (this._visitBaseType) {
                this.Visit((BackupStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BackupDatabaseStatement>(node);
        }

        public virtual void Visit(BackupTransactionLogStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BackupTransactionLogStatement node) {
            this.Start<BackupTransactionLogStatement>(node);
            if (this._visitBaseType) {
                this.Visit((BackupStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BackupTransactionLogStatement>(node);
        }

        public virtual void Visit(RestoreStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(RestoreStatement node) {
            this.Start<RestoreStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<RestoreStatement>(node);
        }

        public virtual void Visit(RestoreOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(RestoreOption node) {
            this.Start<RestoreOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<RestoreOption>(node);
        }

        public virtual void Visit(ScalarExpressionRestoreOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ScalarExpressionRestoreOption node) {
            this.Start<ScalarExpressionRestoreOption>(node);
            if (this._visitBaseType) {
                this.Visit((RestoreOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ScalarExpressionRestoreOption>(node);
        }

        public virtual void Visit(MoveRestoreOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(MoveRestoreOption node) {
            this.Start<MoveRestoreOption>(node);
            if (this._visitBaseType) {
                this.Visit((RestoreOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<MoveRestoreOption>(node);
        }

        public virtual void Visit(StopRestoreOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(StopRestoreOption node) {
            this.Start<StopRestoreOption>(node);
            if (this._visitBaseType) {
                this.Visit((RestoreOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<StopRestoreOption>(node);
        }

        public virtual void Visit(FileStreamRestoreOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FileStreamRestoreOption node) {
            this.Start<FileStreamRestoreOption>(node);
            if (this._visitBaseType) {
                this.Visit((RestoreOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FileStreamRestoreOption>(node);
        }

        public virtual void Visit(BackupOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BackupOption node) {
            this.Start<BackupOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BackupOption>(node);
        }

        public virtual void Visit(BackupEncryptionOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BackupEncryptionOption node) {
            this.Start<BackupEncryptionOption>(node);
            if (this._visitBaseType) {
                this.Visit((BackupOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BackupEncryptionOption>(node);
        }

        public virtual void Visit(DeviceInfo node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DeviceInfo node) {
            this.Start<DeviceInfo>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DeviceInfo>(node);
        }

        public virtual void Visit(MirrorToClause node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(MirrorToClause node) {
            this.Start<MirrorToClause>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<MirrorToClause>(node);
        }

        public virtual void Visit(BackupRestoreFileInfo node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BackupRestoreFileInfo node) {
            this.Start<BackupRestoreFileInfo>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BackupRestoreFileInfo>(node);
        }

        public virtual void Visit(BulkInsertBase node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BulkInsertBase node) {
            this.Start<BulkInsertBase>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BulkInsertBase>(node);
        }

        public virtual void Visit(BulkInsertStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BulkInsertStatement node) {
            this.Start<BulkInsertStatement>(node);
            if (this._visitBaseType) {
                this.Visit((BulkInsertBase)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BulkInsertStatement>(node);
        }

        public virtual void Visit(InsertBulkStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(InsertBulkStatement node) {
            this.Start<InsertBulkStatement>(node);
            if (this._visitBaseType) {
                this.Visit((BulkInsertBase)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<InsertBulkStatement>(node);
        }

        public virtual void Visit(BulkInsertOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BulkInsertOption node) {
            this.Start<BulkInsertOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BulkInsertOption>(node);
        }

        public virtual void Visit(LiteralBulkInsertOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(LiteralBulkInsertOption node) {
            this.Start<LiteralBulkInsertOption>(node);
            if (this._visitBaseType) {
                this.Visit((BulkInsertOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<LiteralBulkInsertOption>(node);
        }

        public virtual void Visit(OrderBulkInsertOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OrderBulkInsertOption node) {
            this.Start<OrderBulkInsertOption>(node);
            if (this._visitBaseType) {
                this.Visit((BulkInsertOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OrderBulkInsertOption>(node);
        }

        public virtual void Visit(ColumnDefinitionBase node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ColumnDefinitionBase node) {
            this.Start<ColumnDefinitionBase>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ColumnDefinitionBase>(node);
        }

        public virtual void Visit(ExternalTableColumnDefinition node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExternalTableColumnDefinition node) {
            this.Start<ExternalTableColumnDefinition>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExternalTableColumnDefinition>(node);
        }

        public virtual void Visit(InsertBulkColumnDefinition node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(InsertBulkColumnDefinition node) {
            this.Start<InsertBulkColumnDefinition>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<InsertBulkColumnDefinition>(node);
        }

        public virtual void Visit(DbccStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DbccStatement node) {
            this.Start<DbccStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DbccStatement>(node);
        }

        public virtual void Visit(DbccOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DbccOption node) {
            this.Start<DbccOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DbccOption>(node);
        }

        public virtual void Visit(DbccNamedLiteral node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DbccNamedLiteral node) {
            this.Start<DbccNamedLiteral>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DbccNamedLiteral>(node);
        }

        public virtual void Visit(CreateAsymmetricKeyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateAsymmetricKeyStatement node) {
            this.Start<CreateAsymmetricKeyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateAsymmetricKeyStatement>(node);
        }

        public virtual void Visit(CreatePartitionFunctionStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreatePartitionFunctionStatement node) {
            this.Start<CreatePartitionFunctionStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreatePartitionFunctionStatement>(node);
        }

        public virtual void Visit(PartitionParameterType node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(PartitionParameterType node) {
            this.Start<PartitionParameterType>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<PartitionParameterType>(node);
        }

        public virtual void Visit(CreatePartitionSchemeStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreatePartitionSchemeStatement node) {
            this.Start<CreatePartitionSchemeStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreatePartitionSchemeStatement>(node);
        }

        public virtual void Visit(RemoteServiceBindingStatementBase node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(RemoteServiceBindingStatementBase node) {
            this.Start<RemoteServiceBindingStatementBase>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<RemoteServiceBindingStatementBase>(node);
        }

        public virtual void Visit(RemoteServiceBindingOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(RemoteServiceBindingOption node) {
            this.Start<RemoteServiceBindingOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<RemoteServiceBindingOption>(node);
        }

        public virtual void Visit(OnOffRemoteServiceBindingOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OnOffRemoteServiceBindingOption node) {
            this.Start<OnOffRemoteServiceBindingOption>(node);
            if (this._visitBaseType) {
                this.Visit((RemoteServiceBindingOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OnOffRemoteServiceBindingOption>(node);
        }

        public virtual void Visit(UserRemoteServiceBindingOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(UserRemoteServiceBindingOption node) {
            this.Start<UserRemoteServiceBindingOption>(node);
            if (this._visitBaseType) {
                this.Visit((RemoteServiceBindingOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<UserRemoteServiceBindingOption>(node);
        }

        public virtual void Visit(CreateRemoteServiceBindingStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateRemoteServiceBindingStatement node) {
            this.Start<CreateRemoteServiceBindingStatement>(node);
            if (this._visitBaseType) {
                this.Visit((RemoteServiceBindingStatementBase)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateRemoteServiceBindingStatement>(node);
        }

        public virtual void Visit(AlterRemoteServiceBindingStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterRemoteServiceBindingStatement node) {
            this.Start<AlterRemoteServiceBindingStatement>(node);
            if (this._visitBaseType) {
                this.Visit((RemoteServiceBindingStatementBase)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterRemoteServiceBindingStatement>(node);
        }

        public virtual void Visit(EncryptionSource node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(EncryptionSource node) {
            this.Start<EncryptionSource>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<EncryptionSource>(node);
        }

        public virtual void Visit(AssemblyEncryptionSource node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AssemblyEncryptionSource node) {
            this.Start<AssemblyEncryptionSource>(node);
            if (this._visitBaseType) {
                this.Visit((EncryptionSource)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AssemblyEncryptionSource>(node);
        }

        public virtual void Visit(FileEncryptionSource node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FileEncryptionSource node) {
            this.Start<FileEncryptionSource>(node);
            if (this._visitBaseType) {
                this.Visit((EncryptionSource)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FileEncryptionSource>(node);
        }

        public virtual void Visit(ProviderEncryptionSource node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ProviderEncryptionSource node) {
            this.Start<ProviderEncryptionSource>(node);
            if (this._visitBaseType) {
                this.Visit((EncryptionSource)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ProviderEncryptionSource>(node);
        }

        public virtual void Visit(CertificateStatementBase node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CertificateStatementBase node) {
            this.Start<CertificateStatementBase>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CertificateStatementBase>(node);
        }

        public virtual void Visit(AlterCertificateStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterCertificateStatement node) {
            this.Start<AlterCertificateStatement>(node);
            if (this._visitBaseType) {
                this.Visit((CertificateStatementBase)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterCertificateStatement>(node);
        }

        public virtual void Visit(CreateCertificateStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateCertificateStatement node) {
            this.Start<CreateCertificateStatement>(node);
            if (this._visitBaseType) {
                this.Visit((CertificateStatementBase)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateCertificateStatement>(node);
        }

        public virtual void Visit(CertificateOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CertificateOption node) {
            this.Start<CertificateOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CertificateOption>(node);
        }

        public virtual void Visit(CreateContractStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateContractStatement node) {
            this.Start<CreateContractStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateContractStatement>(node);
        }

        public virtual void Visit(ContractMessage node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ContractMessage node) {
            this.Start<ContractMessage>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ContractMessage>(node);
        }

        public virtual void Visit(CredentialStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CredentialStatement node) {
            this.Start<CredentialStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CredentialStatement>(node);
        }

        public virtual void Visit(CreateCredentialStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateCredentialStatement node) {
            this.Start<CreateCredentialStatement>(node);
            if (this._visitBaseType) {
                this.Visit((CredentialStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateCredentialStatement>(node);
        }

        public virtual void Visit(AlterCredentialStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterCredentialStatement node) {
            this.Start<AlterCredentialStatement>(node);
            if (this._visitBaseType) {
                this.Visit((CredentialStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterCredentialStatement>(node);
        }

        public virtual void Visit(MessageTypeStatementBase node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(MessageTypeStatementBase node) {
            this.Start<MessageTypeStatementBase>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<MessageTypeStatementBase>(node);
        }

        public virtual void Visit(CreateMessageTypeStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateMessageTypeStatement node) {
            this.Start<CreateMessageTypeStatement>(node);
            if (this._visitBaseType) {
                this.Visit((MessageTypeStatementBase)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateMessageTypeStatement>(node);
        }

        public virtual void Visit(AlterMessageTypeStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterMessageTypeStatement node) {
            this.Start<AlterMessageTypeStatement>(node);
            if (this._visitBaseType) {
                this.Visit((MessageTypeStatementBase)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterMessageTypeStatement>(node);
        }

        public virtual void Visit(CreateAggregateStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateAggregateStatement node) {
            this.Start<CreateAggregateStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateAggregateStatement>(node);
        }

        public virtual void Visit(CreateEndpointStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateEndpointStatement node) {
            this.Start<CreateEndpointStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterCreateEndpointStatementBase)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateEndpointStatement>(node);
        }

        public virtual void Visit(AlterEndpointStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterEndpointStatement node) {
            this.Start<AlterEndpointStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterCreateEndpointStatementBase)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterEndpointStatement>(node);
        }

        public virtual void Visit(AlterCreateEndpointStatementBase node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterCreateEndpointStatementBase node) {
            this.Start<AlterCreateEndpointStatementBase>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterCreateEndpointStatementBase>(node);
        }

        public virtual void Visit(EndpointAffinity node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(EndpointAffinity node) {
            this.Start<EndpointAffinity>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<EndpointAffinity>(node);
        }

        public virtual void Visit(EndpointProtocolOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(EndpointProtocolOption node) {
            this.Start<EndpointProtocolOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<EndpointProtocolOption>(node);
        }

        public virtual void Visit(LiteralEndpointProtocolOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(LiteralEndpointProtocolOption node) {
            this.Start<LiteralEndpointProtocolOption>(node);
            if (this._visitBaseType) {
                this.Visit((EndpointProtocolOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<LiteralEndpointProtocolOption>(node);
        }

        public virtual void Visit(AuthenticationEndpointProtocolOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AuthenticationEndpointProtocolOption node) {
            this.Start<AuthenticationEndpointProtocolOption>(node);
            if (this._visitBaseType) {
                this.Visit((EndpointProtocolOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AuthenticationEndpointProtocolOption>(node);
        }

        public virtual void Visit(PortsEndpointProtocolOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(PortsEndpointProtocolOption node) {
            this.Start<PortsEndpointProtocolOption>(node);
            if (this._visitBaseType) {
                this.Visit((EndpointProtocolOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<PortsEndpointProtocolOption>(node);
        }

        public virtual void Visit(CompressionEndpointProtocolOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CompressionEndpointProtocolOption node) {
            this.Start<CompressionEndpointProtocolOption>(node);
            if (this._visitBaseType) {
                this.Visit((EndpointProtocolOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CompressionEndpointProtocolOption>(node);
        }

        public virtual void Visit(ListenerIPEndpointProtocolOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ListenerIPEndpointProtocolOption node) {
            this.Start<ListenerIPEndpointProtocolOption>(node);
            if (this._visitBaseType) {
                this.Visit((EndpointProtocolOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ListenerIPEndpointProtocolOption>(node);
        }

        public virtual void Visit(IPv4 node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(IPv4 node) {
            this.Start<IPv4>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<IPv4>(node);
        }

        public virtual void Visit(SoapMethod node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SoapMethod node) {
            this.Start<SoapMethod>(node);
            if (this._visitBaseType) {
                this.Visit((PayloadOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SoapMethod>(node);
        }

        public virtual void Visit(PayloadOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(PayloadOption node) {
            this.Start<PayloadOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<PayloadOption>(node);
        }

        public virtual void Visit(EnabledDisabledPayloadOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(EnabledDisabledPayloadOption node) {
            this.Start<EnabledDisabledPayloadOption>(node);
            if (this._visitBaseType) {
                this.Visit((PayloadOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<EnabledDisabledPayloadOption>(node);
        }

        public virtual void Visit(WsdlPayloadOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(WsdlPayloadOption node) {
            this.Start<WsdlPayloadOption>(node);
            if (this._visitBaseType) {
                this.Visit((PayloadOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<WsdlPayloadOption>(node);
        }

        public virtual void Visit(LoginTypePayloadOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(LoginTypePayloadOption node) {
            this.Start<LoginTypePayloadOption>(node);
            if (this._visitBaseType) {
                this.Visit((PayloadOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<LoginTypePayloadOption>(node);
        }

        public virtual void Visit(LiteralPayloadOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(LiteralPayloadOption node) {
            this.Start<LiteralPayloadOption>(node);
            if (this._visitBaseType) {
                this.Visit((PayloadOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<LiteralPayloadOption>(node);
        }

        public virtual void Visit(SessionTimeoutPayloadOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SessionTimeoutPayloadOption node) {
            this.Start<SessionTimeoutPayloadOption>(node);
            if (this._visitBaseType) {
                this.Visit((PayloadOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SessionTimeoutPayloadOption>(node);
        }

        public virtual void Visit(SchemaPayloadOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SchemaPayloadOption node) {
            this.Start<SchemaPayloadOption>(node);
            if (this._visitBaseType) {
                this.Visit((PayloadOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SchemaPayloadOption>(node);
        }

        public virtual void Visit(CharacterSetPayloadOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CharacterSetPayloadOption node) {
            this.Start<CharacterSetPayloadOption>(node);
            if (this._visitBaseType) {
                this.Visit((PayloadOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CharacterSetPayloadOption>(node);
        }

        public virtual void Visit(RolePayloadOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(RolePayloadOption node) {
            this.Start<RolePayloadOption>(node);
            if (this._visitBaseType) {
                this.Visit((PayloadOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<RolePayloadOption>(node);
        }

        public virtual void Visit(AuthenticationPayloadOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AuthenticationPayloadOption node) {
            this.Start<AuthenticationPayloadOption>(node);
            if (this._visitBaseType) {
                this.Visit((PayloadOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AuthenticationPayloadOption>(node);
        }

        public virtual void Visit(EncryptionPayloadOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(EncryptionPayloadOption node) {
            this.Start<EncryptionPayloadOption>(node);
            if (this._visitBaseType) {
                this.Visit((PayloadOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<EncryptionPayloadOption>(node);
        }

        public virtual void Visit(SymmetricKeyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SymmetricKeyStatement node) {
            this.Start<SymmetricKeyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SymmetricKeyStatement>(node);
        }

        public virtual void Visit(CreateSymmetricKeyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateSymmetricKeyStatement node) {
            this.Start<CreateSymmetricKeyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((SymmetricKeyStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateSymmetricKeyStatement>(node);
        }

        public virtual void Visit(KeyOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(KeyOption node) {
            this.Start<KeyOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<KeyOption>(node);
        }

        public virtual void Visit(KeySourceKeyOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(KeySourceKeyOption node) {
            this.Start<KeySourceKeyOption>(node);
            if (this._visitBaseType) {
                this.Visit((KeyOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<KeySourceKeyOption>(node);
        }

        public virtual void Visit(AlgorithmKeyOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlgorithmKeyOption node) {
            this.Start<AlgorithmKeyOption>(node);
            if (this._visitBaseType) {
                this.Visit((KeyOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlgorithmKeyOption>(node);
        }

        public virtual void Visit(IdentityValueKeyOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(IdentityValueKeyOption node) {
            this.Start<IdentityValueKeyOption>(node);
            if (this._visitBaseType) {
                this.Visit((KeyOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<IdentityValueKeyOption>(node);
        }

        public virtual void Visit(ProviderKeyNameKeyOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ProviderKeyNameKeyOption node) {
            this.Start<ProviderKeyNameKeyOption>(node);
            if (this._visitBaseType) {
                this.Visit((KeyOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ProviderKeyNameKeyOption>(node);
        }

        public virtual void Visit(CreationDispositionKeyOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreationDispositionKeyOption node) {
            this.Start<CreationDispositionKeyOption>(node);
            if (this._visitBaseType) {
                this.Visit((KeyOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreationDispositionKeyOption>(node);
        }

        public virtual void Visit(AlterSymmetricKeyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterSymmetricKeyStatement node) {
            this.Start<AlterSymmetricKeyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((SymmetricKeyStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterSymmetricKeyStatement>(node);
        }

        public virtual void Visit(FullTextCatalogStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FullTextCatalogStatement node) {
            this.Start<FullTextCatalogStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FullTextCatalogStatement>(node);
        }

        public virtual void Visit(FullTextCatalogOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FullTextCatalogOption node) {
            this.Start<FullTextCatalogOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FullTextCatalogOption>(node);
        }

        public virtual void Visit(OnOffFullTextCatalogOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OnOffFullTextCatalogOption node) {
            this.Start<OnOffFullTextCatalogOption>(node);
            if (this._visitBaseType) {
                this.Visit((FullTextCatalogOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OnOffFullTextCatalogOption>(node);
        }

        public virtual void Visit(CreateFullTextCatalogStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateFullTextCatalogStatement node) {
            this.Start<CreateFullTextCatalogStatement>(node);
            if (this._visitBaseType) {
                this.Visit((FullTextCatalogStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateFullTextCatalogStatement>(node);
        }

        public virtual void Visit(AlterFullTextCatalogStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterFullTextCatalogStatement node) {
            this.Start<AlterFullTextCatalogStatement>(node);
            if (this._visitBaseType) {
                this.Visit((FullTextCatalogStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterFullTextCatalogStatement>(node);
        }

        public virtual void Visit(AlterCreateServiceStatementBase node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterCreateServiceStatementBase node) {
            this.Start<AlterCreateServiceStatementBase>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterCreateServiceStatementBase>(node);
        }

        public virtual void Visit(CreateServiceStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateServiceStatement node) {
            this.Start<CreateServiceStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterCreateServiceStatementBase)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateServiceStatement>(node);
        }

        public virtual void Visit(AlterServiceStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterServiceStatement node) {
            this.Start<AlterServiceStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterCreateServiceStatementBase)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterServiceStatement>(node);
        }

        public virtual void Visit(ServiceContract node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ServiceContract node) {
            this.Start<ServiceContract>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ServiceContract>(node);
        }

        public virtual void Visit(BinaryExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BinaryExpression node) {
            this.Start<BinaryExpression>(node);
            if (this._visitBaseType) {
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BinaryExpression>(node);
        }

        public virtual void Visit(BuiltInFunctionTableReference node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BuiltInFunctionTableReference node) {
            this.Start<BuiltInFunctionTableReference>(node);
            if (this._visitBaseType) {
                this.Visit((TableReferenceWithAlias)node);
                this.Visit((TableReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BuiltInFunctionTableReference>(node);
        }

        public virtual void Visit(GlobalFunctionTableReference node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(GlobalFunctionTableReference node) {
            this.Start<GlobalFunctionTableReference>(node);
            if (this._visitBaseType) {
                this.Visit((TableReferenceWithAlias)node);
                this.Visit((TableReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<GlobalFunctionTableReference>(node);
        }

        public virtual void Visit(ComputeClause node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ComputeClause node) {
            this.Start<ComputeClause>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ComputeClause>(node);
        }

        public virtual void Visit(ComputeFunction node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ComputeFunction node) {
            this.Start<ComputeFunction>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ComputeFunction>(node);
        }

        public virtual void Visit(PivotedTableReference node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(PivotedTableReference node) {
            this.Start<PivotedTableReference>(node);
            if (this._visitBaseType) {
                this.Visit((TableReferenceWithAlias)node);
                this.Visit((TableReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<PivotedTableReference>(node);
        }

        public virtual void Visit(UnpivotedTableReference node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(UnpivotedTableReference node) {
            this.Start<UnpivotedTableReference>(node);
            if (this._visitBaseType) {
                this.Visit((TableReferenceWithAlias)node);
                this.Visit((TableReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<UnpivotedTableReference>(node);
        }

        public virtual void Visit(UnqualifiedJoin node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(UnqualifiedJoin node) {
            this.Start<UnqualifiedJoin>(node);
            if (this._visitBaseType) {
                this.Visit((JoinTableReference)node);
                this.Visit((TableReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<UnqualifiedJoin>(node);
        }

        public virtual void Visit(TableSampleClause node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TableSampleClause node) {
            this.Start<TableSampleClause>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TableSampleClause>(node);
        }

        public virtual void Visit(ScalarExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ScalarExpression node) {
            this.Start<ScalarExpression>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ScalarExpression>(node);
        }

        public virtual void Visit(BooleanExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BooleanExpression node) {
            this.Start<BooleanExpression>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BooleanExpression>(node);
        }

        public virtual void Visit(BooleanNotExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BooleanNotExpression node) {
            this.Start<BooleanNotExpression>(node);
            if (this._visitBaseType) {
                this.Visit((BooleanExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BooleanNotExpression>(node);
        }

        public virtual void Visit(BooleanParenthesisExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BooleanParenthesisExpression node) {
            this.Start<BooleanParenthesisExpression>(node);
            if (this._visitBaseType) {
                this.Visit((BooleanExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BooleanParenthesisExpression>(node);
        }

        public virtual void Visit(BooleanComparisonExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BooleanComparisonExpression node) {
            this.Start<BooleanComparisonExpression>(node);
            if (this._visitBaseType) {
                this.Visit((BooleanExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BooleanComparisonExpression>(node);
        }

        public virtual void Visit(BooleanBinaryExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BooleanBinaryExpression node) {
            this.Start<BooleanBinaryExpression>(node);
            if (this._visitBaseType) {
                this.Visit((BooleanExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BooleanBinaryExpression>(node);
        }

        public virtual void Visit(BooleanIsNullExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BooleanIsNullExpression node) {
            this.Start<BooleanIsNullExpression>(node);
            if (this._visitBaseType) {
                this.Visit((BooleanExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BooleanIsNullExpression>(node);
        }

        public virtual void Visit(GraphMatchPredicate node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(GraphMatchPredicate node) {
            this.Start<GraphMatchPredicate>(node);
            if (this._visitBaseType) {
                this.Visit((BooleanExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<GraphMatchPredicate>(node);
        }

        public virtual void Visit(GraphMatchExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(GraphMatchExpression node) {
            this.Start<GraphMatchExpression>(node);
            if (this._visitBaseType) {
                this.Visit((BooleanExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<GraphMatchExpression>(node);
        }

        public virtual void Visit(ExpressionWithSortOrder node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExpressionWithSortOrder node) {
            this.Start<ExpressionWithSortOrder>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExpressionWithSortOrder>(node);
        }

        public virtual void Visit(GroupByClause node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(GroupByClause node) {
            this.Start<GroupByClause>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<GroupByClause>(node);
        }

        public virtual void Visit(GroupingSpecification node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(GroupingSpecification node) {
            this.Start<GroupingSpecification>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<GroupingSpecification>(node);
        }

        public virtual void Visit(ExpressionGroupingSpecification node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExpressionGroupingSpecification node) {
            this.Start<ExpressionGroupingSpecification>(node);
            if (this._visitBaseType) {
                this.Visit((GroupingSpecification)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExpressionGroupingSpecification>(node);
        }

        public virtual void Visit(CompositeGroupingSpecification node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CompositeGroupingSpecification node) {
            this.Start<CompositeGroupingSpecification>(node);
            if (this._visitBaseType) {
                this.Visit((GroupingSpecification)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CompositeGroupingSpecification>(node);
        }

        public virtual void Visit(CubeGroupingSpecification node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CubeGroupingSpecification node) {
            this.Start<CubeGroupingSpecification>(node);
            if (this._visitBaseType) {
                this.Visit((GroupingSpecification)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CubeGroupingSpecification>(node);
        }

        public virtual void Visit(RollupGroupingSpecification node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(RollupGroupingSpecification node) {
            this.Start<RollupGroupingSpecification>(node);
            if (this._visitBaseType) {
                this.Visit((GroupingSpecification)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<RollupGroupingSpecification>(node);
        }

        public virtual void Visit(GrandTotalGroupingSpecification node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(GrandTotalGroupingSpecification node) {
            this.Start<GrandTotalGroupingSpecification>(node);
            if (this._visitBaseType) {
                this.Visit((GroupingSpecification)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<GrandTotalGroupingSpecification>(node);
        }

        public virtual void Visit(GroupingSetsGroupingSpecification node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(GroupingSetsGroupingSpecification node) {
            this.Start<GroupingSetsGroupingSpecification>(node);
            if (this._visitBaseType) {
                this.Visit((GroupingSpecification)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<GroupingSetsGroupingSpecification>(node);
        }

        public virtual void Visit(OutputClause node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OutputClause node) {
            this.Start<OutputClause>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OutputClause>(node);
        }

        public virtual void Visit(OutputIntoClause node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OutputIntoClause node) {
            this.Start<OutputIntoClause>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OutputIntoClause>(node);
        }

        public virtual void Visit(HavingClause node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(HavingClause node) {
            this.Start<HavingClause>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<HavingClause>(node);
        }

        public virtual void Visit(IdentityFunctionCall node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(IdentityFunctionCall node) {
            this.Start<IdentityFunctionCall>(node);
            if (this._visitBaseType) {
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<IdentityFunctionCall>(node);
        }

        public virtual void Visit(JoinParenthesisTableReference node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(JoinParenthesisTableReference node) {
            this.Start<JoinParenthesisTableReference>(node);
            if (this._visitBaseType) {
                this.Visit((TableReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<JoinParenthesisTableReference>(node);
        }

        public virtual void Visit(OrderByClause node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OrderByClause node) {
            this.Start<OrderByClause>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OrderByClause>(node);
        }

        public virtual void Visit(JoinTableReference node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(JoinTableReference node) {
            this.Start<JoinTableReference>(node);
            if (this._visitBaseType) {
                this.Visit((TableReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<JoinTableReference>(node);
        }

        public virtual void Visit(QualifiedJoin node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(QualifiedJoin node) {
            this.Start<QualifiedJoin>(node);
            if (this._visitBaseType) {
                this.Visit((JoinTableReference)node);
                this.Visit((TableReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<QualifiedJoin>(node);
        }

        public virtual void Visit(OdbcQualifiedJoinTableReference node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OdbcQualifiedJoinTableReference node) {
            this.Start<OdbcQualifiedJoinTableReference>(node);
            if (this._visitBaseType) {
                this.Visit((TableReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OdbcQualifiedJoinTableReference>(node);
        }

        public virtual void Visit(QueryExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(QueryExpression node) {
            this.Start<QueryExpression>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<QueryExpression>(node);
        }

        public virtual void Visit(QueryParenthesisExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(QueryParenthesisExpression node) {
            this.Start<QueryParenthesisExpression>(node);
            if (this._visitBaseType) {
                this.Visit((QueryExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<QueryParenthesisExpression>(node);
        }

        public virtual void Visit(QuerySpecification node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(QuerySpecification node) {
            this.Start<QuerySpecification>(node);
            if (this._visitBaseType) {
                this.Visit((QueryExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<QuerySpecification>(node);
        }

        public virtual void Visit(FromClause node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FromClause node) {
            this.Start<FromClause>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FromClause>(node);
        }

        public virtual void Visit(SelectElement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SelectElement node) {
            this.Start<SelectElement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SelectElement>(node);
        }

        public virtual void Visit(SelectScalarExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SelectScalarExpression node) {
            this.Start<SelectScalarExpression>(node);
            if (this._visitBaseType) {
                this.Visit((SelectElement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SelectScalarExpression>(node);
        }

        public virtual void Visit(SelectStarExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SelectStarExpression node) {
            this.Start<SelectStarExpression>(node);
            if (this._visitBaseType) {
                this.Visit((SelectElement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SelectStarExpression>(node);
        }

        public virtual void Visit(SelectSetVariable node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SelectSetVariable node) {
            this.Start<SelectSetVariable>(node);
            if (this._visitBaseType) {
                this.Visit((SelectElement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SelectSetVariable>(node);
        }

        public virtual void Visit(TableReference node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TableReference node) {
            this.Start<TableReference>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TableReference>(node);
        }

        public virtual void Visit(TableReferenceWithAlias node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TableReferenceWithAlias node) {
            this.Start<TableReferenceWithAlias>(node);
            if (this._visitBaseType) {
                this.Visit((TableReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TableReferenceWithAlias>(node);
        }

        public virtual void Visit(TableReferenceWithAliasAndColumns node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TableReferenceWithAliasAndColumns node) {
            this.Start<TableReferenceWithAliasAndColumns>(node);
            if (this._visitBaseType) {
                this.Visit((TableReferenceWithAlias)node);
                this.Visit((TableReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TableReferenceWithAliasAndColumns>(node);
        }

        public virtual void Visit(DataModificationTableReference node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DataModificationTableReference node) {
            this.Start<DataModificationTableReference>(node);
            if (this._visitBaseType) {
                this.Visit((TableReferenceWithAliasAndColumns)node);
                this.Visit((TableReferenceWithAlias)node);
                this.Visit((TableReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DataModificationTableReference>(node);
        }

        public virtual void Visit(ChangeTableChangesTableReference node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ChangeTableChangesTableReference node) {
            this.Start<ChangeTableChangesTableReference>(node);
            if (this._visitBaseType) {
                this.Visit((TableReferenceWithAliasAndColumns)node);
                this.Visit((TableReferenceWithAlias)node);
                this.Visit((TableReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ChangeTableChangesTableReference>(node);
        }

        public virtual void Visit(ChangeTableVersionTableReference node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ChangeTableVersionTableReference node) {
            this.Start<ChangeTableVersionTableReference>(node);
            if (this._visitBaseType) {
                this.Visit((TableReferenceWithAliasAndColumns)node);
                this.Visit((TableReferenceWithAlias)node);
                this.Visit((TableReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ChangeTableVersionTableReference>(node);
        }

        public virtual void Visit(BooleanTernaryExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BooleanTernaryExpression node) {
            this.Start<BooleanTernaryExpression>(node);
            if (this._visitBaseType) {
                this.Visit((BooleanExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BooleanTernaryExpression>(node);
        }

        public virtual void Visit(TopRowFilter node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TopRowFilter node) {
            this.Start<TopRowFilter>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TopRowFilter>(node);
        }

        public virtual void Visit(OffsetClause node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OffsetClause node) {
            this.Start<OffsetClause>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OffsetClause>(node);
        }

        public virtual void Visit(UnaryExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(UnaryExpression node) {
            this.Start<UnaryExpression>(node);
            if (this._visitBaseType) {
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<UnaryExpression>(node);
        }

        public virtual void Visit(BinaryQueryExpression node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BinaryQueryExpression node) {
            this.Start<BinaryQueryExpression>(node);
            if (this._visitBaseType) {
                this.Visit((QueryExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BinaryQueryExpression>(node);
        }

        public virtual void Visit(VariableTableReference node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(VariableTableReference node) {
            this.Start<VariableTableReference>(node);
            if (this._visitBaseType) {
                this.Visit((TableReferenceWithAlias)node);
                this.Visit((TableReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<VariableTableReference>(node);
        }

        public virtual void Visit(VariableMethodCallTableReference node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(VariableMethodCallTableReference node) {
            this.Start<VariableMethodCallTableReference>(node);
            if (this._visitBaseType) {
                this.Visit((TableReferenceWithAliasAndColumns)node);
                this.Visit((TableReferenceWithAlias)node);
                this.Visit((TableReference)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<VariableMethodCallTableReference>(node);
        }

        public virtual void Visit(DropPartitionFunctionStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropPartitionFunctionStatement node) {
            this.Start<DropPartitionFunctionStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropPartitionFunctionStatement>(node);
        }

        public virtual void Visit(DropPartitionSchemeStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropPartitionSchemeStatement node) {
            this.Start<DropPartitionSchemeStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropPartitionSchemeStatement>(node);
        }

        public virtual void Visit(DropSynonymStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropSynonymStatement node) {
            this.Start<DropSynonymStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropObjectsStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropSynonymStatement>(node);
        }

        public virtual void Visit(DropAggregateStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropAggregateStatement node) {
            this.Start<DropAggregateStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropObjectsStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropAggregateStatement>(node);
        }

        public virtual void Visit(DropAssemblyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropAssemblyStatement node) {
            this.Start<DropAssemblyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropObjectsStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropAssemblyStatement>(node);
        }

        public virtual void Visit(DropApplicationRoleStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropApplicationRoleStatement node) {
            this.Start<DropApplicationRoleStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropApplicationRoleStatement>(node);
        }

        public virtual void Visit(DropFullTextCatalogStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropFullTextCatalogStatement node) {
            this.Start<DropFullTextCatalogStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropFullTextCatalogStatement>(node);
        }

        public virtual void Visit(DropFullTextIndexStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropFullTextIndexStatement node) {
            this.Start<DropFullTextIndexStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropFullTextIndexStatement>(node);
        }

        public virtual void Visit(DropLoginStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropLoginStatement node) {
            this.Start<DropLoginStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropLoginStatement>(node);
        }

        public virtual void Visit(DropRoleStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropRoleStatement node) {
            this.Start<DropRoleStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropRoleStatement>(node);
        }

        public virtual void Visit(DropTypeStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropTypeStatement node) {
            this.Start<DropTypeStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropTypeStatement>(node);
        }

        public virtual void Visit(DropUserStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropUserStatement node) {
            this.Start<DropUserStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropUserStatement>(node);
        }

        public virtual void Visit(DropMasterKeyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropMasterKeyStatement node) {
            this.Start<DropMasterKeyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropMasterKeyStatement>(node);
        }

        public virtual void Visit(DropSymmetricKeyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropSymmetricKeyStatement node) {
            this.Start<DropSymmetricKeyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropSymmetricKeyStatement>(node);
        }

        public virtual void Visit(DropAsymmetricKeyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropAsymmetricKeyStatement node) {
            this.Start<DropAsymmetricKeyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropAsymmetricKeyStatement>(node);
        }

        public virtual void Visit(DropCertificateStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropCertificateStatement node) {
            this.Start<DropCertificateStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropCertificateStatement>(node);
        }

        public virtual void Visit(DropCredentialStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropCredentialStatement node) {
            this.Start<DropCredentialStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropCredentialStatement>(node);
        }

        public virtual void Visit(AlterPartitionFunctionStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterPartitionFunctionStatement node) {
            this.Start<AlterPartitionFunctionStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterPartitionFunctionStatement>(node);
        }

        public virtual void Visit(AlterPartitionSchemeStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterPartitionSchemeStatement node) {
            this.Start<AlterPartitionSchemeStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterPartitionSchemeStatement>(node);
        }

        public virtual void Visit(AlterFullTextIndexStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterFullTextIndexStatement node) {
            this.Start<AlterFullTextIndexStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterFullTextIndexStatement>(node);
        }

        public virtual void Visit(AlterFullTextIndexAction node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterFullTextIndexAction node) {
            this.Start<AlterFullTextIndexAction>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterFullTextIndexAction>(node);
        }

        public virtual void Visit(SimpleAlterFullTextIndexAction node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SimpleAlterFullTextIndexAction node) {
            this.Start<SimpleAlterFullTextIndexAction>(node);
            if (this._visitBaseType) {
                this.Visit((AlterFullTextIndexAction)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SimpleAlterFullTextIndexAction>(node);
        }

        public virtual void Visit(SetStopListAlterFullTextIndexAction node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SetStopListAlterFullTextIndexAction node) {
            this.Start<SetStopListAlterFullTextIndexAction>(node);
            if (this._visitBaseType) {
                this.Visit((AlterFullTextIndexAction)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SetStopListAlterFullTextIndexAction>(node);
        }

        public virtual void Visit(SetSearchPropertyListAlterFullTextIndexAction node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SetSearchPropertyListAlterFullTextIndexAction node) {
            this.Start<SetSearchPropertyListAlterFullTextIndexAction>(node);
            if (this._visitBaseType) {
                this.Visit((AlterFullTextIndexAction)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SetSearchPropertyListAlterFullTextIndexAction>(node);
        }

        public virtual void Visit(DropAlterFullTextIndexAction node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropAlterFullTextIndexAction node) {
            this.Start<DropAlterFullTextIndexAction>(node);
            if (this._visitBaseType) {
                this.Visit((AlterFullTextIndexAction)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropAlterFullTextIndexAction>(node);
        }

        public virtual void Visit(AddAlterFullTextIndexAction node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AddAlterFullTextIndexAction node) {
            this.Start<AddAlterFullTextIndexAction>(node);
            if (this._visitBaseType) {
                this.Visit((AlterFullTextIndexAction)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AddAlterFullTextIndexAction>(node);
        }

        public virtual void Visit(AlterColumnAlterFullTextIndexAction node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterColumnAlterFullTextIndexAction node) {
            this.Start<AlterColumnAlterFullTextIndexAction>(node);
            if (this._visitBaseType) {
                this.Visit((AlterFullTextIndexAction)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterColumnAlterFullTextIndexAction>(node);
        }

        public virtual void Visit(CreateSearchPropertyListStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateSearchPropertyListStatement node) {
            this.Start<CreateSearchPropertyListStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateSearchPropertyListStatement>(node);
        }

        public virtual void Visit(AlterSearchPropertyListStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterSearchPropertyListStatement node) {
            this.Start<AlterSearchPropertyListStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterSearchPropertyListStatement>(node);
        }

        public virtual void Visit(SearchPropertyListAction node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SearchPropertyListAction node) {
            this.Start<SearchPropertyListAction>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SearchPropertyListAction>(node);
        }

        public virtual void Visit(AddSearchPropertyListAction node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AddSearchPropertyListAction node) {
            this.Start<AddSearchPropertyListAction>(node);
            if (this._visitBaseType) {
                this.Visit((SearchPropertyListAction)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AddSearchPropertyListAction>(node);
        }

        public virtual void Visit(DropSearchPropertyListAction node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropSearchPropertyListAction node) {
            this.Start<DropSearchPropertyListAction>(node);
            if (this._visitBaseType) {
                this.Visit((SearchPropertyListAction)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropSearchPropertyListAction>(node);
        }

        public virtual void Visit(DropSearchPropertyListStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropSearchPropertyListStatement node) {
            this.Start<DropSearchPropertyListStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropSearchPropertyListStatement>(node);
        }

        public virtual void Visit(CreateLoginStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateLoginStatement node) {
            this.Start<CreateLoginStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateLoginStatement>(node);
        }

        public virtual void Visit(CreateLoginSource node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateLoginSource node) {
            this.Start<CreateLoginSource>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateLoginSource>(node);
        }

        public virtual void Visit(PasswordCreateLoginSource node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(PasswordCreateLoginSource node) {
            this.Start<PasswordCreateLoginSource>(node);
            if (this._visitBaseType) {
                this.Visit((CreateLoginSource)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<PasswordCreateLoginSource>(node);
        }

        public virtual void Visit(PrincipalOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(PrincipalOption node) {
            this.Start<PrincipalOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<PrincipalOption>(node);
        }

        public virtual void Visit(OnOffPrincipalOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OnOffPrincipalOption node) {
            this.Start<OnOffPrincipalOption>(node);
            if (this._visitBaseType) {
                this.Visit((PrincipalOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OnOffPrincipalOption>(node);
        }

        public virtual void Visit(LiteralPrincipalOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(LiteralPrincipalOption node) {
            this.Start<LiteralPrincipalOption>(node);
            if (this._visitBaseType) {
                this.Visit((PrincipalOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<LiteralPrincipalOption>(node);
        }

        public virtual void Visit(IdentifierPrincipalOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(IdentifierPrincipalOption node) {
            this.Start<IdentifierPrincipalOption>(node);
            if (this._visitBaseType) {
                this.Visit((PrincipalOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<IdentifierPrincipalOption>(node);
        }

        public virtual void Visit(WindowsCreateLoginSource node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(WindowsCreateLoginSource node) {
            this.Start<WindowsCreateLoginSource>(node);
            if (this._visitBaseType) {
                this.Visit((CreateLoginSource)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<WindowsCreateLoginSource>(node);
        }

        public virtual void Visit(CertificateCreateLoginSource node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CertificateCreateLoginSource node) {
            this.Start<CertificateCreateLoginSource>(node);
            if (this._visitBaseType) {
                this.Visit((CreateLoginSource)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CertificateCreateLoginSource>(node);
        }

        public virtual void Visit(AsymmetricKeyCreateLoginSource node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AsymmetricKeyCreateLoginSource node) {
            this.Start<AsymmetricKeyCreateLoginSource>(node);
            if (this._visitBaseType) {
                this.Visit((CreateLoginSource)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AsymmetricKeyCreateLoginSource>(node);
        }

        public virtual void Visit(PasswordAlterPrincipalOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(PasswordAlterPrincipalOption node) {
            this.Start<PasswordAlterPrincipalOption>(node);
            if (this._visitBaseType) {
                this.Visit((PrincipalOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<PasswordAlterPrincipalOption>(node);
        }

        public virtual void Visit(AlterLoginStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterLoginStatement node) {
            this.Start<AlterLoginStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterLoginStatement>(node);
        }

        public virtual void Visit(AlterLoginOptionsStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterLoginOptionsStatement node) {
            this.Start<AlterLoginOptionsStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterLoginStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterLoginOptionsStatement>(node);
        }

        public virtual void Visit(AlterLoginEnableDisableStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterLoginEnableDisableStatement node) {
            this.Start<AlterLoginEnableDisableStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterLoginStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterLoginEnableDisableStatement>(node);
        }

        public virtual void Visit(AlterLoginAddDropCredentialStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterLoginAddDropCredentialStatement node) {
            this.Start<AlterLoginAddDropCredentialStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AlterLoginStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterLoginAddDropCredentialStatement>(node);
        }

        public virtual void Visit(RevertStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(RevertStatement node) {
            this.Start<RevertStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<RevertStatement>(node);
        }

        public virtual void Visit(DropContractStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropContractStatement node) {
            this.Start<DropContractStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropContractStatement>(node);
        }

        public virtual void Visit(DropEndpointStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropEndpointStatement node) {
            this.Start<DropEndpointStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropEndpointStatement>(node);
        }

        public virtual void Visit(DropMessageTypeStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropMessageTypeStatement node) {
            this.Start<DropMessageTypeStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropMessageTypeStatement>(node);
        }

        public virtual void Visit(DropQueueStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropQueueStatement node) {
            this.Start<DropQueueStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropQueueStatement>(node);
        }

        public virtual void Visit(DropRemoteServiceBindingStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropRemoteServiceBindingStatement node) {
            this.Start<DropRemoteServiceBindingStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropRemoteServiceBindingStatement>(node);
        }

        public virtual void Visit(DropRouteStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropRouteStatement node) {
            this.Start<DropRouteStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropRouteStatement>(node);
        }

        public virtual void Visit(DropServiceStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropServiceStatement node) {
            this.Start<DropServiceStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropServiceStatement>(node);
        }

        public virtual void Visit(SignatureStatementBase node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SignatureStatementBase node) {
            this.Start<SignatureStatementBase>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SignatureStatementBase>(node);
        }

        public virtual void Visit(AddSignatureStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AddSignatureStatement node) {
            this.Start<AddSignatureStatement>(node);
            if (this._visitBaseType) {
                this.Visit((SignatureStatementBase)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AddSignatureStatement>(node);
        }

        public virtual void Visit(DropSignatureStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropSignatureStatement node) {
            this.Start<DropSignatureStatement>(node);
            if (this._visitBaseType) {
                this.Visit((SignatureStatementBase)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropSignatureStatement>(node);
        }

        public virtual void Visit(DropEventNotificationStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropEventNotificationStatement node) {
            this.Start<DropEventNotificationStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropEventNotificationStatement>(node);
        }

        public virtual void Visit(ExecuteAsStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExecuteAsStatement node) {
            this.Start<ExecuteAsStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExecuteAsStatement>(node);
        }

        public virtual void Visit(EndConversationStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(EndConversationStatement node) {
            this.Start<EndConversationStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<EndConversationStatement>(node);
        }

        public virtual void Visit(MoveConversationStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(MoveConversationStatement node) {
            this.Start<MoveConversationStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<MoveConversationStatement>(node);
        }

        public virtual void Visit(GetConversationGroupStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(GetConversationGroupStatement node) {
            this.Start<GetConversationGroupStatement>(node);
            if (this._visitBaseType) {
                this.Visit((WaitForSupportedStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<GetConversationGroupStatement>(node);
        }

        public virtual void Visit(ReceiveStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ReceiveStatement node) {
            this.Start<ReceiveStatement>(node);
            if (this._visitBaseType) {
                this.Visit((WaitForSupportedStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ReceiveStatement>(node);
        }

        public virtual void Visit(SendStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SendStatement node) {
            this.Start<SendStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SendStatement>(node);
        }

        public virtual void Visit(WaitForSupportedStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(WaitForSupportedStatement node) {
            this.Start<WaitForSupportedStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<WaitForSupportedStatement>(node);
        }

        public virtual void Visit(AlterSchemaStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterSchemaStatement node) {
            this.Start<AlterSchemaStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterSchemaStatement>(node);
        }

        public virtual void Visit(AlterAsymmetricKeyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterAsymmetricKeyStatement node) {
            this.Start<AlterAsymmetricKeyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterAsymmetricKeyStatement>(node);
        }

        public virtual void Visit(AlterServiceMasterKeyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterServiceMasterKeyStatement node) {
            this.Start<AlterServiceMasterKeyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterServiceMasterKeyStatement>(node);
        }

        public virtual void Visit(BeginConversationTimerStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BeginConversationTimerStatement node) {
            this.Start<BeginConversationTimerStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BeginConversationTimerStatement>(node);
        }

        public virtual void Visit(BeginDialogStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BeginDialogStatement node) {
            this.Start<BeginDialogStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BeginDialogStatement>(node);
        }

        public virtual void Visit(DialogOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DialogOption node) {
            this.Start<DialogOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DialogOption>(node);
        }

        public virtual void Visit(ScalarExpressionDialogOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ScalarExpressionDialogOption node) {
            this.Start<ScalarExpressionDialogOption>(node);
            if (this._visitBaseType) {
                this.Visit((DialogOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ScalarExpressionDialogOption>(node);
        }

        public virtual void Visit(OnOffDialogOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OnOffDialogOption node) {
            this.Start<OnOffDialogOption>(node);
            if (this._visitBaseType) {
                this.Visit((DialogOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OnOffDialogOption>(node);
        }

        public virtual void Visit(BackupCertificateStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BackupCertificateStatement node) {
            this.Start<BackupCertificateStatement>(node);
            if (this._visitBaseType) {
                this.Visit((CertificateStatementBase)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BackupCertificateStatement>(node);
        }

        public virtual void Visit(BackupRestoreMasterKeyStatementBase node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BackupRestoreMasterKeyStatementBase node) {
            this.Start<BackupRestoreMasterKeyStatementBase>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BackupRestoreMasterKeyStatementBase>(node);
        }

        public virtual void Visit(BackupServiceMasterKeyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BackupServiceMasterKeyStatement node) {
            this.Start<BackupServiceMasterKeyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((BackupRestoreMasterKeyStatementBase)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BackupServiceMasterKeyStatement>(node);
        }

        public virtual void Visit(RestoreServiceMasterKeyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(RestoreServiceMasterKeyStatement node) {
            this.Start<RestoreServiceMasterKeyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((BackupRestoreMasterKeyStatementBase)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<RestoreServiceMasterKeyStatement>(node);
        }

        public virtual void Visit(BackupMasterKeyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BackupMasterKeyStatement node) {
            this.Start<BackupMasterKeyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((BackupRestoreMasterKeyStatementBase)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BackupMasterKeyStatement>(node);
        }

        public virtual void Visit(RestoreMasterKeyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(RestoreMasterKeyStatement node) {
            this.Start<RestoreMasterKeyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((BackupRestoreMasterKeyStatementBase)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<RestoreMasterKeyStatement>(node);
        }

        public virtual void Visit(ScalarExpressionSnippet node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ScalarExpressionSnippet node) {
            this.Start<ScalarExpressionSnippet>(node);
            if (this._visitBaseType) {
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ScalarExpressionSnippet>(node);
        }

        public virtual void Visit(BooleanExpressionSnippet node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BooleanExpressionSnippet node) {
            this.Start<BooleanExpressionSnippet>(node);
            if (this._visitBaseType) {
                this.Visit((BooleanExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BooleanExpressionSnippet>(node);
        }

        public virtual void Visit(StatementListSnippet node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(StatementListSnippet node) {
            this.Start<StatementListSnippet>(node);
            if (this._visitBaseType) {
                this.Visit((StatementList)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<StatementListSnippet>(node);
        }

        public virtual void Visit(SelectStatementSnippet node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SelectStatementSnippet node) {
            this.Start<SelectStatementSnippet>(node);
            if (this._visitBaseType) {
                this.Visit((SelectStatement)node);
                this.Visit((StatementWithCtesAndXmlNamespaces)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SelectStatementSnippet>(node);
        }

        public virtual void Visit(SchemaObjectNameSnippet node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SchemaObjectNameSnippet node) {
            this.Start<SchemaObjectNameSnippet>(node);
            if (this._visitBaseType) {
                this.Visit((SchemaObjectName)node);
                this.Visit((MultiPartIdentifier)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SchemaObjectNameSnippet>(node);
        }

        public virtual void Visit(TSqlFragmentSnippet node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TSqlFragmentSnippet node) {
            this.Start<TSqlFragmentSnippet>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TSqlFragmentSnippet>(node);
        }

        public virtual void Visit(TSqlStatementSnippet node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TSqlStatementSnippet node) {
            this.Start<TSqlStatementSnippet>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TSqlStatementSnippet>(node);
        }

        public virtual void Visit(IdentifierSnippet node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(IdentifierSnippet node) {
            this.Start<IdentifierSnippet>(node);
            if (this._visitBaseType) {
                this.Visit((Identifier)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<IdentifierSnippet>(node);
        }

        public virtual void Visit(TSqlScript node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TSqlScript node) {
            this.Start<TSqlScript>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TSqlScript>(node);
        }

        public virtual void Visit(TSqlBatch node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TSqlBatch node) {
            this.Start<TSqlBatch>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TSqlBatch>(node);
        }

        public virtual void Visit(TSqlStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TSqlStatement node) {
            this.Start<TSqlStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TSqlStatement>(node);
        }

        public virtual void Visit(DataModificationStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DataModificationStatement node) {
            this.Start<DataModificationStatement>(node);
            if (this._visitBaseType) {
                this.Visit((StatementWithCtesAndXmlNamespaces)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DataModificationStatement>(node);
        }

        public virtual void Visit(DataModificationSpecification node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DataModificationSpecification node) {
            this.Start<DataModificationSpecification>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DataModificationSpecification>(node);
        }

        public virtual void Visit(MergeStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(MergeStatement node) {
            this.Start<MergeStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DataModificationStatement)node);
                this.Visit((StatementWithCtesAndXmlNamespaces)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<MergeStatement>(node);
        }

        public virtual void Visit(MergeSpecification node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(MergeSpecification node) {
            this.Start<MergeSpecification>(node);
            if (this._visitBaseType) {
                this.Visit((DataModificationSpecification)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<MergeSpecification>(node);
        }

        public virtual void Visit(MergeActionClause node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(MergeActionClause node) {
            this.Start<MergeActionClause>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<MergeActionClause>(node);
        }

        public virtual void Visit(MergeAction node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(MergeAction node) {
            this.Start<MergeAction>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<MergeAction>(node);
        }

        public virtual void Visit(UpdateMergeAction node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(UpdateMergeAction node) {
            this.Start<UpdateMergeAction>(node);
            if (this._visitBaseType) {
                this.Visit((MergeAction)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<UpdateMergeAction>(node);
        }

        public virtual void Visit(DeleteMergeAction node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DeleteMergeAction node) {
            this.Start<DeleteMergeAction>(node);
            if (this._visitBaseType) {
                this.Visit((MergeAction)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DeleteMergeAction>(node);
        }

        public virtual void Visit(InsertMergeAction node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(InsertMergeAction node) {
            this.Start<InsertMergeAction>(node);
            if (this._visitBaseType) {
                this.Visit((MergeAction)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<InsertMergeAction>(node);
        }

        public virtual void Visit(CreateTypeTableStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateTypeTableStatement node) {
            this.Start<CreateTypeTableStatement>(node);
            if (this._visitBaseType) {
                this.Visit((CreateTypeStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateTypeTableStatement>(node);
        }

        public virtual void Visit(AuditSpecificationStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AuditSpecificationStatement node) {
            this.Start<AuditSpecificationStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AuditSpecificationStatement>(node);
        }

        public virtual void Visit(AuditSpecificationPart node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AuditSpecificationPart node) {
            this.Start<AuditSpecificationPart>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AuditSpecificationPart>(node);
        }

        public virtual void Visit(AuditSpecificationDetail node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AuditSpecificationDetail node) {
            this.Start<AuditSpecificationDetail>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AuditSpecificationDetail>(node);
        }

        public virtual void Visit(AuditActionSpecification node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AuditActionSpecification node) {
            this.Start<AuditActionSpecification>(node);
            if (this._visitBaseType) {
                this.Visit((AuditSpecificationDetail)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AuditActionSpecification>(node);
        }

        public virtual void Visit(DatabaseAuditAction node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DatabaseAuditAction node) {
            this.Start<DatabaseAuditAction>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DatabaseAuditAction>(node);
        }

        public virtual void Visit(AuditActionGroupReference node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AuditActionGroupReference node) {
            this.Start<AuditActionGroupReference>(node);
            if (this._visitBaseType) {
                this.Visit((AuditSpecificationDetail)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AuditActionGroupReference>(node);
        }

        public virtual void Visit(CreateDatabaseAuditSpecificationStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateDatabaseAuditSpecificationStatement node) {
            this.Start<CreateDatabaseAuditSpecificationStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AuditSpecificationStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateDatabaseAuditSpecificationStatement>(node);
        }

        public virtual void Visit(AlterDatabaseAuditSpecificationStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterDatabaseAuditSpecificationStatement node) {
            this.Start<AlterDatabaseAuditSpecificationStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AuditSpecificationStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterDatabaseAuditSpecificationStatement>(node);
        }

        public virtual void Visit(DropDatabaseAuditSpecificationStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropDatabaseAuditSpecificationStatement node) {
            this.Start<DropDatabaseAuditSpecificationStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropDatabaseAuditSpecificationStatement>(node);
        }

        public virtual void Visit(CreateServerAuditSpecificationStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateServerAuditSpecificationStatement node) {
            this.Start<CreateServerAuditSpecificationStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AuditSpecificationStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateServerAuditSpecificationStatement>(node);
        }

        public virtual void Visit(AlterServerAuditSpecificationStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterServerAuditSpecificationStatement node) {
            this.Start<AlterServerAuditSpecificationStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AuditSpecificationStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterServerAuditSpecificationStatement>(node);
        }

        public virtual void Visit(DropServerAuditSpecificationStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropServerAuditSpecificationStatement node) {
            this.Start<DropServerAuditSpecificationStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropServerAuditSpecificationStatement>(node);
        }

        public virtual void Visit(ServerAuditStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ServerAuditStatement node) {
            this.Start<ServerAuditStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ServerAuditStatement>(node);
        }

        public virtual void Visit(CreateServerAuditStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateServerAuditStatement node) {
            this.Start<CreateServerAuditStatement>(node);
            if (this._visitBaseType) {
                this.Visit((ServerAuditStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateServerAuditStatement>(node);
        }

        public virtual void Visit(AlterServerAuditStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterServerAuditStatement node) {
            this.Start<AlterServerAuditStatement>(node);
            if (this._visitBaseType) {
                this.Visit((ServerAuditStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterServerAuditStatement>(node);
        }

        public virtual void Visit(DropServerAuditStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropServerAuditStatement node) {
            this.Start<DropServerAuditStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropServerAuditStatement>(node);
        }

        public virtual void Visit(AuditTarget node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AuditTarget node) {
            this.Start<AuditTarget>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AuditTarget>(node);
        }

        public virtual void Visit(AuditOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AuditOption node) {
            this.Start<AuditOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AuditOption>(node);
        }

        public virtual void Visit(QueueDelayAuditOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(QueueDelayAuditOption node) {
            this.Start<QueueDelayAuditOption>(node);
            if (this._visitBaseType) {
                this.Visit((AuditOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<QueueDelayAuditOption>(node);
        }

        public virtual void Visit(AuditGuidAuditOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AuditGuidAuditOption node) {
            this.Start<AuditGuidAuditOption>(node);
            if (this._visitBaseType) {
                this.Visit((AuditOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AuditGuidAuditOption>(node);
        }

        public virtual void Visit(OnFailureAuditOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OnFailureAuditOption node) {
            this.Start<OnFailureAuditOption>(node);
            if (this._visitBaseType) {
                this.Visit((AuditOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OnFailureAuditOption>(node);
        }

        public virtual void Visit(StateAuditOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(StateAuditOption node) {
            this.Start<StateAuditOption>(node);
            if (this._visitBaseType) {
                this.Visit((AuditOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<StateAuditOption>(node);
        }

        public virtual void Visit(AuditTargetOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AuditTargetOption node) {
            this.Start<AuditTargetOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AuditTargetOption>(node);
        }

        public virtual void Visit(MaxSizeAuditTargetOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(MaxSizeAuditTargetOption node) {
            this.Start<MaxSizeAuditTargetOption>(node);
            if (this._visitBaseType) {
                this.Visit((AuditTargetOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<MaxSizeAuditTargetOption>(node);
        }

        public virtual void Visit(MaxRolloverFilesAuditTargetOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(MaxRolloverFilesAuditTargetOption node) {
            this.Start<MaxRolloverFilesAuditTargetOption>(node);
            if (this._visitBaseType) {
                this.Visit((AuditTargetOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<MaxRolloverFilesAuditTargetOption>(node);
        }

        public virtual void Visit(LiteralAuditTargetOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(LiteralAuditTargetOption node) {
            this.Start<LiteralAuditTargetOption>(node);
            if (this._visitBaseType) {
                this.Visit((AuditTargetOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<LiteralAuditTargetOption>(node);
        }

        public virtual void Visit(OnOffAuditTargetOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OnOffAuditTargetOption node) {
            this.Start<OnOffAuditTargetOption>(node);
            if (this._visitBaseType) {
                this.Visit((AuditTargetOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OnOffAuditTargetOption>(node);
        }

        public virtual void Visit(DatabaseEncryptionKeyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DatabaseEncryptionKeyStatement node) {
            this.Start<DatabaseEncryptionKeyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DatabaseEncryptionKeyStatement>(node);
        }

        public virtual void Visit(CreateDatabaseEncryptionKeyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateDatabaseEncryptionKeyStatement node) {
            this.Start<CreateDatabaseEncryptionKeyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DatabaseEncryptionKeyStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateDatabaseEncryptionKeyStatement>(node);
        }

        public virtual void Visit(AlterDatabaseEncryptionKeyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterDatabaseEncryptionKeyStatement node) {
            this.Start<AlterDatabaseEncryptionKeyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DatabaseEncryptionKeyStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterDatabaseEncryptionKeyStatement>(node);
        }

        public virtual void Visit(DropDatabaseEncryptionKeyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropDatabaseEncryptionKeyStatement node) {
            this.Start<DropDatabaseEncryptionKeyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropDatabaseEncryptionKeyStatement>(node);
        }

        public virtual void Visit(ResourcePoolStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ResourcePoolStatement node) {
            this.Start<ResourcePoolStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ResourcePoolStatement>(node);
        }

        public virtual void Visit(ResourcePoolParameter node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ResourcePoolParameter node) {
            this.Start<ResourcePoolParameter>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ResourcePoolParameter>(node);
        }

        public virtual void Visit(ResourcePoolAffinitySpecification node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ResourcePoolAffinitySpecification node) {
            this.Start<ResourcePoolAffinitySpecification>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ResourcePoolAffinitySpecification>(node);
        }

        public virtual void Visit(CreateResourcePoolStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateResourcePoolStatement node) {
            this.Start<CreateResourcePoolStatement>(node);
            if (this._visitBaseType) {
                this.Visit((ResourcePoolStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateResourcePoolStatement>(node);
        }

        public virtual void Visit(AlterResourcePoolStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterResourcePoolStatement node) {
            this.Start<AlterResourcePoolStatement>(node);
            if (this._visitBaseType) {
                this.Visit((ResourcePoolStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterResourcePoolStatement>(node);
        }

        public virtual void Visit(DropResourcePoolStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropResourcePoolStatement node) {
            this.Start<DropResourcePoolStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropResourcePoolStatement>(node);
        }

        public virtual void Visit(ExternalResourcePoolStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExternalResourcePoolStatement node) {
            this.Start<ExternalResourcePoolStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExternalResourcePoolStatement>(node);
        }

        public virtual void Visit(ExternalResourcePoolParameter node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExternalResourcePoolParameter node) {
            this.Start<ExternalResourcePoolParameter>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExternalResourcePoolParameter>(node);
        }

        public virtual void Visit(ExternalResourcePoolAffinitySpecification node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ExternalResourcePoolAffinitySpecification node) {
            this.Start<ExternalResourcePoolAffinitySpecification>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ExternalResourcePoolAffinitySpecification>(node);
        }

        public virtual void Visit(CreateExternalResourcePoolStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateExternalResourcePoolStatement node) {
            this.Start<CreateExternalResourcePoolStatement>(node);
            if (this._visitBaseType) {
                this.Visit((ExternalResourcePoolStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateExternalResourcePoolStatement>(node);
        }

        public virtual void Visit(AlterExternalResourcePoolStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterExternalResourcePoolStatement node) {
            this.Start<AlterExternalResourcePoolStatement>(node);
            if (this._visitBaseType) {
                this.Visit((ExternalResourcePoolStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterExternalResourcePoolStatement>(node);
        }

        public virtual void Visit(DropExternalResourcePoolStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropExternalResourcePoolStatement node) {
            this.Start<DropExternalResourcePoolStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropExternalResourcePoolStatement>(node);
        }

        public virtual void Visit(WorkloadGroupStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(WorkloadGroupStatement node) {
            this.Start<WorkloadGroupStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<WorkloadGroupStatement>(node);
        }

        public virtual void Visit(WorkloadGroupResourceParameter node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(WorkloadGroupResourceParameter node) {
            this.Start<WorkloadGroupResourceParameter>(node);
            if (this._visitBaseType) {
                this.Visit((WorkloadGroupParameter)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<WorkloadGroupResourceParameter>(node);
        }

        public virtual void Visit(WorkloadGroupImportanceParameter node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(WorkloadGroupImportanceParameter node) {
            this.Start<WorkloadGroupImportanceParameter>(node);
            if (this._visitBaseType) {
                this.Visit((WorkloadGroupParameter)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<WorkloadGroupImportanceParameter>(node);
        }

        public virtual void Visit(WorkloadGroupParameter node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(WorkloadGroupParameter node) {
            this.Start<WorkloadGroupParameter>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<WorkloadGroupParameter>(node);
        }

        public virtual void Visit(CreateWorkloadGroupStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateWorkloadGroupStatement node) {
            this.Start<CreateWorkloadGroupStatement>(node);
            if (this._visitBaseType) {
                this.Visit((WorkloadGroupStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateWorkloadGroupStatement>(node);
        }

        public virtual void Visit(AlterWorkloadGroupStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterWorkloadGroupStatement node) {
            this.Start<AlterWorkloadGroupStatement>(node);
            if (this._visitBaseType) {
                this.Visit((WorkloadGroupStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterWorkloadGroupStatement>(node);
        }

        public virtual void Visit(DropWorkloadGroupStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropWorkloadGroupStatement node) {
            this.Start<DropWorkloadGroupStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropWorkloadGroupStatement>(node);
        }

        public virtual void Visit(BrokerPriorityStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BrokerPriorityStatement node) {
            this.Start<BrokerPriorityStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BrokerPriorityStatement>(node);
        }

        public virtual void Visit(BrokerPriorityParameter node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BrokerPriorityParameter node) {
            this.Start<BrokerPriorityParameter>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BrokerPriorityParameter>(node);
        }

        public virtual void Visit(CreateBrokerPriorityStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateBrokerPriorityStatement node) {
            this.Start<CreateBrokerPriorityStatement>(node);
            if (this._visitBaseType) {
                this.Visit((BrokerPriorityStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateBrokerPriorityStatement>(node);
        }

        public virtual void Visit(AlterBrokerPriorityStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterBrokerPriorityStatement node) {
            this.Start<AlterBrokerPriorityStatement>(node);
            if (this._visitBaseType) {
                this.Visit((BrokerPriorityStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterBrokerPriorityStatement>(node);
        }

        public virtual void Visit(DropBrokerPriorityStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropBrokerPriorityStatement node) {
            this.Start<DropBrokerPriorityStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropBrokerPriorityStatement>(node);
        }

        public virtual void Visit(CreateFullTextStopListStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateFullTextStopListStatement node) {
            this.Start<CreateFullTextStopListStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateFullTextStopListStatement>(node);
        }

        public virtual void Visit(AlterFullTextStopListStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterFullTextStopListStatement node) {
            this.Start<AlterFullTextStopListStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterFullTextStopListStatement>(node);
        }

        public virtual void Visit(FullTextStopListAction node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FullTextStopListAction node) {
            this.Start<FullTextStopListAction>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FullTextStopListAction>(node);
        }

        public virtual void Visit(DropFullTextStopListStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropFullTextStopListStatement node) {
            this.Start<DropFullTextStopListStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropFullTextStopListStatement>(node);
        }

        public virtual void Visit(CreateCryptographicProviderStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateCryptographicProviderStatement node) {
            this.Start<CreateCryptographicProviderStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateCryptographicProviderStatement>(node);
        }

        public virtual void Visit(AlterCryptographicProviderStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterCryptographicProviderStatement node) {
            this.Start<AlterCryptographicProviderStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterCryptographicProviderStatement>(node);
        }

        public virtual void Visit(DropCryptographicProviderStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropCryptographicProviderStatement node) {
            this.Start<DropCryptographicProviderStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropCryptographicProviderStatement>(node);
        }

        public virtual void Visit(EventSessionObjectName node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(EventSessionObjectName node) {
            this.Start<EventSessionObjectName>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<EventSessionObjectName>(node);
        }

        public virtual void Visit(EventSessionStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(EventSessionStatement node) {
            this.Start<EventSessionStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<EventSessionStatement>(node);
        }

        public virtual void Visit(CreateEventSessionStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateEventSessionStatement node) {
            this.Start<CreateEventSessionStatement>(node);
            if (this._visitBaseType) {
                this.Visit((EventSessionStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateEventSessionStatement>(node);
        }

        public virtual void Visit(EventDeclaration node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(EventDeclaration node) {
            this.Start<EventDeclaration>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<EventDeclaration>(node);
        }

        public virtual void Visit(EventDeclarationSetParameter node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(EventDeclarationSetParameter node) {
            this.Start<EventDeclarationSetParameter>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<EventDeclarationSetParameter>(node);
        }

        public virtual void Visit(SourceDeclaration node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SourceDeclaration node) {
            this.Start<SourceDeclaration>(node);
            if (this._visitBaseType) {
                this.Visit((ScalarExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SourceDeclaration>(node);
        }

        public virtual void Visit(EventDeclarationCompareFunctionParameter node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(EventDeclarationCompareFunctionParameter node) {
            this.Start<EventDeclarationCompareFunctionParameter>(node);
            if (this._visitBaseType) {
                this.Visit((BooleanExpression)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<EventDeclarationCompareFunctionParameter>(node);
        }

        public virtual void Visit(TargetDeclaration node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TargetDeclaration node) {
            this.Start<TargetDeclaration>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TargetDeclaration>(node);
        }

        public virtual void Visit(SessionOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SessionOption node) {
            this.Start<SessionOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SessionOption>(node);
        }

        public virtual void Visit(EventRetentionSessionOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(EventRetentionSessionOption node) {
            this.Start<EventRetentionSessionOption>(node);
            if (this._visitBaseType) {
                this.Visit((SessionOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<EventRetentionSessionOption>(node);
        }

        public virtual void Visit(MemoryPartitionSessionOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(MemoryPartitionSessionOption node) {
            this.Start<MemoryPartitionSessionOption>(node);
            if (this._visitBaseType) {
                this.Visit((SessionOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<MemoryPartitionSessionOption>(node);
        }

        public virtual void Visit(LiteralSessionOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(LiteralSessionOption node) {
            this.Start<LiteralSessionOption>(node);
            if (this._visitBaseType) {
                this.Visit((SessionOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<LiteralSessionOption>(node);
        }

        public virtual void Visit(MaxDispatchLatencySessionOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(MaxDispatchLatencySessionOption node) {
            this.Start<MaxDispatchLatencySessionOption>(node);
            if (this._visitBaseType) {
                this.Visit((SessionOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<MaxDispatchLatencySessionOption>(node);
        }

        public virtual void Visit(OnOffSessionOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(OnOffSessionOption node) {
            this.Start<OnOffSessionOption>(node);
            if (this._visitBaseType) {
                this.Visit((SessionOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<OnOffSessionOption>(node);
        }

        public virtual void Visit(AlterEventSessionStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterEventSessionStatement node) {
            this.Start<AlterEventSessionStatement>(node);
            if (this._visitBaseType) {
                this.Visit((EventSessionStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterEventSessionStatement>(node);
        }

        public virtual void Visit(DropEventSessionStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropEventSessionStatement node) {
            this.Start<DropEventSessionStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropEventSessionStatement>(node);
        }

        public virtual void Visit(AlterResourceGovernorStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterResourceGovernorStatement node) {
            this.Start<AlterResourceGovernorStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterResourceGovernorStatement>(node);
        }

        public virtual void Visit(CreateSpatialIndexStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateSpatialIndexStatement node) {
            this.Start<CreateSpatialIndexStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateSpatialIndexStatement>(node);
        }

        public virtual void Visit(SpatialIndexOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SpatialIndexOption node) {
            this.Start<SpatialIndexOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SpatialIndexOption>(node);
        }

        public virtual void Visit(SpatialIndexRegularOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SpatialIndexRegularOption node) {
            this.Start<SpatialIndexRegularOption>(node);
            if (this._visitBaseType) {
                this.Visit((SpatialIndexOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SpatialIndexRegularOption>(node);
        }

        public virtual void Visit(BoundingBoxSpatialIndexOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BoundingBoxSpatialIndexOption node) {
            this.Start<BoundingBoxSpatialIndexOption>(node);
            if (this._visitBaseType) {
                this.Visit((SpatialIndexOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BoundingBoxSpatialIndexOption>(node);
        }

        public virtual void Visit(BoundingBoxParameter node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(BoundingBoxParameter node) {
            this.Start<BoundingBoxParameter>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<BoundingBoxParameter>(node);
        }

        public virtual void Visit(GridsSpatialIndexOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(GridsSpatialIndexOption node) {
            this.Start<GridsSpatialIndexOption>(node);
            if (this._visitBaseType) {
                this.Visit((SpatialIndexOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<GridsSpatialIndexOption>(node);
        }

        public virtual void Visit(GridParameter node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(GridParameter node) {
            this.Start<GridParameter>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<GridParameter>(node);
        }

        public virtual void Visit(CellsPerObjectSpatialIndexOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CellsPerObjectSpatialIndexOption node) {
            this.Start<CellsPerObjectSpatialIndexOption>(node);
            if (this._visitBaseType) {
                this.Visit((SpatialIndexOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CellsPerObjectSpatialIndexOption>(node);
        }

        public virtual void Visit(AlterServerConfigurationStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterServerConfigurationStatement node) {
            this.Start<AlterServerConfigurationStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterServerConfigurationStatement>(node);
        }

        public virtual void Visit(ProcessAffinityRange node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(ProcessAffinityRange node) {
            this.Start<ProcessAffinityRange>(node);
            if (this._visitBaseType) {
                this.Visit((LiteralRange)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<ProcessAffinityRange>(node);
        }

        public virtual void Visit(AlterServerConfigurationSetBufferPoolExtensionStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterServerConfigurationSetBufferPoolExtensionStatement node) {
            this.Start<AlterServerConfigurationSetBufferPoolExtensionStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterServerConfigurationSetBufferPoolExtensionStatement>(node);
        }

        public virtual void Visit(AlterServerConfigurationBufferPoolExtensionOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterServerConfigurationBufferPoolExtensionOption node) {
            this.Start<AlterServerConfigurationBufferPoolExtensionOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterServerConfigurationBufferPoolExtensionOption>(node);
        }

        public virtual void Visit(AlterServerConfigurationBufferPoolExtensionContainerOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterServerConfigurationBufferPoolExtensionContainerOption node) {
            this.Start<AlterServerConfigurationBufferPoolExtensionContainerOption>(node);
            if (this._visitBaseType) {
                this.Visit((AlterServerConfigurationBufferPoolExtensionOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterServerConfigurationBufferPoolExtensionContainerOption>(node);
        }

        public virtual void Visit(AlterServerConfigurationBufferPoolExtensionSizeOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterServerConfigurationBufferPoolExtensionSizeOption node) {
            this.Start<AlterServerConfigurationBufferPoolExtensionSizeOption>(node);
            if (this._visitBaseType) {
                this.Visit((AlterServerConfigurationBufferPoolExtensionOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterServerConfigurationBufferPoolExtensionSizeOption>(node);
        }

        public virtual void Visit(AlterServerConfigurationSetDiagnosticsLogStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterServerConfigurationSetDiagnosticsLogStatement node) {
            this.Start<AlterServerConfigurationSetDiagnosticsLogStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterServerConfigurationSetDiagnosticsLogStatement>(node);
        }

        public virtual void Visit(AlterServerConfigurationDiagnosticsLogOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterServerConfigurationDiagnosticsLogOption node) {
            this.Start<AlterServerConfigurationDiagnosticsLogOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterServerConfigurationDiagnosticsLogOption>(node);
        }

        public virtual void Visit(AlterServerConfigurationDiagnosticsLogMaxSizeOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterServerConfigurationDiagnosticsLogMaxSizeOption node) {
            this.Start<AlterServerConfigurationDiagnosticsLogMaxSizeOption>(node);
            if (this._visitBaseType) {
                this.Visit((AlterServerConfigurationDiagnosticsLogOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterServerConfigurationDiagnosticsLogMaxSizeOption>(node);
        }

        public virtual void Visit(AlterServerConfigurationSetFailoverClusterPropertyStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterServerConfigurationSetFailoverClusterPropertyStatement node) {
            this.Start<AlterServerConfigurationSetFailoverClusterPropertyStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterServerConfigurationSetFailoverClusterPropertyStatement>(node);
        }

        public virtual void Visit(AlterServerConfigurationFailoverClusterPropertyOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterServerConfigurationFailoverClusterPropertyOption node) {
            this.Start<AlterServerConfigurationFailoverClusterPropertyOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterServerConfigurationFailoverClusterPropertyOption>(node);
        }

        public virtual void Visit(AlterServerConfigurationSetHadrClusterStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterServerConfigurationSetHadrClusterStatement node) {
            this.Start<AlterServerConfigurationSetHadrClusterStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterServerConfigurationSetHadrClusterStatement>(node);
        }

        public virtual void Visit(AlterServerConfigurationHadrClusterOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterServerConfigurationHadrClusterOption node) {
            this.Start<AlterServerConfigurationHadrClusterOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterServerConfigurationHadrClusterOption>(node);
        }

        public virtual void Visit(AlterServerConfigurationSetSoftNumaStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterServerConfigurationSetSoftNumaStatement node) {
            this.Start<AlterServerConfigurationSetSoftNumaStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterServerConfigurationSetSoftNumaStatement>(node);
        }

        public virtual void Visit(AlterServerConfigurationSoftNumaOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterServerConfigurationSoftNumaOption node) {
            this.Start<AlterServerConfigurationSoftNumaOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterServerConfigurationSoftNumaOption>(node);
        }

        public virtual void Visit(AvailabilityGroupStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AvailabilityGroupStatement node) {
            this.Start<AvailabilityGroupStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AvailabilityGroupStatement>(node);
        }

        public virtual void Visit(CreateAvailabilityGroupStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateAvailabilityGroupStatement node) {
            this.Start<CreateAvailabilityGroupStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AvailabilityGroupStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateAvailabilityGroupStatement>(node);
        }

        public virtual void Visit(AlterAvailabilityGroupStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterAvailabilityGroupStatement node) {
            this.Start<AlterAvailabilityGroupStatement>(node);
            if (this._visitBaseType) {
                this.Visit((AvailabilityGroupStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterAvailabilityGroupStatement>(node);
        }

        public virtual void Visit(AvailabilityReplica node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AvailabilityReplica node) {
            this.Start<AvailabilityReplica>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AvailabilityReplica>(node);
        }

        public virtual void Visit(AvailabilityReplicaOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AvailabilityReplicaOption node) {
            this.Start<AvailabilityReplicaOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AvailabilityReplicaOption>(node);
        }

        public virtual void Visit(LiteralReplicaOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(LiteralReplicaOption node) {
            this.Start<LiteralReplicaOption>(node);
            if (this._visitBaseType) {
                this.Visit((AvailabilityReplicaOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<LiteralReplicaOption>(node);
        }

        public virtual void Visit(AvailabilityModeReplicaOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AvailabilityModeReplicaOption node) {
            this.Start<AvailabilityModeReplicaOption>(node);
            if (this._visitBaseType) {
                this.Visit((AvailabilityReplicaOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AvailabilityModeReplicaOption>(node);
        }

        public virtual void Visit(FailoverModeReplicaOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(FailoverModeReplicaOption node) {
            this.Start<FailoverModeReplicaOption>(node);
            if (this._visitBaseType) {
                this.Visit((AvailabilityReplicaOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<FailoverModeReplicaOption>(node);
        }

        public virtual void Visit(PrimaryRoleReplicaOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(PrimaryRoleReplicaOption node) {
            this.Start<PrimaryRoleReplicaOption>(node);
            if (this._visitBaseType) {
                this.Visit((AvailabilityReplicaOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<PrimaryRoleReplicaOption>(node);
        }

        public virtual void Visit(SecondaryRoleReplicaOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SecondaryRoleReplicaOption node) {
            this.Start<SecondaryRoleReplicaOption>(node);
            if (this._visitBaseType) {
                this.Visit((AvailabilityReplicaOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SecondaryRoleReplicaOption>(node);
        }

        public virtual void Visit(AvailabilityGroupOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AvailabilityGroupOption node) {
            this.Start<AvailabilityGroupOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AvailabilityGroupOption>(node);
        }

        public virtual void Visit(LiteralAvailabilityGroupOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(LiteralAvailabilityGroupOption node) {
            this.Start<LiteralAvailabilityGroupOption>(node);
            if (this._visitBaseType) {
                this.Visit((AvailabilityGroupOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<LiteralAvailabilityGroupOption>(node);
        }

        public virtual void Visit(AlterAvailabilityGroupAction node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterAvailabilityGroupAction node) {
            this.Start<AlterAvailabilityGroupAction>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterAvailabilityGroupAction>(node);
        }

        public virtual void Visit(AlterAvailabilityGroupFailoverAction node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterAvailabilityGroupFailoverAction node) {
            this.Start<AlterAvailabilityGroupFailoverAction>(node);
            if (this._visitBaseType) {
                this.Visit((AlterAvailabilityGroupAction)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterAvailabilityGroupFailoverAction>(node);
        }

        public virtual void Visit(AlterAvailabilityGroupFailoverOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterAvailabilityGroupFailoverOption node) {
            this.Start<AlterAvailabilityGroupFailoverOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterAvailabilityGroupFailoverOption>(node);
        }

        public virtual void Visit(DropAvailabilityGroupStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropAvailabilityGroupStatement node) {
            this.Start<DropAvailabilityGroupStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropAvailabilityGroupStatement>(node);
        }

        public virtual void Visit(CreateFederationStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateFederationStatement node) {
            this.Start<CreateFederationStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateFederationStatement>(node);
        }

        public virtual void Visit(AlterFederationStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(AlterFederationStatement node) {
            this.Start<AlterFederationStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<AlterFederationStatement>(node);
        }

        public virtual void Visit(DropFederationStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DropFederationStatement node) {
            this.Start<DropFederationStatement>(node);
            if (this._visitBaseType) {
                this.Visit((DropUnownedObjectStatement)node);
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DropFederationStatement>(node);
        }

        public virtual void Visit(UseFederationStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(UseFederationStatement node) {
            this.Start<UseFederationStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<UseFederationStatement>(node);
        }

        public virtual void Visit(DiskStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DiskStatement node) {
            this.Start<DiskStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DiskStatement>(node);
        }

        public virtual void Visit(DiskStatementOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(DiskStatementOption node) {
            this.Start<DiskStatementOption>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<DiskStatementOption>(node);
        }

        public virtual void Visit(CreateColumnStoreIndexStatement node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CreateColumnStoreIndexStatement node) {
            this.Start<CreateColumnStoreIndexStatement>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlStatement)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CreateColumnStoreIndexStatement>(node);
        }

        public virtual void Visit(WindowFrameClause node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(WindowFrameClause node) {
            this.Start<WindowFrameClause>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<WindowFrameClause>(node);
        }

        public virtual void Visit(WindowDelimiter node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(WindowDelimiter node) {
            this.Start<WindowDelimiter>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<WindowDelimiter>(node);
        }

        public virtual void Visit(WithinGroupClause node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(WithinGroupClause node) {
            this.Start<WithinGroupClause>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<WithinGroupClause>(node);
        }

        public virtual void Visit(SelectiveXmlIndexPromotedPath node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(SelectiveXmlIndexPromotedPath node) {
            this.Start<SelectiveXmlIndexPromotedPath>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<SelectiveXmlIndexPromotedPath>(node);
        }

        public virtual void Visit(TemporalClause node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(TemporalClause node) {
            this.Start<TemporalClause>(node);
            if (this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<TemporalClause>(node);
        }

        public virtual void Visit(CompressionDelayIndexOption node) {
            if (!this._visitBaseType) {
                this.Visit((TSqlFragment)node);
            }
        }

        public virtual void ExplicitVisit(CompressionDelayIndexOption node) {
            this.Start<CompressionDelayIndexOption>(node);
            if (this._visitBaseType) {
                this.Visit((IndexOption)node);
                this.Visit((TSqlFragment)node);
            }
            this.Visit(node);
            node.AcceptChildren(this);
            this.Done<CompressionDelayIndexOption>(node);
        }
    }
}
