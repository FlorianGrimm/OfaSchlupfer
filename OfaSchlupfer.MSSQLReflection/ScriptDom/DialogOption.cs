using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public abstract class DialogOption : TSqlFragment
	{
		private DialogOptionKind _optionKind;

		public DialogOptionKind OptionKind
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
