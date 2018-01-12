using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class CreateContractStatement : TSqlStatement, IAuthorization
	{
		private Identifier _name;

		private List<ContractMessage> _messages = new List<ContractMessage>();

		private Identifier _owner;

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

		public List<ContractMessage> Messages
		{
			get
			{
				return this._messages;
			}
		}

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
			if (this.Name != null)
			{
				this.Name.Accept(visitor);
			}
			int i = 0;
			for (int count = this.Messages.Count; i < count; i++)
			{
				this.Messages[i].Accept(visitor);
			}
			if (this.Owner != null)
			{
				this.Owner.Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
