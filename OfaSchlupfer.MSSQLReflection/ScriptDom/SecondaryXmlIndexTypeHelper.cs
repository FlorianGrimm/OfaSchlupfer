using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class SecondaryXmlIndexTypeHelper : OptionsHelper<SecondaryXmlIndexType> {
        internal static readonly SecondaryXmlIndexTypeHelper Instance = new SecondaryXmlIndexTypeHelper();

        private SecondaryXmlIndexTypeHelper() {
            base.AddOptionMapping(SecondaryXmlIndexType.Path, "PATH");
            base.AddOptionMapping(SecondaryXmlIndexType.Property, "PROPERTY");
            base.AddOptionMapping(SecondaryXmlIndexType.Value, "VALUE");
        }
    }
}
