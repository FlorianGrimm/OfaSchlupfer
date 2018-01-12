using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class DiskStatementOption : TSqlFragment
	{
		private DiskStatementOptionKind _optionKind;

		private IdentifierOrValueExpression _value;

		public DiskStatementOptionKind OptionKind
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

		public IdentifierOrValueExpression Value
		{
			get
			{
				return this._value;
			}
			set
			{
				base.UpdateTokenInfo(value);
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
			if (this.Value != null)
			{
				this.Value.Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
