#pragma warning disable SA1600

namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using System.Collections.Generic;
    using OfaSchlupfer.MSSQLReflection.AST;
    using OfaSchlupfer.MSSQLReflection.Model;

    /// <summary>
    /// Bind
    /// </summary>
    internal class TSqlBindVisitor
        : SqlConcreteFragmentVisitor {
        private readonly Stack<SqlCodeScope> _Scopes;
        private SqlCodeScope _DBScope;
        private SqlCodeScope currentScope;
        private SqlName _sqlSysName;
        private List<AnalyseResult> _AnalyseResults;

        public TSqlBindVisitor(SqlCodeScope dbScope) {
            this._Scopes = new Stack<SqlCodeScope>();
            this._DBScope = dbScope;
            this.currentScope = dbScope;
            this._Scopes.Push(dbScope);
            this._AnalyseResults = new List<AnalyseResult>();
        }

        /// <summary>
        /// start the enginges.
        /// </summary>
        /// <param name="fragment">the start node.</param>
        /// <returns>think of</returns>
        internal List<AnalyseResult> Run(SqlNode fragment) {
            if ((object)fragment == null) { return null; }
            fragment.Accept(this);
            return this._AnalyseResults;
        }

        /// <summary>
        /// the root
        /// </summary>
        /// <param name="node">the current node</param>
        public override void ExplicitVisit(SqlScript node) {
            node.Analyse.SqlCodeScope = this._DBScope;
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(SqlBatch node) {
            var nodeAnalyse = node.Analyse;

            var declarationScope = this._DBScope.CreateChildDeclarationScope("Declaration", null);
            this._Scopes.Push(declarationScope);

            var batchScope = declarationScope.CreateChildScope("TSqlBatch", null);
            nodeAnalyse.SqlCodeScope = batchScope;
            this._Scopes.Push(batchScope);
            this.currentScope = batchScope;

            var node_Statements = node.Statements;
            SqlCodeScope scopeLastStatement = batchScope;
            for (int i = 0, count = node_Statements.Count; i < count; i++) {
                var statement = node_Statements[i];
                SqlCodeScope scopeStatement = null;
                if (scopeLastStatement.HasContent) {
                    scopeStatement = scopeLastStatement.CreateNextScope(statement.GetType().Name, null);
                    this._Scopes.Pop();
                    this._Scopes.Push(scopeStatement);
                    this.currentScope = scopeStatement;
                    scopeLastStatement = scopeStatement;
                }
                this.ExplicitVisit(statement);
            }

            this._AnalyseResults.Add(new AnalyseResult() {
                DeclarationScope = declarationScope,
                LastScope = scopeLastStatement,
                SqlCodeResult = null,
                SqlCodeType = null,
                Fragment = node
            });

            var pop1 = this._Scopes.Pop();
            System.Diagnostics.Debug.Assert(ReferenceEquals(scopeLastStatement, pop1), "last statement");
            var pop2 = this._Scopes.Pop();
            System.Diagnostics.Debug.Assert(ReferenceEquals(declarationScope, pop2), "db scope");
            this.currentScope = this._Scopes.Peek();

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
                nodeAnalyse.SqlCodeScope = this.currentScope;
            }
            System.Diagnostics.Debug.WriteLine(node.GetType().Name);
            base.Visit(node);
        }

        public override void ExplicitVisit(DeclareVariableElement node) {
            var declarationScope = this.currentScope.GetDeclarationScope();
            node.Analyse.SqlCodeScope = declarationScope;
            var variableNameValue = new SqlName(null, node.VariableName.Value, ObjectLevel.Local);
            var lazy = new SqlCodeTypeLazy(node.DataType);
            node.DataType.Analyse.SqlCodeType = lazy;
            node.Analyse.SqlCodeType = lazy;
            node.Analyse.SqlCodeScope.Add(variableNameValue, lazy);
            base.ExplicitVisit(node);
            var resolved = node.Analyse.SqlCodeType.GetResolvedCodeType();
            if (resolved != null) {
                node.Analyse.SqlCodeType = resolved;
            }
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

        public override void ExplicitVisit(SqlDataTypeReference node) {
            var name = node.Name;
            var parameters = node.Parameters;
            if ((name.Identifiers.Count == 1) && (parameters.Count == 0)) {
                var sqlName = SqlName.Parse(name.BaseIdentifier.Value, ObjectLevel.Object);
                var sqlSysName = SqlName.Root.Child("sys", ObjectLevel.Schema).Child(sqlName.Name, ObjectLevel.Object);
                var sqlCodeType = this.currentScope.ResolveObject(sqlSysName, null) as ISqlCodeType;
                SetAnalyseSqlCodeType(node.Analyse, sqlCodeType);
            } else {
                if (System.Diagnostics.Debugger.IsAttached) {
                    System.Diagnostics.Debugger.Break();
                }
                node.Analyse.SqlCodeType = null;
            }
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(UserDataTypeReference node) {
            var name = node.Name;
            var parameters = node.Parameters;
            if (System.Diagnostics.Debugger.IsAttached) {
                System.Diagnostics.Debugger.Break();
            }
            node.Analyse.SqlCodeType = null;
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(XmlDataTypeReference node) {
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(SelectScalarExpression node) {
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(IntegerLiteral node) {
            var sys_int_name = this.GetSqlNameSys().ChildWellkown("int");

            // this._DBScope.Resolve(sys_int_name);
            // var sys_int_model = this._DBScope.ModelDatabase.Types.GetValueOrDefault(sys_int_name);
            // var sys_int_model = (ISqlCodeType)this.currentScope.ResolveObject(sys_int_name, null);
            // ??
            var sys_int_model = (OfaSchlupfer.MSSQLReflection.Model.ModelSqlType)this.currentScope.ScopeNameResolverContext.Resolve(sys_int_name);
            ISqlCodeType sqlCodeType = new SqlCodeTypeSingle(sys_int_model);
            SetAnalyseSqlCodeType(node.Analyse, sqlCodeType);
            var modelSqlScalarValue = new OfaSchlupfer.MSSQLReflection.Model.ModelSqlScalarValue(sys_int_model.GetScalarType(), node.Value, true);
            node.Analyse.SqlCodeResult = new SqlCodeResultConst(modelSqlScalarValue);
            base.ExplicitVisit(node);
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
        /*
                Integer,
        Real,
        Money,
        Binary,
        String,
        Null,
        Default,
        Max,
        Odbc,
        Identifier,
        Numeric
             */

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

        private static void SetAnalyseSqlCodeType(AnalyseNodeState nodeAnalyse, ISqlCodeType sqlCodeType) {
            if (sqlCodeType == null) {
                // too bad
            } else if (nodeAnalyse.SqlCodeType == null) {
                nodeAnalyse.SqlCodeType = sqlCodeType;
            } else if (nodeAnalyse.SqlCodeType is SqlCodeTypeLazy) {
                ((SqlCodeTypeLazy)nodeAnalyse.SqlCodeType).SetResolvedCodeType(sqlCodeType);
            }
        }

        private SqlName GetSqlNameSys() {
            var sqlSysName = this._sqlSysName;
            if (sqlSysName == null) {
                sqlSysName = SqlName.Root.Child("sys", ObjectLevel.Schema);

                // think
                // this._sqlSysName = this._DBScope.ModelDatabase.Schemas.GetValueOrDefault(sqlSysName)?.Name ?? sqlSysName;
                // this.currentScope.ScopeNameResolverContext.Resolve(sqlSysName);
                this._sqlSysName = this.currentScope.ScopeNameResolverContext.ModelDatabase.Schemas.GetValueOrDefault(sqlSysName)?.Name ?? sqlSysName;
            }
            return sqlSysName;
        }
    }
}
