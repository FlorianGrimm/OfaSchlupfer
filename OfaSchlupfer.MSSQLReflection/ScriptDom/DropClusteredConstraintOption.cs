using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public abstract class DropClusteredConstraintOption : TSqlFragment
	{
		private DropClusteredConstraintOptionKind _optionKind;

		public DropClusteredConstraintOptionKind OptionKind
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

		public override void AcceptChildren(TSqlFragmentVisitor visitor)
		{
			base.AcceptChildren(visitor);
		}
	}
}
