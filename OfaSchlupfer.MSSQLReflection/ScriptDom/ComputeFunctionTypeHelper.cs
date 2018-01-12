using antlr;

namespace OfaSchlupfer.ScriptDom {
    internal class ComputeFunctionTypeHelper : OptionsHelper<ComputeFunctionType> {
        internal static readonly ComputeFunctionTypeHelper Instance = new ComputeFunctionTypeHelper();

        private ComputeFunctionTypeHelper() {
            base.AddOptionMapping(ComputeFunctionType.Count, "COUNT");
            base.AddOptionMapping(ComputeFunctionType.CountBig, "COUNT_BIG");
            base.AddOptionMapping(ComputeFunctionType.Max, "MAX");
            base.AddOptionMapping(ComputeFunctionType.Min, "MIN");
            base.AddOptionMapping(ComputeFunctionType.Sum, "SUM");
            base.AddOptionMapping(ComputeFunctionType.Avg, "AVG");
            base.AddOptionMapping(ComputeFunctionType.Var, "VAR");
            base.AddOptionMapping(ComputeFunctionType.Varp, "VARP");
            base.AddOptionMapping(ComputeFunctionType.Stdev, "STDEV");
            base.AddOptionMapping(ComputeFunctionType.Stdevp, "STDEVP");
            base.AddOptionMapping(ComputeFunctionType.ChecksumAgg, "CHECKSUM_AGG");
            base.AddOptionMapping(ComputeFunctionType.ModularSum, "MODULAR_SUM");
        }

        protected override TSqlParseErrorException GetMatchingException(IToken token) {
            return new TSqlParseErrorException(TSql80ParserBaseInternal.CreateParseError("SQL46024", token, TSqlParserResource.SQL46024Message, token.getText()));
        }
    }
}
