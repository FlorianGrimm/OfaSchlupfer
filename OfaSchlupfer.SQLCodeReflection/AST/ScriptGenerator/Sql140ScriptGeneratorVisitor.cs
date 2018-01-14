using System;
using System.Collections.Generic;

namespace OfaSchlupfer.AST.ScriptGenerator {
    internal class Sql140ScriptGeneratorVisitor : SqlScriptGeneratorVisitor {
        private static HashSet<Type> _typesCantHaveSemiColon = new HashSet<Type>
        {
            typeof(CreateProcedureStatement),
            typeof(AlterProcedureStatement),
            typeof(CreateFunctionStatement),
            typeof(AlterFunctionStatement),
            typeof(CreateTriggerStatement),
            typeof(AlterTriggerStatement),
            typeof(TSqlStatementSnippet),
            typeof(BeginEndBlockStatement),
            typeof(IfStatement),
            typeof(WhileStatement),
            typeof(LabelStatement),
            typeof(TryCatchStatement),
            typeof(CreateOrAlterProcedureStatement),
            typeof(CreateOrAlterFunctionStatement),
            typeof(CreateOrAlterTriggerStatement)
        };

        internal override HashSet<Type> StatementsThatCannotHaveSemiColon {
            get {
                return Sql140ScriptGeneratorVisitor._typesCantHaveSemiColon;
            }
        }

        public Sql140ScriptGeneratorVisitor(SqlScriptGeneratorOptions options, ScriptWriter writer)
            : base(options, writer) {
            options.SqlVersion = SqlVersion.Sql140;
        }
    }
}
