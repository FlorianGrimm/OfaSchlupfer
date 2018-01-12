using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class CreateEndpointStatement : AlterCreateEndpointStatementBase, IAuthorization
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
				this.UpdateTokenInfo(value);
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
			if (base.Affinity != null)
			{
				base.Affinity.Accept(visitor);
			}
			int i = 0;
			for (int count = base.ProtocolOptions.Count; i < count; i++)
			{
				base.ProtocolOptions[i].Accept(visitor);
			}
			int j = 0;
			for (int count2 = base.PayloadOptions.Count; j < count2; j++)
			{
				base.PayloadOptions[j].Accept(visitor);
			}
			if (this.Owner != null)
			{
				this.Owner.Accept(visitor);
			}
		}
	}
}
