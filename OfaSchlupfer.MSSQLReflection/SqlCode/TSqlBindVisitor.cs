namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OfaSchlupfer.MSSQLReflection.Model;
    using OfaSchlupfer.ScriptDom;

    internal class TSqlBindVisitor : TSqlConcreteFragmentVisitor {
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

        internal List<AnalyseResult> Run(TSqlFragment fragment) {
            fragment.Accept(this);
            return this._AnalyseResults;
        }

        public override void ExplicitVisit(TSqlScript node) {
            node.SqlCodeScope = this._DBScope;
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(TSqlBatch node) {
            var declarationScope = this._DBScope.CreateChildDeclarationScope("Declaration");
            this._Scopes.Push(declarationScope);

            //
            var batchScope = declarationScope.CreateChildScope("TSqlBatch");
            node.SqlCodeScope = batchScope;
            this._Scopes.Push(batchScope);
            this.currentScope = batchScope;

            // base.ExplicitVisit(node);
            // think carefully

            var node_Statements = node.Statements;
            SqlCodeScope scopeLastStatement = batchScope;
            for (int i = 0, count = node_Statements.Count; i < count; i++) {
                var statement = node_Statements[i];
                SqlCodeScope scopeStatement = null;
                if (scopeLastStatement.HasContent) {
                    scopeStatement = scopeLastStatement.CreateNextScope(statement.GetType().Name);
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
                TSqlFragment = node
            });

            var pop1 = this._Scopes.Pop();
            System.Diagnostics.Debug.Assert(ReferenceEquals(scopeLastStatement, pop1));
            var pop2 = this._Scopes.Pop();
            System.Diagnostics.Debug.Assert(ReferenceEquals(declarationScope, pop2));
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

            // base

        }

        public override void Visit(TSqlFragment node) {
            if (node.SqlCodeScope == null) {
                node.SqlCodeScope = currentScope;
            }
            System.Diagnostics.Debug.WriteLine(node.GetType().Name);
            base.Visit(node);
        }

        public override void ExplicitVisit(DeclareVariableElement node) {
            var declarationScope = this.currentScope.GetDeclarationScope();
            node.SqlCodeScope = declarationScope;
            var variableNameValue = node.VariableName.Value;
            var lazy = new SqlCodeTypeLazy(node.DataType);
            node.DataType.SqlCodeType = lazy;
            node.SqlCodeType = lazy;
            node.SqlCodeScope.Add(variableNameValue, lazy);
            base.ExplicitVisit(node);
            var resolved = node.SqlCodeType.GetResolved();
            if (resolved != null) {
                node.SqlCodeType = resolved;
            }
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
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(SqlDataTypeReference node) {
            var name = node.Name;
            var parameters = node.Parameters;
            if ((name.Identifiers.Count == 1) && (parameters.Count == 0)) {
                var sqlName = SqlName.Parse(name.BaseIdentifier.Value);
                var sqlSysName = SqlName.Root.Child("sys").Child(sqlName.Name);
                var sqlCodeType = this.currentScope.Resolve(sqlSysName);
                if (sqlCodeType == null) {
                    // too bad
                } else if (node.SqlCodeType == null) {
                    node.SqlCodeType = sqlCodeType;
                } else if (node.SqlCodeType is SqlCodeTypeLazy) {
                    ((SqlCodeTypeLazy)node.SqlCodeType).SetResolved(sqlCodeType);
                }
            } else {
                if (System.Diagnostics.Debugger.IsAttached) {
                    System.Diagnostics.Debugger.Break();
                }
                node.SqlCodeType = null;
            }
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(UserDataTypeReference node) {
            var name = node.Name;
            var parameters = node.Parameters;
            if (System.Diagnostics.Debugger.IsAttached) {
                System.Diagnostics.Debugger.Break();
            }
            node.SqlCodeType = null;
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
            var sys_int_model = this._DBScope.ModelDatabase.GetTypeByName(sys_int_name);
            ISqlCodeType sqlCodeType = new SqlCodeTypeSingle(sys_int_model);
            node.SqlCodeType = sqlCodeType;
            node.SqlCodeResult = new SqlCodeResultConst(sqlCodeType, node.Value);
            base.ExplicitVisit(node);
        }


        private SqlName GetSqlNameSys() {
            var sqlSysName = this._sqlSysName;
            if (sqlSysName == null) {
                sqlSysName = SqlName.Root.ChildWellkown("sys");
                this._sqlSysName = this._DBScope.ModelDatabase.GetSchemaByName(sqlSysName)?.Name ?? sqlSysName;
            }
            return sqlSysName;
        }

    }
    public class AnalyseResult {
        public TSqlFragment TSqlFragment { get; set; }

        public SqlCodeScope DeclarationScope { get; set; }

        public SqlCodeScope LastScope { get; set; }

        public ISqlCodeResult SqlCodeResult { get; set; }

        public ISqlCodeType SqlCodeType { get; set; }
    }
}
