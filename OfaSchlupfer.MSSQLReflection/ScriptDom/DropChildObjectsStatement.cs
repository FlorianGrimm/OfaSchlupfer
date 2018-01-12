using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public abstract class DropChildObjectsStatement : TSqlStatement
	{
		private List<ChildObjectName> _objects = new List<ChildObjectName>();

		public List<ChildObjectName> Objects
		{
			get
			{
				return this._objects;
			}
		}

		public override void AcceptChildren(TSqlFragmentVisitor visitor)
		{
			int i = 0;
			for (int count = this.Objects.Count; i < count; i++)
			{
				this.Objects[i].Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
