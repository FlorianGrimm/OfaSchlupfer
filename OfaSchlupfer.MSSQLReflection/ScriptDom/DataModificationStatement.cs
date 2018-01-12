using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public abstract class DataModificationStatement : StatementWithCtesAndXmlNamespaces
	{
		public override void AcceptChildren(TSqlFragmentVisitor visitor)
		{
			base.AcceptChildren(visitor);
		}
	}
}
