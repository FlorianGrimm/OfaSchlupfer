namespace OfaSchlupfer.ScriptDom {
    internal class EventSessionMemoryPartitionModeTypeHelper : OptionsHelper<EventSessionMemoryPartitionModeType> {
        internal static readonly EventSessionMemoryPartitionModeTypeHelper Instance = new EventSessionMemoryPartitionModeTypeHelper();

        private EventSessionMemoryPartitionModeTypeHelper() {
            base.AddOptionMapping(EventSessionMemoryPartitionModeType.None, "NONE");
            base.AddOptionMapping(EventSessionMemoryPartitionModeType.PerCpu, "PER_CPU");
            base.AddOptionMapping(EventSessionMemoryPartitionModeType.PerNode, "PER_NODE");
        }
    }
}
