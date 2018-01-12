using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom.ScriptGenerator {
    internal sealed class Sql80ScriptGeneratorVisitor : SqlScriptGeneratorVisitor {
        private static HashSet<Type> _typesCantHaveSemiColon = new HashSet<Type>
        {
            typeof(CreateViewStatement),
            typeof(AlterViewStatement),
            typeof(CreateFunctionStatement),
            typeof(AlterFunctionStatement),
            typeof(CreateDefaultStatement),
            typeof(CreateRuleStatement),
            typeof(CreateSchemaStatement),
            typeof(TSqlStatementSnippet),
            typeof(CreateTriggerStatement),
            typeof(AlterTriggerStatement),
            typeof(CreateProcedureStatement),
            typeof(AlterProcedureStatement),
            typeof(BeginEndBlockStatement),
            typeof(IfStatement),
            typeof(WhileStatement),
            typeof(LabelStatement),
            typeof(TryCatchStatement)
        };

        internal override HashSet<Type> StatementsThatCannotHaveSemiColon {
            get {
                return Sql80ScriptGeneratorVisitor._typesCantHaveSemiColon;
            }
        }

        public Sql80ScriptGeneratorVisitor(SqlScriptGeneratorOptions options, ScriptWriter writer)
            : base(options, writer) {
            options.SqlVersion = SqlVersion.Sql80;
        }

        protected override void GenerateIndexOptions(IList<IndexOption> options) {
            if (options != null && options.Count > 0) {
                bool flag = true;
                foreach (IndexOption option in options) {
                    IndexStateOption indexStateOption = option as IndexStateOption;
                    if (indexStateOption == null || indexStateOption.OptionState == OptionState.On) {
                        if (flag) {
                            flag = false;
                            base.NewLineAndIndent();
                            base.GenerateKeyword(TSqlTokenType.With);
                            base.GenerateSpace();
                        } else {
                            base.GenerateSymbolAndSpace(TSqlTokenType.Comma);
                        }
                        base.GenerateFragmentIfNotNull(option);
                    }
                }
            }
        }

        public override void ExplicitVisit(IndexStateOption node) {
            if (node.OptionState == OptionState.On) {
                IndexOptionHelper.Instance.GenerateSourceForOption(base._writer, node.OptionKind);
            }
        }
    }
}
