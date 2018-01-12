using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class ExecuteInsertSource : InsertSource
	{
		private ExecuteSpecification _execute;

		public ExecuteSpecification Execute
		{
			get
			{
				return this._execute;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._execute = value;
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
			if (this.Execute != null)
			{
				this.Execute.Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
