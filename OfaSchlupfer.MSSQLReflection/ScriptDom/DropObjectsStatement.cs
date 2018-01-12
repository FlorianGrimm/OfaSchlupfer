using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public abstract class DropObjectsStatement : TSqlStatement
	{
		private List<SchemaObjectName> _objects = new List<SchemaObjectName>();

		private bool _isIfExists;

		public List<SchemaObjectName> Objects
		{
			get
			{
				return this._objects;
			}
		}

		public bool IsIfExists
		{
			get
			{
				return this._isIfExists;
			}
			set
			{
				this._isIfExists = value;
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
