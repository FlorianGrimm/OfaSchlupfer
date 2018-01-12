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

        public TSqlBindVisitor(SqlCodeScope dbScope) {
            this._Scopes = new Stack<SqlCodeScope>();
            this._DBScope = dbScope;
            this.currentScope = dbScope;
            this._Scopes.Push(dbScope);
        }

        public override void ExplicitVisit(TSqlScript node) {
            node.SqlCodeScope = this._DBScope;
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(TSqlBatch node) {
            var batchScope = this._DBScope.CreateChildScope("Batch");
            node.SqlCodeScope = batchScope;
            this._Scopes.Push(batchScope);
            this.currentScope = batchScope;

            // base.ExplicitVisit(node);
            // think carefully
            /*
            var node_Statements = node.Statements;
            SqlCodeScope scopeLastStatement = null;
            for (int i = 0, count = node_Statements.Count; i < count; i++) {
                var statement = node_Statements[i];
                SqlCodeScope scopeStatement = null;
                if (i == 0 || scopeLastStatement == null) {
                    scopeStatement = batchScope.CreateChildScope(statement.GetType().Name);
                    this._Scopes.Push(scopeStatement);
                    this.currentScope = scopeStatement;
                    scopeLastStatement = scopeStatement;
                } else if (scopeLastStatement.HasContent) {
                    scopeStatement = scopeLastStatement.CreateNextScope(statement.GetType().Name);
                    this._Scopes.Pop();
                    this._Scopes.Push(scopeStatement);
                    this.currentScope = scopeStatement;
                    scopeLastStatement = scopeStatement;
                }
                //statement.SqlCodeScope = this.
                this.ExplicitVisit(statement);
                //if (statement.SqlCodeScope)
                if (scopeStatement != null) {

                }
            }
            if (scopeLastStatement != null) {
                this._Scopes.Pop();
            }
            */

            var node_Statements = node.Statements;
            for (int i = 0, count = node_Statements.Count; i < count; i++) {
                var statement = node_Statements[i];
                this.ExplicitVisit(statement);
            }

            // base

            this._Scopes.Pop();
            this.currentScope = this._Scopes.Peek();
        }

        public override void Visit(TSqlFragment node) {
            if (node.SqlCodeScope == null) {
                node.SqlCodeScope = currentScope;
            }
            System.Diagnostics.Debug.WriteLine(node.GetType().Name);
            base.Visit(node);
        }

        public override void ExplicitVisit(DeclareVariableElement node) {
            node.SqlCodeScope = this.currentScope;
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

        /*
         QueryParenthesisExpression
         */
    }
}
