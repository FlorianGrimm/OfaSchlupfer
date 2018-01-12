using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class DatabaseAuditAction : TSqlFragment
	{
		private DatabaseAuditActionKind _actionKind;

		public DatabaseAuditActionKind ActionKind
		{
			get
			{
				return this._actionKind;
			}
			set
			{
				this._actionKind = value;
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
