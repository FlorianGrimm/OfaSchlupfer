namespace OfaSchlupfer.ScriptDom {
    internal class GenerateAlwaysTypeHelper : OptionsHelper<GeneratedAlwaysType> {
        internal static readonly GenerateAlwaysTypeHelper Instance = new GenerateAlwaysTypeHelper();

        private GenerateAlwaysTypeHelper() {
            base.AddOptionMapping(GeneratedAlwaysType.RowStart, "START");
            base.AddOptionMapping(GeneratedAlwaysType.RowEnd, "END");
        }
    }
}
