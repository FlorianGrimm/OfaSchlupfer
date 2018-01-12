using System;

namespace OfaSchlupfer.ScriptDom
{
	[Flags]
	internal enum ExpressionFlags
	{
		None = 0,
		ScalarSubqueriesDisallowed = 1,
		MatchClauseAllowed = 2
	}
}
