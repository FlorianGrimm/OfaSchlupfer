namespace OfaSchlupfer.ScriptDom {
    internal class PageVerifyDbOptionsHelper : OptionsHelper<PageVerifyDatabaseOptionKind> {
        internal static readonly PageVerifyDbOptionsHelper Instance = new PageVerifyDbOptionsHelper();

        private PageVerifyDbOptionsHelper() {
            base.AddOptionMapping(PageVerifyDatabaseOptionKind.None, "NONE");
            base.AddOptionMapping(PageVerifyDatabaseOptionKind.Checksum, "CHECKSUM");
            base.AddOptionMapping(PageVerifyDatabaseOptionKind.TornPageDetection, "TORN_PAGE_DETECTION");
        }
    }
}
