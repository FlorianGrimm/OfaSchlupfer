using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class DropSearchPropertyListAction : SearchPropertyListAction
	{
		private StringLiteral _propertyName;

		public StringLiteral PropertyName
		{
			get
			{
				return this._propertyName;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._propertyName = value;
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
			if (this.PropertyName != null)
			{
				this.PropertyName.Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
