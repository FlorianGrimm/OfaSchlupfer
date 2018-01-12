namespace OfaSchlupfer.ScriptDom {
    internal class BoundingBoxParameterTypeHelper : OptionsHelper<BoundingBoxParameterType> {
        internal static readonly BoundingBoxParameterTypeHelper Instance = new BoundingBoxParameterTypeHelper();

        private BoundingBoxParameterTypeHelper() {
            base.AddOptionMapping(BoundingBoxParameterType.XMin, "XMIN");
            base.AddOptionMapping(BoundingBoxParameterType.YMin, "YMIN");
            base.AddOptionMapping(BoundingBoxParameterType.XMax, "XMAX");
            base.AddOptionMapping(BoundingBoxParameterType.YMax, "YMAX");
        }
    }
}
