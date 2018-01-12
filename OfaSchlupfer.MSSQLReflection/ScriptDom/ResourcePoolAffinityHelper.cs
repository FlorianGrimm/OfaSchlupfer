using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class ResourcePoolAffinityHelper : OptionsHelper<ResourcePoolAffinityType> {
        internal static readonly ResourcePoolAffinityHelper Instance = new ResourcePoolAffinityHelper();

        private ResourcePoolAffinityHelper() {
            base.AddOptionMapping(ResourcePoolAffinityType.Scheduler, "SCHEDULER");
            base.AddOptionMapping(ResourcePoolAffinityType.NumaNode, "NUMANODE");
        }
    }
}
