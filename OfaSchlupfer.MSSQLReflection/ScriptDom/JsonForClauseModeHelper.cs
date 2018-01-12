namespace OfaSchlupfer.ScriptDom {
    internal class JsonForClauseModeHelper : OptionsHelper<JsonForClauseOptions> {
        internal static readonly JsonForClauseModeHelper Instance = new JsonForClauseModeHelper();

        private JsonForClauseModeHelper() {
            base.AddOptionMapping(JsonForClauseOptions.Auto, "AUTO");
            base.AddOptionMapping(JsonForClauseOptions.Path, "PATH");
        }
    }
}
