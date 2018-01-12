using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class ExternalResourcePoolAffinityHelper : OptionsHelper<ExternalResourcePoolAffinityType> {
        internal static readonly ExternalResourcePoolAffinityHelper Instance = new ExternalResourcePoolAffinityHelper();

        private ExternalResourcePoolAffinityHelper() {
            base.AddOptionMapping(ExternalResourcePoolAffinityType.Cpu, "CPU", SqlVersionFlags.TSql130AndAbove);
            base.AddOptionMapping(ExternalResourcePoolAffinityType.NumaNode, "NUMANODE", SqlVersionFlags.TSql130AndAbove);
        }
    }
}
