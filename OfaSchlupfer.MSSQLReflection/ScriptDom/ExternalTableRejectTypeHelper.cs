namespace OfaSchlupfer.ScriptDom {
    internal class ExternalTableRejectTypeHelper : OptionsHelper<ExternalTableRejectType> {
        internal static readonly ExternalTableRejectTypeHelper Instance = new ExternalTableRejectTypeHelper();

        private ExternalTableRejectTypeHelper() {
            base.AddOptionMapping(ExternalTableRejectType.Value, "VALUE");
            base.AddOptionMapping(ExternalTableRejectType.Percentage, "PERCENTAGE");
        }
    }
}
