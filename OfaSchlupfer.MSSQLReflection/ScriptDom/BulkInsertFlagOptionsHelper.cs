namespace OfaSchlupfer.ScriptDom {
    internal class BulkInsertFlagOptionsHelper : OptionsHelper<BulkInsertOptionKind> {
        internal static readonly BulkInsertFlagOptionsHelper Instance = new BulkInsertFlagOptionsHelper();

        private BulkInsertFlagOptionsHelper() {
            base.AddOptionMapping(BulkInsertOptionKind.NoTriggers, "NO_TRIGGERS");
            base.AddOptionMapping(BulkInsertOptionKind.KeepIdentity, "KEEPIDENTITY");
            base.AddOptionMapping(BulkInsertOptionKind.KeepNulls, "KEEPNULLS");
            base.AddOptionMapping(BulkInsertOptionKind.TabLock, "TABLOCK");
            base.AddOptionMapping(BulkInsertOptionKind.CheckConstraints, "CHECK_CONSTRAINTS");
            base.AddOptionMapping(BulkInsertOptionKind.FireTriggers, "FIRE_TRIGGERS");
            base.AddOptionMapping(BulkInsertOptionKind.IncludeHidden, "INCLUDE_HIDDEN");
        }
    }
}
