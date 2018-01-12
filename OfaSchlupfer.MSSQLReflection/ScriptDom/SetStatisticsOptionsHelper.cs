using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	internal class SetStatisticsOptionsHelper : OptionsHelper<SetStatisticsOptions>
	{
		internal static readonly SetStatisticsOptionsHelper Instance = new SetStatisticsOptionsHelper();

		private SetStatisticsOptionsHelper()
		{
			base.AddOptionMapping(SetStatisticsOptions.IO, "IO", SqlVersionFlags.TSqlAll);
			base.AddOptionMapping(SetStatisticsOptions.Profile, "PROFILE", SqlVersionFlags.TSqlAll);
			base.AddOptionMapping(SetStatisticsOptions.Time, "TIME", SqlVersionFlags.TSqlAll);
			base.AddOptionMapping(SetStatisticsOptions.Xml, "XML", SqlVersionFlags.TSql90AndAbove);
		}
	}
}
