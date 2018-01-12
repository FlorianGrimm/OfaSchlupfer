using antlr;
using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class TriggerOptionHelper : OptionsHelper<TriggerOptionKind> {
        internal static readonly TriggerOptionHelper Instance = new TriggerOptionHelper();

        private TriggerOptionHelper() {
            base.AddOptionMapping(TriggerOptionKind.Encryption, "ENCRYPTION");
            base.AddOptionMapping(TriggerOptionKind.NativeCompile, "NATIVE_COMPILATION", SqlVersionFlags.TSql130AndAbove);
            base.AddOptionMapping(TriggerOptionKind.SchemaBinding, "SCHEMABINDING", SqlVersionFlags.TSql130AndAbove);
        }

        protected override TSqlParseErrorException GetMatchingException(IToken token) {
            return new TSqlParseErrorException(TSql80ParserBaseInternal.CreateParseError("SQL46007", token, TSqlParserResource.SQL46007Message, token.getText()));
        }
    }
}
