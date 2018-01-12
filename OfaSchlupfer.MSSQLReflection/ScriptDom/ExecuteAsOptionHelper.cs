namespace OfaSchlupfer.ScriptDom
{
	internal class ExecuteAsOptionHelper : OptionsHelper<ExecuteAsOption>
	{
		internal static readonly ExecuteAsOptionHelper Instance = new ExecuteAsOptionHelper();

		private ExecuteAsOptionHelper()
		{
			base.AddOptionMapping(ExecuteAsOption.Caller, "CALLER");
			base.AddOptionMapping(ExecuteAsOption.Self, "SELF");
			base.AddOptionMapping(ExecuteAsOption.Owner, "OWNER");
		}
	}
}
