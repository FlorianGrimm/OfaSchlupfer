namespace OfaSchlupfer.ScriptDom {
    internal class AttachModeHelper : OptionsHelper<AttachMode> {
        internal static readonly AttachModeHelper Instance = new AttachModeHelper();

        private AttachModeHelper() {
            base.AddOptionMapping(AttachMode.Attach, "ATTACH");
            base.AddOptionMapping(AttachMode.AttachRebuildLog, "ATTACH_REBUILD_LOG");
            base.AddOptionMapping(AttachMode.AttachForceRebuildLog, "ATTACH_FORCE_REBUILD_LOG");
            base.AddOptionMapping(AttachMode.Load, "LOAD");
        }
    }
}
