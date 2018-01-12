using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class ImportanceParameterHelper : OptionsHelper<ImportanceParameterType> {
        internal static readonly ImportanceParameterHelper Instance = new ImportanceParameterHelper();

        private ImportanceParameterHelper() {
            base.AddOptionMapping(ImportanceParameterType.Low, "LOW");
            base.AddOptionMapping(ImportanceParameterType.High, "HIGH");
            base.AddOptionMapping(ImportanceParameterType.Medium, "MEDIUM");
        }
    }
}
