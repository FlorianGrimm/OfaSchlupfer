using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom.ScriptGenerator {
    internal class Sql110ScriptGeneratorVisitor : SqlScriptGeneratorVisitor {
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
            typeof(TryCatchStatement)
        };

        internal override HashSet<Type> StatementsThatCannotHaveSemiColon {
            get {
                return Sql110ScriptGeneratorVisitor._typesCantHaveSemiColon;
            }
        }

        public Sql110ScriptGeneratorVisitor(SqlScriptGeneratorOptions options, ScriptWriter writer)
            : base(options, writer) {
            options.SqlVersion = SqlVersion.Sql110;
        }
    }
}
