namespace OfaSchlupfer.ScriptDom {
    internal class GeneralSetCommandTypeHelper : OptionsHelper<GeneralSetCommandType> {
        internal static readonly GeneralSetCommandTypeHelper Instance = new GeneralSetCommandTypeHelper();

        private GeneralSetCommandTypeHelper() {
            base.AddOptionMapping(GeneralSetCommandType.Language, "LANGUAGE");
            base.AddOptionMapping(GeneralSetCommandType.DateFormat, "DATEFORMAT");
            base.AddOptionMapping(GeneralSetCommandType.DateFirst, "DATEFIRST");
            base.AddOptionMapping(GeneralSetCommandType.DeadlockPriority, "DEADLOCK_PRIORITY");
            base.AddOptionMapping(GeneralSetCommandType.LockTimeout, "LOCK_TIMEOUT");
            base.AddOptionMapping(GeneralSetCommandType.QueryGovernorCostLimit, "QUERY_GOVERNOR_COST_LIMIT");
            base.AddOptionMapping(GeneralSetCommandType.ContextInfo, "CONTEXT_INFO");
        }
    }
}
