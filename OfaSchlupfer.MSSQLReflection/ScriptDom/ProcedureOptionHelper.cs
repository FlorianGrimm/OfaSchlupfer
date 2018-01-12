using antlr;
using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class ProcedureOptionHelper : OptionsHelper<ProcedureOptionKind> {
        internal static readonly ProcedureOptionHelper Instance = new ProcedureOptionHelper();

        private ProcedureOptionHelper() {
            base.AddOptionMapping(ProcedureOptionKind.Encryption, "ENCRYPTION");
            base.AddOptionMapping(ProcedureOptionKind.Recompile, "RECOMPILE");
            base.AddOptionMapping(ProcedureOptionKind.NativeCompilation, "NATIVE_COMPILATION", SqlVersionFlags.TSql120AndAbove);
            base.AddOptionMapping(ProcedureOptionKind.SchemaBinding, "SCHEMABINDING", SqlVersionFlags.TSql120AndAbove);
        }

        protected override TSqlParseErrorException GetMatchingException(IToken token) {
            return new TSqlParseErrorException(TSql80ParserBaseInternal.CreateParseError("SQL46006", token, TSqlParserResource.SQL46006Message, token.getText()));
        }
    }
}
