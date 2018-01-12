namespace OfaSchlupfer.ScriptDom {
    internal class DurabilityTableOptionHelper : OptionsHelper<DurabilityTableOptionKind> {
        internal static readonly DurabilityTableOptionHelper Instance = new DurabilityTableOptionHelper();

        private DurabilityTableOptionHelper() {
            base.AddOptionMapping(DurabilityTableOptionKind.SchemaOnly, "SCHEMA_ONLY");
            base.AddOptionMapping(DurabilityTableOptionKind.SchemaAndData, "SCHEMA_AND_DATA");
        }
    }
}
