using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class DiskStatement : TSqlStatement
	{
		private DiskStatementType _diskStatementType;

		private List<DiskStatementOption> _options = new List<DiskStatementOption>();

		public DiskStatementType DiskStatementType
		{
			get
			{
				return this._diskStatementType;
			}
			set
			{
				this._diskStatementType = value;
			}
		}

		public List<DiskStatementOption> Options
		{
			get
			{
				return this._options;
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
			for (int count = this.Options.Count; i < count; i++)
			{
				this.Options[i].Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
