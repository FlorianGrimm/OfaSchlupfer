using antlr;

namespace OfaSchlupfer.ScriptDom {
    internal class ViewOptionHelper : OptionsHelper<ViewOptionKind> {
        internal static readonly ViewOptionHelper Instance = new ViewOptionHelper();

        private ViewOptionHelper() {
            base.AddOptionMapping(ViewOptionKind.Encryption, "ENCRYPTION");
            base.AddOptionMapping(ViewOptionKind.SchemaBinding, "SCHEMABINDING");
            base.AddOptionMapping(ViewOptionKind.ViewMetadata, "VIEW_METADATA");
        }

        protected override TSqlParseErrorException GetMatchingException(IToken token) {
            return new TSqlParseErrorException(TSql80ParserBaseInternal.CreateParseError("SQL46025", token, TSqlParserResource.SQL46025Message, token.getText()));
        }
    }
}
