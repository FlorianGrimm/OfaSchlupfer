namespace OfaSchlupfer.ScriptDom {
    internal class XmlForClauseModeHelper : OptionsHelper<XmlForClauseOptions> {
        internal static readonly XmlForClauseModeHelper Instance = new XmlForClauseModeHelper();

        private XmlForClauseModeHelper() {
            base.AddOptionMapping(XmlForClauseOptions.Auto, "AUTO");
            base.AddOptionMapping(XmlForClauseOptions.Raw, "RAW");
            base.AddOptionMapping(XmlForClauseOptions.Explicit, "EXPLICIT");
            base.AddOptionMapping(XmlForClauseOptions.Path, "PATH");
        }
    }
}
