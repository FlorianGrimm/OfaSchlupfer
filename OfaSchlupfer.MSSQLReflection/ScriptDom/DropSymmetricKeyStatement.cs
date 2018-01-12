using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class DropSymmetricKeyStatement : DropUnownedObjectStatement
	{
		private bool _removeProviderKey;

		public bool RemoveProviderKey
		{
			get
			{
				return this._removeProviderKey;
			}
			set
			{
				this._removeProviderKey = value;
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
		}
	}
}
