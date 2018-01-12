using antlr;

namespace OfaSchlupfer.ScriptDom {
    internal class StatisticsOptionHelper : OptionsHelper<StatisticsOptionKind> {
        internal static readonly StatisticsOptionHelper Instance = new StatisticsOptionHelper();

        private StatisticsOptionHelper() {
            base.AddOptionMapping(StatisticsOptionKind.FullScan, "FULLSCAN");
            base.AddOptionMapping(StatisticsOptionKind.NoRecompute, "NORECOMPUTE");
            base.AddOptionMapping(StatisticsOptionKind.Resample, "RESAMPLE");
            base.AddOptionMapping(StatisticsOptionKind.Columns, "COLUMNS");
        }

        protected override TSqlParseErrorException GetMatchingException(IToken token) {
            return new TSqlParseErrorException(TSql80ParserBaseInternal.CreateParseError("SQL46020", token, TSqlParserResource.SQL46020Message, token.getText()));
        }
    }
}
