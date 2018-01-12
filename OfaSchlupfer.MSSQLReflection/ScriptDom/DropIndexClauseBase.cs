using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public abstract class DropIndexClauseBase : TSqlFragment
	{
		public override void AcceptChildren(TSqlFragmentVisitor visitor)
		{
			base.AcceptChildren(visitor);
		}
	}
}
