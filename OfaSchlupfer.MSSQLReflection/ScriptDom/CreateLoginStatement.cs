using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class CreateLoginStatement : TSqlStatement
	{
		private Identifier _name;

		private CreateLoginSource _source;

		public Identifier Name
		{
			get
			{
				return this._name;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._name = value;
			}
		}

		public CreateLoginSource Source
		{
			get
			{
				return this._source;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._source = value;
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
			if (this.Source != null)
			{
				this.Source.Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
