using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class DropTypeStatement : TSqlStatement
	{
		private SchemaObjectName _name;

		private bool _isIfExists;

		public SchemaObjectName Name
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

		public bool IsIfExists
		{
			get
			{
				return this._isIfExists;
			}
			set
			{
				this._isIfExists = value;
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
			base.AcceptChildren(visitor);
		}
	}
}
