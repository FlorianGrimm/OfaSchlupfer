namespace OfaSchlupfer.ScriptDom {
    internal class AlterIndexTypeHelper : OptionsHelper<AlterIndexType> {
        internal static readonly AlterIndexTypeHelper Instance = new AlterIndexTypeHelper();

        private AlterIndexTypeHelper() {
            base.AddOptionMapping(AlterIndexType.Disable, "DISABLE");
            base.AddOptionMapping(AlterIndexType.Rebuild, "REBUILD");
            base.AddOptionMapping(AlterIndexType.Reorganize, "REORGANIZE");
            base.AddOptionMapping(AlterIndexType.Set, TSqlTokenType.Set);
            base.AddOptionMapping(AlterIndexType.Abort, "ABORT", SqlVersionFlags.TSql140);
            base.AddOptionMapping(AlterIndexType.Pause, "PAUSE", SqlVersionFlags.TSql140);
            base.AddOptionMapping(AlterIndexType.Resume, "RESUME", SqlVersionFlags.TSql140);
        }
    }
}
