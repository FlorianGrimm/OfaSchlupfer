namespace OfaSchlupfer.ScriptDom {
    internal class PseudoColumnHelper : OptionsHelper<ColumnType> {
        internal static readonly PseudoColumnHelper Instance = new PseudoColumnHelper();

        private PseudoColumnHelper() {
            base.AddOptionMapping(ColumnType.PseudoColumnIdentity, "$IDENTITY", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(ColumnType.PseudoColumnRowGuid, "$ROWGUID", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(ColumnType.PseudoColumnAction, "$ACTION", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(ColumnType.PseudoColumnCuid, "$CUID", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(ColumnType.PseudoColumnGraphNodeId, "$NODE_ID", SqlVersionFlags.TSql140);
            base.AddOptionMapping(ColumnType.PseudoColumnGraphEdgeId, "$EDGE_ID", SqlVersionFlags.TSql140);
            base.AddOptionMapping(ColumnType.PseudoColumnGraphFromId, "$FROM_ID", SqlVersionFlags.TSql140);
            base.AddOptionMapping(ColumnType.PseudoColumnGraphToId, "$TO_ID", SqlVersionFlags.TSql140);
        }
    }
}
