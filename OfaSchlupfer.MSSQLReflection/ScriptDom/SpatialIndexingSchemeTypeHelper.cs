namespace OfaSchlupfer.ScriptDom {
    internal class SpatialIndexingSchemeTypeHelper : OptionsHelper<SpatialIndexingSchemeType> {
        internal static readonly SpatialIndexingSchemeTypeHelper Instance = new SpatialIndexingSchemeTypeHelper();

        private SpatialIndexingSchemeTypeHelper() {
            base.AddOptionMapping(SpatialIndexingSchemeType.GeographyGrid, "GEOGRAPHY_GRID");
            base.AddOptionMapping(SpatialIndexingSchemeType.GeometryGrid, "GEOMETRY_GRID");
            base.AddOptionMapping(SpatialIndexingSchemeType.GeographyAutoGrid, "GEOGRAPHY_AUTO_GRID", SqlVersionFlags.TSql110AndAbove);
            base.AddOptionMapping(SpatialIndexingSchemeType.GeometryAutoGrid, "GEOMETRY_AUTO_GRID", SqlVersionFlags.TSql110AndAbove);
        }
    }
}
