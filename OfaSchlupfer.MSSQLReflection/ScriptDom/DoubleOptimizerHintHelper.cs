namespace OfaSchlupfer.ScriptDom
{
	internal class DoubleOptimizerHintHelper : OptionsHelper<OptimizerHintKind>
	{
		internal static readonly DoubleOptimizerHintHelper Instance = new DoubleOptimizerHintHelper();

		private DoubleOptimizerHintHelper()
		{
			base.AddOptionMapping(OptimizerHintKind.MaxGrantPercent, "MAX_GRANT_PERCENT", SqlVersionFlags.TSql130AndAbove);
			base.AddOptionMapping(OptimizerHintKind.MinGrantPercent, "MIN_GRANT_PERCENT", SqlVersionFlags.TSql130AndAbove);
		}
	}
}
