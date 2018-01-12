using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class DbccNamedLiteral : TSqlFragment
	{
		private string _name;

		private ScalarExpression _value;

		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
			}
		}

		public ScalarExpression Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this.UpdateTokenInfo(value);
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
