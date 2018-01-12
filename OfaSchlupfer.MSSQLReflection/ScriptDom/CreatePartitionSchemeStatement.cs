using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class CreatePartitionSchemeStatement : TSqlStatement
	{
		private Identifier _name;

		private Identifier _partitionFunction;

		private bool _isAll;

		private List<IdentifierOrValueExpression> _fileGroups = new List<IdentifierOrValueExpression>();

		public Identifier Name
		{
			get
			{
				return this._name;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._name = value;
			}
		}

		public Identifier PartitionFunction
		{
			get
			{
				return this._partitionFunction;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._partitionFunction = value;
			}
		}

		public bool IsAll
		{
			get
			{
				return this._isAll;
			}
			set
			{
				this._isAll = value;
			}
		}

		public List<IdentifierOrValueExpression> FileGroups
		{
			get
			{
				return this._fileGroups;
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
			if (this.PartitionFunction != null)
			{
				this.PartitionFunction.Accept(visitor);
			}
			int i = 0;
			for (int count = this.FileGroups.Count; i < count; i++)
			{
				this.FileGroups[i].Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
