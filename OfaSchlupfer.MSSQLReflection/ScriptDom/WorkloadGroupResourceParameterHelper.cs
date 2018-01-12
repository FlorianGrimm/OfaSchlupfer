using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class WorkloadGroupResourceParameterHelper : OptionsHelper<WorkloadGroupParameterType> {
        internal static readonly WorkloadGroupResourceParameterHelper Instance = new WorkloadGroupResourceParameterHelper();

        private WorkloadGroupResourceParameterHelper() {
            base.AddOptionMapping(WorkloadGroupParameterType.RequestMaxMemoryGrantPercent, "REQUEST_MAX_MEMORY_GRANT_PERCENT");
            base.AddOptionMapping(WorkloadGroupParameterType.RequestMaxCpuTimeSec, "REQUEST_MAX_CPU_TIME_SEC");
            base.AddOptionMapping(WorkloadGroupParameterType.RequestMemoryGrantTimeoutSec, "REQUEST_MEMORY_GRANT_TIMEOUT_SEC");
            base.AddOptionMapping(WorkloadGroupParameterType.MaxDop, "MAX_DOP");
            base.AddOptionMapping(WorkloadGroupParameterType.GroupMaxRequests, "GROUP_MAX_REQUESTS");
            base.AddOptionMapping(WorkloadGroupParameterType.GroupMinMemoryPercent, "GROUP_MIN_MEMORY_PERCENT", SqlVersionFlags.TSql110AndAbove);
        }
    }
}
