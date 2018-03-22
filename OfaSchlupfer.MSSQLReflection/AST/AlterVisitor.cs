#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    internal class AlterVisitor : SqlConcreteFragmentVisitor {
        public static SqlNode Convert(SqlNode source) {
            var that = new AlterVisitor();
            source.Accept(that);
            return that._ResultSqlScript;
        }

        private SqlScript _ResultSqlScript;
        private SqlBatch _Batch;
        private SqlStatement _ReplaceSource;
        private SqlStatement _ReplaceTarget;

        public override void ExplicitVisit(SqlScript node) {
            var result = new SqlScript();
            this._ResultSqlScript = result;
            base.ExplicitVisit(node);
        }

        public override void ExplicitVisit(SqlBatch node) {
            var targetBatch = new SqlBatch();
            this._Batch = targetBatch;
            //base.ExplicitVisit(node);
            var statements = node.Statements;
            for (int i = 0, count = statements.Count; i < count; i++) {
                var statement = statements[i];
                statement.Accept(this);
                if (ReferenceEquals(statement, this._ReplaceSource)) {
                    targetBatch.Statements.Add(this._ReplaceTarget);
                } else {
                    targetBatch.Statements.Add(statement);
                }
            }
            this._ResultSqlScript.Batches.Add(targetBatch);
        }

        public override void ExplicitVisit(CreateFunctionStatement node) {
            var target = new AlterFunctionStatement();
            target.Name = node.Name;
            target.Parameters.AddRange(node.Parameters);
            target.ReturnType = node.ReturnType;
            target.Options.AddRange(node.Options);
            target.StatementList = node.StatementList;
            target.MethodSpecifier = node.MethodSpecifier;
            target.OrderHint = node.OrderHint;
            //base.ExplicitVisit(node);
            this._ReplaceSource = node;
            this._ReplaceTarget = target;
        }

        //public override void ExplicitVisit(CreateOrAlterProcedureStatement node) {
        //    base.ExplicitVisit(node);
        //}

        public override void ExplicitVisit(CreateProcedureStatement node) {
            var target = new AlterProcedureStatement();
            target.ProcedureReference = node.ProcedureReference;
            target.Parameters.AddRange(node.Parameters);
            target.Options.AddRange(node.Options);
            target.StatementList = node.StatementList;
            target.MethodSpecifier = node.MethodSpecifier;
            //base.ExplicitVisit(node);
            this._ReplaceSource = node;
            this._ReplaceTarget = target;
        }

        public override void ExplicitVisit(CreateViewStatement node) {
            var target = new AlterViewStatement();
            target.SchemaObjectName = node.SchemaObjectName;
            target.Columns.AddRange(node.Columns);
            target.ViewOptions.AddRange(node.ViewOptions);
            target.SelectStatement = node.SelectStatement;
            // base.ExplicitVisit(node);
            this._ReplaceSource = node;
            this._ReplaceTarget = target;
        }
    }
}
