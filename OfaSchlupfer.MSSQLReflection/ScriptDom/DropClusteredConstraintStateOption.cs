using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class DropClusteredConstraintStateOption : DropClusteredConstraintOption
	{
		private OptionState _optionState;

		public OptionState OptionState
		{
			get
			{
				return this._optionState;
			}
			set
			{
				this._optionState = value;
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
