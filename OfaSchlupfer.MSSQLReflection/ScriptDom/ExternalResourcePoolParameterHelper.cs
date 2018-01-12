using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class ExternalResourcePoolParameterHelper : OptionsHelper<ExternalResourcePoolParameterType> {
        internal static readonly ExternalResourcePoolParameterHelper Instance = new ExternalResourcePoolParameterHelper();

        private ExternalResourcePoolParameterHelper() {
            base.AddOptionMapping(ExternalResourcePoolParameterType.MaxCpuPercent, "MAX_CPU_PERCENT", SqlVersionFlags.TSql130AndAbove);
            base.AddOptionMapping(ExternalResourcePoolParameterType.MaxMemoryPercent, "MAX_MEMORY_PERCENT", SqlVersionFlags.TSql130AndAbove);
            base.AddOptionMapping(ExternalResourcePoolParameterType.MaxProcesses, "MAX_PROCESSES", SqlVersionFlags.TSql130AndAbove);
            base.AddOptionMapping(ExternalResourcePoolParameterType.Affinity, "AFFINITY", SqlVersionFlags.TSql130AndAbove);
        }
    }
}
