using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class ResourcePoolParameterHelper : OptionsHelper<ResourcePoolParameterType> {
        internal static readonly ResourcePoolParameterHelper Instance = new ResourcePoolParameterHelper();

        private ResourcePoolParameterHelper() {
            base.AddOptionMapping(ResourcePoolParameterType.MaxCpuPercent, "MAX_CPU_PERCENT");
            base.AddOptionMapping(ResourcePoolParameterType.MaxMemoryPercent, "MAX_MEMORY_PERCENT");
            base.AddOptionMapping(ResourcePoolParameterType.MinCpuPercent, "MIN_CPU_PERCENT");
            base.AddOptionMapping(ResourcePoolParameterType.MinMemoryPercent, "MIN_MEMORY_PERCENT");
            base.AddOptionMapping(ResourcePoolParameterType.CapCpuPercent, "CAP_CPU_PERCENT", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(ResourcePoolParameterType.TargetMemoryPercent, "TARGET_MEMORY_PERCENT", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(ResourcePoolParameterType.MinIoPercent, "MIN_IO_PERCENT", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(ResourcePoolParameterType.MaxIoPercent, "MAX_IO_PERCENT", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(ResourcePoolParameterType.CapIoPercent, "CAP_IO_PERCENT", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(ResourcePoolParameterType.Affinity, "AFFINITY", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(ResourcePoolParameterType.MinIopsPerVolume, "MIN_IOPS_PER_VOLUME", SqlVersionFlags.TSql120AndAbove);
            base.AddOptionMapping(ResourcePoolParameterType.MaxIopsPerVolume, "MAX_IOPS_PER_VOLUME", SqlVersionFlags.TSql120AndAbove);
        }
    }
}
