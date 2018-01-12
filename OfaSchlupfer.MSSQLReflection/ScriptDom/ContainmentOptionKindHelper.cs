namespace OfaSchlupfer.ScriptDom {
    internal class ContainmentOptionKindHelper : OptionsHelper<ContainmentOptionKind> {
        internal static readonly ContainmentOptionKindHelper Instance = new ContainmentOptionKindHelper();

        private ContainmentOptionKindHelper() {
            base.AddOptionMapping(ContainmentOptionKind.None, "NONE");
            base.AddOptionMapping(ContainmentOptionKind.Partial, "PARTIAL");
        }
    }
}
