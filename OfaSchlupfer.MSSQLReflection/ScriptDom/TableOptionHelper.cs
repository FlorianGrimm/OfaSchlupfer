namespace OfaSchlupfer.ScriptDom {
    internal class TableOptionHelper : OptionsHelper<TableOptionKind> {
        internal static readonly TableOptionHelper Instance = new TableOptionHelper();

        private TableOptionHelper() {
            base.AddOptionMapping(TableOptionKind.Distribution, "DISTRIBUTION");
            base.AddOptionMapping(TableOptionKind.Partition, "PARTITION");
        }
    }
}
