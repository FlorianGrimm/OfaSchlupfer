using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class DropAssemblyStatement : DropObjectsStatement
	{
		private bool _withNoDependents;

		public bool WithNoDependents
		{
			get
			{
				return this._withNoDependents;
			}
			set
			{
				this._withNoDependents = value;
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
