using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class CreateFederationStatement : TSqlStatement
	{
		private Identifier _name;

		private Identifier _distributionName;

		private DataTypeReference _dataType;

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

		public Identifier DistributionName
		{
			get
			{
				return this._distributionName;
			}
			set
			{
				this.UpdateTokenInfo(value);
				this._distributionName = value;
			}
		}

		public DataTypeReference DataType
		{
			get
			{
				return this._dataType;
			}
			set
			{
				this.UpdateTokenInfo(value);
				this._dataType = value;
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
			if (this.DistributionName != null)
			{
				this.DistributionName.Accept(visitor);
			}
			if (this.DataType != null)
			{
				this.DataType.Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
