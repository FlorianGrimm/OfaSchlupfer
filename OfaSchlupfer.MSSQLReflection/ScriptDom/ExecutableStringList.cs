using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class ExecutableStringList : ExecutableEntity
	{
		private List<ValueExpression> _strings = new List<ValueExpression>();

		public List<ValueExpression> Strings
		{
			get
			{
				return this._strings;
			}
		}

		public override void Accept(TSqlFragmentVisitor visitor)
		{
			if (visitor != null)
			{
				visitor.ExplicitVisit(this);
			}
		}

		public override void AcceptChildren(TSqlFragmentVisitor visitor)
		{
			base.AcceptChildren(visitor);
			int i = 0;
			for (int count = this.Strings.Count; i < count; i++)
			{
				this.Strings[i].Accept(visitor);
			}
		}
	}
}
