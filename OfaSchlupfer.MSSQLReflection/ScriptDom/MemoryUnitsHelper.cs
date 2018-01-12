namespace OfaSchlupfer.ScriptDom {
    internal class MemoryUnitsHelper : OptionsHelper<MemoryUnit> {
        internal static readonly MemoryUnitsHelper Instance = new MemoryUnitsHelper();

        private MemoryUnitsHelper() {
            base.AddOptionMapping(MemoryUnit.KB, "KB");
            base.AddOptionMapping(MemoryUnit.MB, "MB");
            base.AddOptionMapping(MemoryUnit.GB, "GB");
            base.AddOptionMapping(MemoryUnit.TB, "TB");
            base.AddOptionMapping(MemoryUnit.Percent, TSqlTokenType.PercentSign);
        }
    }
}
