using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class DropAlterFullTextIndexAction : AlterFullTextIndexAction
	{
		private List<Identifier> _columns = new List<Identifier>();

		private bool _withNoPopulation;

		public List<Identifier> Columns
		{
			get
			{
				return this._columns;
			}
		}

		public bool WithNoPopulation
		{
			get
			{
				return this._withNoPopulation;
			}
			set
			{
				this._withNoPopulation = value;
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
			for (int count = this.Columns.Count; i < count; i++)
			{
				this.Columns[i].Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
