using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class DropIndexStatement : TSqlStatement
	{
		private List<DropIndexClauseBase> _dropIndexClauses = new List<DropIndexClauseBase>();

		private bool _isIfExists;

		public List<DropIndexClauseBase> DropIndexClauses
		{
			get
			{
				return this._dropIndexClauses;
			}
		}

		public bool IsIfExists
		{
			get
			{
				return this._isIfExists;
			}
			set
			{
				this._isIfExists = value;
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
			int i = 0;
			for (int count = this.DropIndexClauses.Count; i < count; i++)
			{
				this.DropIndexClauses[i].Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
