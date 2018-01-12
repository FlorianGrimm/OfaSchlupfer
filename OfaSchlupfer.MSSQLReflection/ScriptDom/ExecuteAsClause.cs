using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class ExecuteAsClause : TSqlFragment
	{
		private ExecuteAsOption _executeAsOption;

		private Literal _literal;

		public ExecuteAsOption ExecuteAsOption
		{
			get
			{
				return this._executeAsOption;
			}
			set
			{
				this._executeAsOption = value;
			}
		}

		public Literal Literal
		{
			get
			{
				return this._literal;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._literal = value;
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
			if (this.Literal != null)
			{
				this.Literal.Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
