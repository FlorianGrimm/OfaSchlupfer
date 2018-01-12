namespace OfaSchlupfer.ScriptDom {
    internal class EventSessionEventRetentionModeTypeHelper : OptionsHelper<EventSessionEventRetentionModeType> {
        internal static readonly EventSessionEventRetentionModeTypeHelper Instance = new EventSessionEventRetentionModeTypeHelper();

        private EventSessionEventRetentionModeTypeHelper() {
            base.AddOptionMapping(EventSessionEventRetentionModeType.AllowMultipleEventLoss, "ALLOW_MULTIPLE_EVENT_LOSS");
            base.AddOptionMapping(EventSessionEventRetentionModeType.AllowSingleEventLoss, "ALLOW_SINGLE_EVENT_LOSS");
            base.AddOptionMapping(EventSessionEventRetentionModeType.NoEventLoss, "NO_EVENT_LOSS");
        }
    }
}
