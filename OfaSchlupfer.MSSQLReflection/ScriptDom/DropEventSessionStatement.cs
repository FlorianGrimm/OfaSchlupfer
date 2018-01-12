using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class DropEventSessionStatement : DropUnownedObjectStatement
	{
		private EventSessionScope _sessionScope;

		public EventSessionScope SessionScope
		{
			get
			{
				return this._sessionScope;
			}
			set
			{
				this._sessionScope = value;
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
