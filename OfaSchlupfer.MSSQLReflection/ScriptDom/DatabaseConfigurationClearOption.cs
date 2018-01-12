using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class DatabaseConfigurationClearOption : TSqlFragment
	{
		private DatabaseConfigClearOptionKind _optionKind;

		public DatabaseConfigClearOptionKind OptionKind
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
