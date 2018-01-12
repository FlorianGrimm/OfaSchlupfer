using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class DropSchemaStatement : TSqlStatement
	{
		private SchemaObjectName _schema;

		private DropSchemaBehavior _dropBehavior;

		private bool _isIfExists;

		public SchemaObjectName Schema
		{
			get
			{
				return this._schema;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._schema = value;
			}
		}

		public DropSchemaBehavior DropBehavior
		{
			get
			{
				return this._dropBehavior;
			}
			set
			{
				this._dropBehavior = value;
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
			if (this.Schema != null)
			{
				this.Schema.Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
