using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class CreateSelectiveXmlIndexStatement : IndexStatement
	{
		private bool _isSecondary;

		private Identifier _xmlColumn;

		private List<SelectiveXmlIndexPromotedPath> _promotedPaths = new List<SelectiveXmlIndexPromotedPath>();

		private XmlNamespaces _xmlNamespaces;

		private Identifier _usingXmlIndexName;

		private Identifier _pathName;

		public bool IsSecondary
		{
			get
			{
				return this._isSecondary;
			}
			set
			{
				this._isSecondary = value;
			}
		}

		public Identifier XmlColumn
		{
			get
			{
				return this._xmlColumn;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._xmlColumn = value;
			}
		}

		public List<SelectiveXmlIndexPromotedPath> PromotedPaths
		{
			get
			{
				return this._promotedPaths;
			}
		}

		public XmlNamespaces XmlNamespaces
		{
			get
			{
				return this._xmlNamespaces;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._xmlNamespaces = value;
			}
		}

		public Identifier UsingXmlIndexName
		{
			get
			{
				return this._usingXmlIndexName;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._usingXmlIndexName = value;
			}
		}

		public Identifier PathName
		{
			get
			{
				return this._pathName;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._pathName = value;
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
			if (base.OnName != null)
			{
				base.OnName.Accept(visitor);
			}
			if (this.XmlColumn != null)
			{
				this.XmlColumn.Accept(visitor);
			}
			int i = 0;
			for (int count = this.PromotedPaths.Count; i < count; i++)
			{
				this.PromotedPaths[i].Accept(visitor);
			}
			if (this.XmlNamespaces != null)
			{
				this.XmlNamespaces.Accept(visitor);
			}
			if (this.UsingXmlIndexName != null)
			{
				this.UsingXmlIndexName.Accept(visitor);
			}
			if (this.PathName != null)
			{
				this.PathName.Accept(visitor);
			}
			int j = 0;
			for (int count2 = base.IndexOptions.Count; j < count2; j++)
			{
				base.IndexOptions[j].Accept(visitor);
			}
		}
	}
}
