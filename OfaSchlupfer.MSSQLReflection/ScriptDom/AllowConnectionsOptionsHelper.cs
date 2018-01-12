namespace OfaSchlupfer.ScriptDom {
    internal class AllowConnectionsOptionsHelper : OptionsHelper<AllowConnectionsOptionKind> {
        public static readonly AllowConnectionsOptionsHelper Instance = new AllowConnectionsOptionsHelper();

        private AllowConnectionsOptionsHelper() {
            base.AddOptionMapping(AllowConnectionsOptionKind.All, "ALL");
            base.AddOptionMapping(AllowConnectionsOptionKind.No, "NO");
            base.AddOptionMapping(AllowConnectionsOptionKind.ReadOnly, "READ_ONLY");
            base.AddOptionMapping(AllowConnectionsOptionKind.ReadWrite, "READ_WRITE");
        }
    }
}
