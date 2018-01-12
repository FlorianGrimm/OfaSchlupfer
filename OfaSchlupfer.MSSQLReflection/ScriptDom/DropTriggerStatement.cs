using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class DropTriggerStatement : DropObjectsStatement
	{
		private TriggerScope _triggerScope;

		public TriggerScope TriggerScope
		{
			get
			{
				return this._triggerScope;
			}
			set
			{
				this._triggerScope = value;
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
