using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class DropFullTextIndexStatement : TSqlStatement
	{
		private SchemaObjectName _tableName;

		public SchemaObjectName TableName
		{
			get
			{
				return this._tableName;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._tableName = value;
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
			if (this.TableName != null)
			{
				this.TableName.Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
