using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class DeclareCursorStatement : TSqlStatement
	{
		private Identifier _name;

		private CursorDefinition _cursorDefinition;

		public Identifier Name
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

		public CursorDefinition CursorDefinition
		{
			get
			{
				return this._cursorDefinition;
			}
			set
			{
				this.UpdateTokenInfo(value);
				this._cursorDefinition = value;
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
			if (this.CursorDefinition != null)
			{
				this.CursorDefinition.Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
