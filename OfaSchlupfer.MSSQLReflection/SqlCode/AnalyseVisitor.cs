#pragma warning disable SA1600

namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using System.Collections.Generic;
    using System.Linq;
    using OfaSchlupfer.MSSQLReflection.AST;
    using OfaSchlupfer.MSSQLReflection.Model;

    /// <summary>
    /// Bind
    /// </summary>
    internal class AnalyseVisitor
        : SqlConcreteFragmentVisitor {
        private readonly SqlCodeScopeReference currentScopeRef;
        private SqlCodeScope _DBScope;
        private SqlName _sqlSysName;
        private List<AnalyseResult> _AnalyseResults;

        public AnalyseVisitor(SqlCodeScope dbScope) {
            this._DBScope = dbScope;
            this._AnalyseResults = new List<AnalyseResult>();
            this.currentScopeRef = new SqlCodeScopeReference();
            this.currentScopeRef.Set(dbScope);
        }

        /// <summary>
        /// start the enginges.
        /// </summary>
        /// <param name="node">the start node.</param>
        /// <returns>think of</returns>
        internal List<AnalyseResult> Run(SqlNode node) {
            if ((object)node == null) { return null; }
            node.Accept(this);
            return this._AnalyseResults;
        }

        /// <summary>
        /// the root
        /// </summary>
        /// <param name="node">the current node</param>
        public override void ExplicitVisit(SqlScript node) {
            node.Analyse.SqlCodeScope = this.currentScopeRef.Current;
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(SqlBatch node) {
            var nodeAnalyse = node.Analyse;

            var declarationScope = this._DBScope.CreateChildDeclarationScope("Declaration", null);
            this.currentScopeRef.Push(declarationScope);

            var batchScope = declarationScope.CreateChildScope("TSqlBatch", null);
            nodeAnalyse.SqlCodeScope = batchScope;
            this.currentScopeRef.Push(batchScope);

            var node_Statements = node.Statements;
            /*
            SqlCodeScope scopeLastStatement = batchScope;
            */
            for (int i = 0, count = node_Statements.Count; i < count; i++) {
                var statement = node_Statements[i];
                /*
                SqlCodeScope scopeStatement = null;
                if (scopeLastStatement.HasContent) {
                    scopeStatement = scopeLastStatement.CreateNextScope(statement.GetType().Name, null);
                    this._CurrentScope.Pop();
                    this._CurrentScope.Push(scopeStatement);
                    this.currentScope = scopeStatement;
                    scopeLastStatement = scopeStatement;
                }
                */
                statement.Accept(this);
            }

            this._AnalyseResults.Add(new AnalyseResult() {
                DeclarationScope = declarationScope,
                /*
                LastScope = scopeLastStatement,
                */
                LastScope = this.currentScopeRef.Current,
                SqlCodeResult = null,
                SqlCodeType = null,
                Fragment = node
            });
            var pop1 = this.currentScopeRef.Pop();
            /*
            System.Diagnostics.Debug.Assert(ReferenceEquals(scopeLastStatement, pop1), "last statement");
            */

            var pop2 = this.currentScopeRef.Pop();
            System.Diagnostics.Debug.Assert(ReferenceEquals(declarationScope, pop2), "db scope");

            /*
            var node_Statements = node.Statements;
            for (int i = 0, count = node_Statements.Count; i < count; i++) {
                var statement = node_Statements[i];
                this.ExplicitVisit(statement);
            }
            this._Scopes.Pop();
            this.currentScope = this._Scopes.Peek();
            */
        }

        public override void Visit(SqlNode node) {
            var nodeAnalyse = node.Analyse;

            if (nodeAnalyse.SqlCodeScope == null) {
                nodeAnalyse.SqlCodeScope = this.currentScopeRef.Current;
            }
            System.Diagnostics.Debug.WriteLine(node.GetType().Name);
            base.Visit(node);
        }

        public override void ExplicitVisit(DeclareVariableElement node) {
            var declarationScope = this.currentScopeRef.Current.GetDeclarationScope();
            node.Analyse.SqlCodeScope = declarationScope;
            var variableNameValue = new SqlName(null, node.VariableName.Value, ObjectLevel.Local);
            var lazy = new SqlCodeTypeLazy(node.DataType);
            node.DataType.Analyse.ResultType = lazy;
            node.Analyse.ResultType = lazy;
            node.Analyse.SqlCodeScope.Add(variableNameValue, lazy);
            base.ExplicitVisit(node);
            var resolved = node.Analyse.ResultType.GetResolvedCodeType();
            if (resolved != null) {
                node.Analyse.ResultType = resolved;
            }
        }

        public override void ExplicitVisit(CreateProcedureStatement node) { this.HandleProcedure(node); }

        public override void ExplicitVisit(AlterProcedureStatement node) { this.HandleProcedure(node); }

        public override void ExplicitVisit(CreateFunctionStatement node) { this.HandleFunction(node); }

        public override void ExplicitVisit(AlterFunctionStatement node) { this.HandleFunction(node); }

        public void HandleProcedure(ProcedureStatementBody node) {
            var outerPreviousScope = this.currentScopeRef.Current;
            var dbScope = this.currentScopeRef.Current.GetRoot();
            var declarationScope = dbScope.CreateChildDeclarationScope("procedure", dbScope.ScopeNameResolverContext);
            this.currentScopeRef.Push(declarationScope);
            var procedureScope = dbScope.CreateChildScope("procedure", dbScope.ScopeNameResolverContext);
            this.currentScopeRef.Push(declarationScope);

            this.ExplicitVisit((ProcedureStatementBody)node);

            this.currentScopeRef.Pop();
            this.currentScopeRef.Pop();
            System.Diagnostics.Debug.Assert(ReferenceEquals(outerPreviousScope, this.currentScopeRef.Current), "previous must be restored.");
        }

        /* function */

        public void HandleFunction(FunctionStatementBody node) {
            var outerPreviousScope = this.currentScopeRef.Current;
            var dbScope = this.currentScopeRef.Current.GetRoot();
            var declarationScope = dbScope.CreateChildDeclarationScope("function", dbScope.ScopeNameResolverContext);
            this.currentScopeRef.Push(declarationScope);

            // node.Analyse.OutputType
            this.ExplicitVisit((FunctionStatementBody)node);

            this.currentScopeRef.Pop();
            System.Diagnostics.Debug.Assert(ReferenceEquals(outerPreviousScope, this.currentScopeRef.Current), "previous must be restored.");
        }

        public override void ExplicitVisit(FunctionCall node) {
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(MultiPartIdentifierCallTarget node) {
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(ExpressionCallTarget node) {
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(UserDefinedTypeCallTarget node) {
            base.ExplicitVisit(node);
        }

        /* / function */

        public override void ExplicitVisit(IfStatement node) {
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(BeginEndBlockStatement node) {
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(BinaryExpression node) {
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(BooleanParenthesisExpression node) {
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(SetErrorLevelStatement node) {
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(SqlDataTypeReference node) {
            (new TypeVisitor(this.currentScopeRef.Current)).ExplicitVisit(node);
        }

        public override void ExplicitVisit(UserDataTypeReference node) {
            (new TypeVisitor(this.currentScopeRef.Current)).ExplicitVisit(node);
        }

        public override void ExplicitVisit(IntegerLiteral node) {
            var sys_int_name = this.GetSqlNameSys().ChildWellkown("int");
            var t = new ModelTypeScalar() {
                Name = sys_int_name,
                SystemDataType = ModelSystemDataType.Int
            };
            var v = new ModelValueScalar() {
                Type = t,
                Value = node.Value,
                IsConst = true
            };
            node.Analyse.ResultType = new SqlCodeType(t);
            node.Analyse.ResultValue = new SqlCodeResultConst(v);
            /*
            no need for base.ExplicitVisit(node);
            */
        }

        public override void ExplicitVisit(RealLiteral node) {
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(MoneyLiteral node) {
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(BinaryLiteral node) {
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(StringLiteral node) {
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(NullLiteral node) {
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(DefaultLiteral node) {
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(MaxLiteral node) {
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(IdentifierLiteral node) {
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(NumericLiteral node) {
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(AssignmentSetClause node) {
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(SelectStatement node) {
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(BinaryQueryExpression node) {
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(QueryParenthesisExpression node) {
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(QuerySpecification node) {
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(ColumnReferenceExpression node) {
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(FromClause node) {
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(NamedTableReference node) {
            // node.Alias
            // node.SchemaObject
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(XmlDataTypeReference node) {
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(SelectScalarExpression node) {
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(DeclareVariableStatement node) {
            base.ExplicitVisit(node);
        }

        private SqlName GetSqlNameSys() {
            var sqlSysName = this._sqlSysName;
            if (sqlSysName == null) {
                sqlSysName = SqlName.Root.Child("sys", ObjectLevel.Schema);

                // think
                // this._sqlSysName = this._DBScope.ModelDatabase.Schemas.GetValueOrDefault(sqlSysName)?.Name ?? sqlSysName;
                // this.currentScope.ScopeNameResolverContext.Resolve(sqlSysName);
                this._sqlSysName = this.currentScopeRef.Current.ScopeNameResolverContext.ModelDatabase.Schemas.GetValueOrDefault(sqlSysName)?.Name ?? sqlSysName;
            }
            return sqlSysName;
        }
    }
}
