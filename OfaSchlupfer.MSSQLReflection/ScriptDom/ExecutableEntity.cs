using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public abstract class ExecutableEntity : TSqlFragment
	{
		private List<ExecuteParameter> _parameters = new List<ExecuteParameter>();

		public List<ExecuteParameter> Parameters
		{
			get
			{
				return this._parameters;
			}
		}

		public override void AcceptChildren(TSqlFragmentVisitor visitor)
		{
			int i = 0;
			for (int count = this.Parameters.Count; i < count; i++)
			{
				this.Parameters[i].Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
