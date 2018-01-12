using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class CreateFullTextIndexStatement : TSqlStatement
	{
		private SchemaObjectName _onName;

		private List<FullTextIndexColumn> _fullTextIndexColumns = new List<FullTextIndexColumn>();

		private Identifier _keyIndexName;

		private FullTextCatalogAndFileGroup _catalogAndFileGroup;

		private List<FullTextIndexOption> _options = new List<FullTextIndexOption>();

		public SchemaObjectName OnName
		{
			get
			{
				return this._onName;
			}
			set
			{
				this.UpdateTokenInfo(value);
				this._onName = value;
			}
		}

		public List<FullTextIndexColumn> FullTextIndexColumns
		{
			get
			{
				return this._fullTextIndexColumns;
			}
		}

		public Identifier KeyIndexName
		{
			get
			{
				return this._keyIndexName;
			}
			set
			{
				this.UpdateTokenInfo(value);
				this._keyIndexName = value;
			}
		}

		public FullTextCatalogAndFileGroup CatalogAndFileGroup
		{
			get
			{
				return this._catalogAndFileGroup;
			}
			set
			{
				this.UpdateTokenInfo(value);
				this._catalogAndFileGroup = value;
			}
		}

		public List<FullTextIndexOption> Options
		{
			get
			{
				return this._options;
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
			if (this.OnName != null)
			{
				this.OnName.Accept(visitor);
			}
			int i = 0;
			for (int count = this.FullTextIndexColumns.Count; i < count; i++)
			{
				this.FullTextIndexColumns[i].Accept(visitor);
			}
			if (this.KeyIndexName != null)
			{
				this.KeyIndexName.Accept(visitor);
			}
			if (this.CatalogAndFileGroup != null)
			{
				this.CatalogAndFileGroup.Accept(visitor);
			}
			int j = 0;
			for (int count2 = this.Options.Count; j < count2; j++)
			{
				this.Options[j].Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
