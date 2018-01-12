using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public abstract class DropUnownedObjectStatement : TSqlStatement
	{
		private Identifier _name;

		private bool _isIfExists;

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
