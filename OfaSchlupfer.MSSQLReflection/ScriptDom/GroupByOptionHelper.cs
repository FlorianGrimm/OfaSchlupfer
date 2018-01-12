using antlr;

namespace OfaSchlupfer.ScriptDom {
    internal class GroupByOptionHelper : OptionsHelper<GroupByOption> {
        internal static readonly GroupByOptionHelper Instance = new GroupByOptionHelper();

        private GroupByOptionHelper() {
            base.AddOptionMapping(GroupByOption.Cube, "CUBE");
            base.AddOptionMapping(GroupByOption.Rollup, "ROLLUP");
        }

        protected override TSqlParseErrorException GetMatchingException(IToken token) {
            return new TSqlParseErrorException(TSql80ParserBaseInternal.CreateParseError("SQL46023", token, TSqlParserResource.SQL46023Message, token.getText()));
        }
    }
}
