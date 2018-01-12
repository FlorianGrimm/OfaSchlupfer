using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class ExistsPredicate : BooleanExpression
	{
		private ScalarSubquery _subquery;

		public ScalarSubquery Subquery
		{
			get
			{
				return this._subquery;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._subquery = value;
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
			if (this.Subquery != null)
			{
				this.Subquery.Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
