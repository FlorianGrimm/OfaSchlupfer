namespace OfaSchlupfer.ScriptDom {
    internal class IntegerOptimizerHintHelper : OptionsHelper<OptimizerHintKind> {
        internal static readonly IntegerOptimizerHintHelper Instance = new IntegerOptimizerHintHelper();

        private IntegerOptimizerHintHelper() {
            base.AddOptionMapping(OptimizerHintKind.Fast, "FAST", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(OptimizerHintKind.MaxDop, "MAXDOP", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(OptimizerHintKind.UsePlan, "USEPLAN", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(OptimizerHintKind.MaxRecursion, "MAXRECURSION", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(OptimizerHintKind.QueryTraceOn, "QUERYTRACEON", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(OptimizerHintKind.CardinalityTunerLimit, "CARDINALITY_TUNER_LIMIT", SqlVersionFlags.TSql100AndAbove);
        }
    }
}
