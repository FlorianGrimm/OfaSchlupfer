using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class XmlDataTypeOptionHelper : OptionsHelper<XmlDataTypeOption> {
        internal static readonly XmlDataTypeOptionHelper Instance = new XmlDataTypeOptionHelper();

        private XmlDataTypeOptionHelper() {
            base.AddOptionMapping(XmlDataTypeOption.Content, "CONTENT");
            base.AddOptionMapping(XmlDataTypeOption.Document, "DOCUMENT");
        }
    }
}
