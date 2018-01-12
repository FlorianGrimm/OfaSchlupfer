using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class DropDatabaseStatement : TSqlStatement
	{
		private List<Identifier> _databases = new List<Identifier>();

		private bool _isIfExists;

		public List<Identifier> Databases
		{
			get
			{
				return this._databases;
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

		public override void Accept(TSqlFragmentVisitor visitor)
		{
			if (visitor != null)
			{
				visitor.ExplicitVisit(this);
			}
		}

		public override void AcceptChildren(TSqlFragmentVisitor visitor)
		{
			int i = 0;
			for (int count = this.Databases.Count; i < count; i++)
			{
				this.Databases[i].Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
