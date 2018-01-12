namespace OfaSchlupfer.ScriptDom {
    internal class GridParameterTypeHelper : OptionsHelper<GridParameterType> {
        internal static readonly GridParameterTypeHelper Instance = new GridParameterTypeHelper();

        private GridParameterTypeHelper() {
            base.AddOptionMapping(GridParameterType.Level1, "LEVEL_1");
            base.AddOptionMapping(GridParameterType.Level2, "LEVEL_2");
            base.AddOptionMapping(GridParameterType.Level3, "LEVEL_3");
            base.AddOptionMapping(GridParameterType.Level4, "LEVEL_4");
        }
    }
}
