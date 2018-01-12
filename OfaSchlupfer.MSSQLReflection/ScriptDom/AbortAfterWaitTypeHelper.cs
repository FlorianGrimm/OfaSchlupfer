namespace OfaSchlupfer.ScriptDom {
    internal class AbortAfterWaitTypeHelper : OptionsHelper<AbortAfterWaitType> {
        public static readonly AbortAfterWaitTypeHelper Instance = new AbortAfterWaitTypeHelper();

        private AbortAfterWaitTypeHelper() {
            base.AddOptionMapping(AbortAfterWaitType.None, "NONE");
            base.AddOptionMapping(AbortAfterWaitType.Blockers, "BLOCKERS");
            base.AddOptionMapping(AbortAfterWaitType.Self, "SELF");
        }
    }
}
