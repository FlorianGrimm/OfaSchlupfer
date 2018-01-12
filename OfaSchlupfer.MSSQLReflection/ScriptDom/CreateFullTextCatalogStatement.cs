using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class CreateFullTextCatalogStatement : FullTextCatalogStatement, IAuthorization
	{
		private Identifier _fileGroup;

		private Literal _path;

		private bool _isDefault;

		private Identifier _owner;

		public Identifier FileGroup
		{
			get
			{
				return this._fileGroup;
			}
			set
			{
				this.UpdateTokenInfo(value);
				this._fileGroup = value;
			}
		}

		public Literal Path
		{
			get
			{
				return this._path;
			}
			set
			{
				this.UpdateTokenInfo(value);
				this._path = value;
			}
		}

		public bool IsDefault
		{
			get
			{
				return this._isDefault;
			}
			set
			{
				this._isDefault = value;
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
			if (base.Name != null)
			{
				base.Name.Accept(visitor);
			}
			if (this.FileGroup != null)
			{
				this.FileGroup.Accept(visitor);
			}
			if (this.Path != null)
			{
				this.Path.Accept(visitor);
			}
			int i = 0;
			for (int count = base.Options.Count; i < count; i++)
			{
				base.Options[i].Accept(visitor);
			}
			if (this.Owner != null)
			{
				this.Owner.Accept(visitor);
			}
		}
	}
}
