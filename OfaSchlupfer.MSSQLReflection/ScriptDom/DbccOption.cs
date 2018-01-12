using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class DbccOption : TSqlFragment
	{
		private DbccOptionKind _optionKind;

		public DbccOptionKind OptionKind
		{
			get
			{
				return this._optionKind;
			}
			set
			{
				this._optionKind = value;
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
