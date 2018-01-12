using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class DelayedDurabilityDatabaseOption : DatabaseOption
	{
		private DelayedDurabilityOptionKind _value;

		public DelayedDurabilityOptionKind Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = value;
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
