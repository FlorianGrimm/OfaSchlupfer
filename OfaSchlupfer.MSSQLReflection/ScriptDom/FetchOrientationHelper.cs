namespace OfaSchlupfer.ScriptDom {
    internal class FetchOrientationHelper : OptionsHelper<FetchOrientation> {
        internal static readonly FetchOrientationHelper Instance = new FetchOrientationHelper();

        private FetchOrientationHelper() {
            base.AddOptionMapping(FetchOrientation.First, "FIRST");
            base.AddOptionMapping(FetchOrientation.Next, "NEXT");
            base.AddOptionMapping(FetchOrientation.Prior, "PRIOR");
            base.AddOptionMapping(FetchOrientation.Last, "LAST");
            base.AddOptionMapping(FetchOrientation.Relative, "RELATIVE");
            base.AddOptionMapping(FetchOrientation.Absolute, "ABSOLUTE");
        }
    }
}
