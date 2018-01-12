namespace OfaSchlupfer.ScriptDom {
    internal class EnableDisableOptionTypeHelper : OptionsHelper<EnableDisableOptionType> {
        internal static readonly EnableDisableOptionTypeHelper Instance = new EnableDisableOptionTypeHelper();

        private EnableDisableOptionTypeHelper() {
            base.AddOptionMapping(EnableDisableOptionType.Enable, "ENABLE");
            base.AddOptionMapping(EnableDisableOptionType.Disable, "DISABLE");
        }
    }
}
