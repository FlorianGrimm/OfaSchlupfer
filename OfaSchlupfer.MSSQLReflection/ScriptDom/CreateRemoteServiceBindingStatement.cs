using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class CreateRemoteServiceBindingStatement : RemoteServiceBindingStatementBase, IAuthorization
	{
		private Literal _service;

		private Identifier _owner;

		public Literal Service
		{
			get
			{
				return this._service;
			}
			set
			{
				this.UpdateTokenInfo(value);
				this._service = value;
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
			if (this.Service != null)
			{
				this.Service.Accept(visitor);
			}
			int i = 0;
			for (int count = base.Options.Count; i < count; i++)
			{
				base.Options[i].Accept(visitor);
			}
			if (this.Owner != null)
			{
				this.Owner.Accept(visitor);
			}
		}
	}
}
