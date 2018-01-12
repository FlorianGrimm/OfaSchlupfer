namespace OfaSchlupfer.ScriptDom {
    internal class XmlForClauseOptionsHelper : OptionsHelper<XmlForClauseOptions> {
        internal static readonly XmlForClauseOptionsHelper Instance = new XmlForClauseOptionsHelper();

        private XmlForClauseOptionsHelper() {
            base.AddOptionMapping(XmlForClauseOptions.Elements, "ELEMENTS");
            base.AddOptionMapping(XmlForClauseOptions.Root, "ROOT");
            base.AddOptionMapping(XmlForClauseOptions.XmlSchema, "XMLSCHEMA");
            base.AddOptionMapping(XmlForClauseOptions.XmlData, "XMLDATA");
            base.AddOptionMapping(XmlForClauseOptions.Type, "TYPE");
        }
    }
}
