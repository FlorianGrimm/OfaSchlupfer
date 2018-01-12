using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class PortTypesHelper : OptionsHelper<PortTypes> {
        internal static readonly PortTypesHelper Instance = new PortTypesHelper();

        private PortTypesHelper() {
            base.AddOptionMapping(PortTypes.Clear, "CLEAR");
            base.AddOptionMapping(PortTypes.Ssl, "SSL");
        }
    }
}
