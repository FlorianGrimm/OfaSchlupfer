using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class DropClusteredConstraintValueOption : DropClusteredConstraintOption
	{
		private Literal _optionValue;

		public Literal OptionValue
		{
			get
			{
				return this._optionValue;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._optionValue = value;
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
			if (this.OptionValue != null)
			{
				this.OptionValue.Accept(visitor);
			}
		}
	}
}
