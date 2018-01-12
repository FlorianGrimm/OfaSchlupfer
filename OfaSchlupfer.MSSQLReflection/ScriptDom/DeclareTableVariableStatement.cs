using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class DeclareTableVariableStatement : TSqlStatement
	{
		private DeclareTableVariableBody _body;

		public DeclareTableVariableBody Body
		{
			get
			{
				return this._body;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._body = value;
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
			if (this.Body != null)
			{
				this.Body.Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
