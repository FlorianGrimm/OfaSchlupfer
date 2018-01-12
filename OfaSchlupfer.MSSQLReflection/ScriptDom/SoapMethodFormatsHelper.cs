using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class SoapMethodFormatsHelper : OptionsHelper<SoapMethodFormat> {
        internal static readonly SoapMethodFormatsHelper Instance = new SoapMethodFormatsHelper();

        private SoapMethodFormatsHelper() {
            base.AddOptionMapping(SoapMethodFormat.AllResults, "ALL_RESULTS");
            base.AddOptionMapping(SoapMethodFormat.RowsetsOnly, "ROWSETS_ONLY");
            base.AddOptionMapping(SoapMethodFormat.None, "NONE");
        }
    }
}
