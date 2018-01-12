namespace OfaSchlupfer.ScriptDom {
    internal class SessionOptionUnitHelper : OptionsHelper<MemoryUnit> {
        internal static readonly SessionOptionUnitHelper Instance = new SessionOptionUnitHelper();

        private SessionOptionUnitHelper() {
            base.AddOptionMapping(MemoryUnit.KB, "KB");
            base.AddOptionMapping(MemoryUnit.MB, "MB");
        }
    }
}
