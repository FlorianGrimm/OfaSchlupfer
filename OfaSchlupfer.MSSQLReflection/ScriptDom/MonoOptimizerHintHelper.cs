namespace OfaSchlupfer.ScriptDom {
    internal class MonoOptimizerHintHelper : OptionsHelper<OptimizerHintKind> {
        internal static readonly MonoOptimizerHintHelper Instance = new MonoOptimizerHintHelper();

        private MonoOptimizerHintHelper() {
            base.AddOptionMapping(OptimizerHintKind.Recompile, "RECOMPILE", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(OptimizerHintKind.IgnoreNonClusteredColumnStoreIndex, "IGNORE_NONCLUSTERED_COLUMNSTORE_INDEX", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(OptimizerHintKind.NoPerformanceSpool, "NO_PERFORMANCE_SPOOL", SqlVersionFlags.TSql130AndAbove);
        }
    }
}
