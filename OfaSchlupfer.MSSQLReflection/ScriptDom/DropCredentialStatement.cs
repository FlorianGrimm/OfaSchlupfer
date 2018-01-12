using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class DropCredentialStatement : DropUnownedObjectStatement
	{
		private bool _isDatabaseScoped;

		public bool IsDatabaseScoped
		{
			get
			{
				return this._isDatabaseScoped;
			}
			set
			{
				this._isDatabaseScoped = value;
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
		}
	}
}
