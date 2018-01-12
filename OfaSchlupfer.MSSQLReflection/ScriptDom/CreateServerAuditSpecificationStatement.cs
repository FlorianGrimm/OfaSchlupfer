using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class CreateServerAuditSpecificationStatement : AuditSpecificationStatement
	{
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
