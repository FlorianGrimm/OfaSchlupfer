using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class ExternalDataSourceLiteralOrIdentifierOption : ExternalDataSourceOption
	{
		private IdentifierOrValueExpression _value;

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
			base.AcceptChildren(visitor);
			if (this.Value != null)
			{
				this.Value.Accept(visitor);
			}
		}
	}
}
