using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public abstract class DataModificationSpecification : TSqlFragment
	{
		private TableReference _target;

		private TopRowFilter _topRowFilter;

		private OutputIntoClause _outputIntoClause;

		private OutputClause _outputClause;

		public TableReference Target
		{
			get
			{
				return this._target;
			}
			set
			{
				this.UpdateTokenInfo(value);
				this._target = value;
			}
		}

		public TopRowFilter TopRowFilter
		{
			get
			{
				return this._topRowFilter;
			}
			set
			{
				this.UpdateTokenInfo(value);
				this._topRowFilter = value;
			}
		}

		public OutputIntoClause OutputIntoClause
		{
			get
			{
				return this._outputIntoClause;
			}
			set
			{
				this.UpdateTokenInfo(value);
				this._outputIntoClause = value;
			}
		}

		public OutputClause OutputClause
		{
			get
			{
				return this._outputClause;
			}
			set
			{
				this.UpdateTokenInfo(value);
				this._outputClause = value;
			}
		}

		public override void AcceptChildren(TSqlFragmentVisitor visitor)
		{
			if (this.Target != null)
			{
				this.Target.Accept(visitor);
			}
			if (this.TopRowFilter != null)
			{
				this.TopRowFilter.Accept(visitor);
			}
			if (this.OutputIntoClause != null)
			{
				this.OutputIntoClause.Accept(visitor);
			}
			if (this.OutputClause != null)
			{
				this.OutputClause.Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
