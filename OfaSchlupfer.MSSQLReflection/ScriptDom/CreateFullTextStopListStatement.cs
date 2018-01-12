using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class CreateFullTextStopListStatement : TSqlStatement, IAuthorization
	{
		private Identifier _name;

		private bool _isSystemStopList;

		private Identifier _databaseName;

		private Identifier _sourceStopListName;

		private Identifier _owner;

		public Identifier Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this.UpdateTokenInfo(value);
				this._name = value;
			}
		}

		public bool IsSystemStopList
		{
			get
			{
				return this._isSystemStopList;
			}
			set
			{
				this._isSystemStopList = value;
			}
		}

		public Identifier DatabaseName
		{
			get
			{
				return this._databaseName;
			}
			set
			{
				this.UpdateTokenInfo(value);
				this._databaseName = value;
			}
		}

		public Identifier SourceStopListName
		{
			get
			{
				return this._sourceStopListName;
			}
			set
			{
				this.UpdateTokenInfo(value);
				this._sourceStopListName = value;
			}
		}

		public Identifier Owner
		{
			get
			{
				return this._owner;
			}
			set
			{
				this.UpdateTokenInfo(value);
				this._owner = value;
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
			if (this.Name != null)
			{
				this.Name.Accept(visitor);
			}
			if (this.DatabaseName != null)
			{
				this.DatabaseName.Accept(visitor);
			}
			if (this.SourceStopListName != null)
			{
				this.SourceStopListName.Accept(visitor);
			}
			if (this.Owner != null)
			{
				this.Owner.Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
