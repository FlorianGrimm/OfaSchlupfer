using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class CreateDefaultStatement : TSqlStatement
	{
		private SchemaObjectName _name;

		private ScalarExpression _expression;

		public SchemaObjectName Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this.UpdateTokenInfo(value);
				this._name = value;
			}
		}

		public ScalarExpression Expression
		{
			get
			{
				return this._expression;
			}
			set
			{
				this.UpdateTokenInfo(value);
				this._expression = value;
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
			if (this.Name != null)
			{
				this.Name.Accept(visitor);
			}
			if (this.Expression != null)
			{
				this.Expression.Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
