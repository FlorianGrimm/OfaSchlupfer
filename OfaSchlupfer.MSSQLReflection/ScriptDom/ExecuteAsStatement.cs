using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class ExecuteAsStatement : TSqlStatement
	{
		private bool _withNoRevert;

		private VariableReference _cookie;

		private ExecuteContext _executeContext;

		public bool WithNoRevert
		{
			get
			{
				return this._withNoRevert;
			}
			set
			{
				this._withNoRevert = value;
			}
		}

		public VariableReference Cookie
		{
			get
			{
				return this._cookie;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._cookie = value;
			}
		}

		public ExecuteContext ExecuteContext
		{
			get
			{
				return this._executeContext;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._executeContext = value;
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
			if (this.Cookie != null)
			{
				this.Cookie.Accept(visitor);
			}
			if (this.ExecuteContext != null)
			{
				this.ExecuteContext.Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
