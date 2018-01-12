using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class CreateMessageTypeStatement : MessageTypeStatementBase, IAuthorization
	{
		private Identifier _owner;

		public Identifier Owner
		{
			get
			{
				return this._owner;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._owner = value;
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
			if (base.Name != null)
			{
				base.Name.Accept(visitor);
			}
			if (base.XmlSchemaCollectionName != null)
			{
				base.XmlSchemaCollectionName.Accept(visitor);
			}
			if (this.Owner != null)
			{
				this.Owner.Accept(visitor);
			}
		}
	}
}
