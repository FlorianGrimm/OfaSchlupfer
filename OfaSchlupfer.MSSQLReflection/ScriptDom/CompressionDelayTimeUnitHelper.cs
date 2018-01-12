namespace OfaSchlupfer.ScriptDom {
    internal class CompressionDelayTimeUnitHelper : OptionsHelper<CompressionDelayTimeUnit> {
        internal static readonly CompressionDelayTimeUnitHelper Instance = new CompressionDelayTimeUnitHelper();

        private CompressionDelayTimeUnitHelper() {
            base.AddOptionMapping(CompressionDelayTimeUnit.Unitless, string.Empty);
            base.AddOptionMapping(CompressionDelayTimeUnit.Minute, "MINUTE");
            base.AddOptionMapping(CompressionDelayTimeUnit.Minutes, "MINUTES");
        }
    }
}
